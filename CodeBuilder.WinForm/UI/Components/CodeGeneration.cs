using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading;

namespace CodeBuilder.WinForm.UI
{
    using Configuration;
    using PhysicalDataModel;
    using Properties;
    using TemplateEngine;
    using Util;

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
                    throw new ArgumentException(Resources.TaskId, "taskId");

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
            if (IsTaskCanceled(asyncOp.UserSuppliedState)) return;

            int genratedCount = 0;
            int errorCount = 0;
            int progressCount = 0;

            try
            {
                string adapterTypeName = ConfigManager.SettingsSection.TemplateEngines[parameter.Settings.TemplateEngine].Adapter;
                ITemplateEngine templateEngine = (ITemplateEngine)Activator.CreateInstance(Type.GetType(adapterTypeName));

                foreach (string templateName in parameter.Settings.TemplatesNames)
                {
                    this.GenerateCode(parameter, templateEngine, templateName, ref genratedCount, ref errorCount, ref progressCount, asyncOp);
                }
            }
            catch (Exception ex)
            {
                logger.Error("", ex);
            }

            this.CompletionMethod(null, IsTaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        private void GenerateCode(GenerationParameter parameter, ITemplateEngine templateEngine, string templateName,
            ref int genratedCount, ref int errorCount, ref int progressCount, AsyncOperation asyncOp)
        {
            foreach (string modelId in parameter.GenerationObjects.Keys)
            {
                string codeFileNamePath = PathHelper.GetCodeFileNamePath(ConfigManager.GenerationCodeOuputPath,
                    ConfigManager.SettingsSection.Languages[parameter.Settings.Language].Alias,
                    ConfigManager.SettingsSection.TemplateEngines[parameter.Settings.TemplateEngine].Name,
                    ConfigManager.TemplateSection.Templates[templateName].DisplayName, parameter.Settings.Package, modelId);
                PathHelper.CreateCodeFileNamePath(codeFileNamePath);

                foreach (string objId in parameter.GenerationObjects[modelId])
                {
                    IMetaData modelObject = ModelManager.GetModelObject(parameter.Models[modelId], objId);
                    TemplateData templateData = TemplateDataBuilder.Build(modelObject, parameter.Settings,
                            templateName, parameter.Models[modelId].Database, modelId);

                    if (templateData == null || !templateEngine.Run(templateData)) errorCount++; else genratedCount++;
                    string currentCodeFileName = templateData == null ? string.Empty : templateData.CodeFileName;

                    var args = new GenerationProgressChangedEventArgs(genratedCount,
                            errorCount, currentCodeFileName, ++progressCount, asyncOp.UserSuppliedState);
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
