using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading;

namespace CodeBuilder.WinForm.UI
{
    using Util;
    using PhysicalDataModel;
    using Configuration;
    using TemplateEngine;

    public partial class CodeGeneration : Component
    {
        private static Logger logger = InternalTrace.GetLogger(typeof(CodeGeneration));

        private delegate void WorkerEventHandler(GenerationParameter parameter, AsyncOperation asyncOp);
        private SendOrPostCallback onProgressReportDelegate;
        private SendOrPostCallback onCompletedDelegate;

        private HybridDictionary userStateToLifetime = new HybridDictionary();

        public CodeGeneration()
        {
            InitializeComponent();
            InitializeDelegates();
        }

        public CodeGeneration(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            InitializeDelegates();
        }

        protected virtual void InitializeDelegates()
        {
            onProgressReportDelegate = new SendOrPostCallback(ReportProgress);
            onCompletedDelegate = new SendOrPostCallback(GenerateCompleted);
        }

        #region Public events

        public event GenerationProgressChangedEventHandler ProgressChanged;

        public event GenerationCompletedEventHandler Completed;

        #endregion

        #region Async Generate Code

        public virtual void GenerateAsync(GenerationParameter parameter, object taskId)
        {
            AsyncOperation asyncOp = AsyncOperationManager.CreateOperation(taskId);
            lock (userStateToLifetime.SyncRoot)
            {
                if (userStateToLifetime.Contains(taskId)) 
                    throw new ArgumentException("Task ID parameter must be unique", "taskId");

                userStateToLifetime[taskId] = asyncOp;
            }

            WorkerEventHandler workerDelegate = new WorkerEventHandler(GenerateWorker);
            workerDelegate.BeginInvoke(parameter, asyncOp, null, null);
        }

        public void CancelAsync(object taskId)
        {
            AsyncOperation asyncOp = userStateToLifetime[taskId] as AsyncOperation;
            if (asyncOp != null)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(taskId);
                }
            }
        }

        private void GenerateWorker(GenerationParameter parameter, AsyncOperation asyncOp)
        {
            Exception e = null;
            if (IsTaskCanceled(asyncOp.UserSuppliedState)) return;

            int genratedCount = 0;
            int errorCount = 0;
            int progressCount = 0;

            try
            {
                string adapterTypeName = ConfigManager.SettingsSection.TemplateEngines[parameter.Settings.TemplateEngine].Adapter;
                ITemplateEngine engine = (ITemplateEngine)Activator.CreateInstance(Type.GetType(adapterTypeName));

                foreach (string modelId in parameter.GenerationObjects.Keys)
                {
                    this.GenerateCode(parameter, modelId, engine, ref genratedCount, ref errorCount, ref progressCount, asyncOp);
                }
            }
            catch (Exception ex)
            {
                logger.Error("", ex);
                e = ex;
            }

            this.CompletionMethod(e, IsTaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        private void GenerateCode(GenerationParameter parameter, string modelId, ITemplateEngine engine,
            ref int genratedCount, ref int errorCount, ref int progressCount, AsyncOperation asyncOp)
        {
            foreach (string objId in parameter.GenerationObjects[modelId])
            {
                IMetaData modelObject = TemplateDataBuilder.GetModelObject(parameter.Models[modelId], objId);
                if (modelObject == null) continue;

                foreach (string templateName in parameter.Settings.TemplatesNames)
                {
                    TemplateData templateData = TemplateDataBuilder.Build(modelObject, parameter.Settings,
                        templateName, parameter.Models[modelId].Database);
                    if (templateData == null) errorCount++; else genratedCount++;

                    engine.Run(templateData);

                    var args = new GenerationProgressChangedEventArgs(genratedCount,
                            errorCount, templateData.CodeFileName, ++progressCount, asyncOp.UserSuppliedState);
                    asyncOp.Post(this.onProgressReportDelegate, args);
                }
            }
        }

        private void GenerateCompleted(object operationState)
        {
            GenerationCompletedEventArgs e = operationState as GenerationCompletedEventArgs;
            OnCompleted(e);
        }

        private void ReportProgress(object state)
        {
            GenerationProgressChangedEventArgs e = state as GenerationProgressChangedEventArgs;
            OnProgressChanged(e);
        }

        protected void OnCompleted(GenerationCompletedEventArgs e)
        {
            if (Completed != null) Completed(this, e);
        }

        protected void OnProgressChanged(GenerationProgressChangedEventArgs e)
        {
            if (ProgressChanged != null) ProgressChanged(e);
        }

        private void CompletionMethod(Exception exception,bool canceled,AsyncOperation asyncOp)
        {
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            GenerationCompletedEventArgs e = new GenerationCompletedEventArgs(
                exception,
                canceled,
                asyncOp.UserSuppliedState);

            asyncOp.PostOperationCompleted(onCompletedDelegate, e);
        }

        private bool IsTaskCanceled(object taskId)
        {
            return (userStateToLifetime[taskId] == null);
        }
        #endregion
    }
}
