using System;
using System.Text;
using System.IO;
using System.Reflection;
using NVelocity;
using NVelocity.App;
using NVelocity.Runtime;
using NVelocity.Util.Introspection;

namespace CodeBuilder.TemplateEngine
{
    using Util;

    public class NVelocityAdapter : ITemplateEngine
    {
        private static Logger logger = InternalTrace.GetLogger(typeof(NVelocityAdapter));
        private VelocityEngine velocityEngine;

        public NVelocityAdapter()
        {
            velocityEngine = new VelocityEngine();
        }

        public bool Run(TemplateData templateData)
        {
            VelocityContext context = new VelocityContext();
            context.Put("tdo", templateData);

            try
            {
                string loaderPath = Path.GetDirectoryName(templateData.TemplateFileName);
                string templateFile = Path.GetFileName(templateData.TemplateFileName);
                velocityEngine.SetProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, loaderPath);
                velocityEngine.Init();

                Template template = velocityEngine.GetTemplate(templateFile);
                StreamWriter writer = new StreamWriter(templateData.CodeFileName, false, Encoding.GetEncoding(templateData.Encoding));
                template.Merge(context, writer);
                writer.Close();
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(String.Format("NVelocityAdapter:{0}", templateData.CodeFileName), ex);
                return false;
            }
        }
    }

    public class NVelocityDuck : IDuck
    {
        private readonly object _instance;
        private readonly Type _instanceType;
        private readonly Type[] _extensionTypes;
        private Introspector _introspector;

        public NVelocityDuck(object instance)
        {
            if (instance == null)
                throw new ArgumentNullException("instance");

            _extensionTypes = new Type[] { typeof(StringExtension) };
            _instance = instance;
            _instanceType = _instance.GetType();
        }

        public Introspector Introspector
        {
            get
            {
                if (_introspector == null)
                    _introspector = RuntimeSingleton.Introspector;
                return _introspector;
            }
            set { _introspector = value; }
        }

        public object GetInvoke(string propName)
        {
            return null;
        }

        public void SetInvoke(string propName, object value)
        {
        }

        public object Invoke(string method, params object[] args)
        {
            if (string.IsNullOrEmpty(method)) return null;

            MethodInfo methodInfo = Introspector.GetMethod(_instanceType, method, args);
            if (methodInfo != null) { return methodInfo.Invoke(_instance, args); }

            object[] extensionArgs = new object[args.Length + 1];
            extensionArgs[0] = _instance; 
            Array.Copy(args, 0, extensionArgs, 1, args.Length);
            foreach (Type extensionType in _extensionTypes)
            {
                methodInfo = Introspector.GetMethod(extensionType, method, extensionArgs);
                if (methodInfo != null) { return methodInfo.Invoke(null, extensionArgs); }
            }

            return null;
        }
    }
}
