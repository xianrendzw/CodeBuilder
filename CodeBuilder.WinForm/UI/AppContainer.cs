using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace CodeBuilder.WinForm.UI
{
    public class AppContainer : Container
    {
        public AppContainer()
        {
            _services = new ServiceContainer();
            _services.AddService(typeof(IServiceContainer), _services);
        }

        private ServiceContainer _services;
        public IServiceContainer Services
        {
            get { return _services; }
        }

        protected override object GetService(Type service)
        {
            object s = _services.GetService(service);
            if (s == null) s = base.GetService(service);
            return s;
        }

        public static ISite GetSite(Control control)
        {
            while (control != null && control.Site == null)
                control = control.Parent;
            return control == null ? null : control.Site;
        }

        public static IContainer GetContainer(Control control)
        {
            ISite site = GetSite(control);
            return site == null ? null : site.Container;
        }

        public static object GetService(Control control, Type service)
        {
            ISite site = GetSite(control);
            return site == null ? null : site.GetService(service);
        }

        public static AppContainer GetAppContainer(Control control)
        {
            return GetContainer(control) as AppContainer;
        }
    } 
}
