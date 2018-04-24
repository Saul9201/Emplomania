using Emplomania.Data;
using Emplomania.Data.ApiClient.Services;
using Emplomania.Data.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.UI.Infrastucture
{
    public static class ServiceLocator
    {
        private static IKernel kernel;

        public static T Get<T>()
        {
            if (kernel == null)
                Initialize();
            return kernel.Get<T>();

        }

        private static void Initialize()
        {
            kernel = new StandardKernel();
            kernel.Bind<EmplomaniaAdminDBContext>().ToSelf().InThreadScope();

            foreach (var interfaceType in typeof(ICategoryService).Assembly.GetTypes()
                .Where(x => x.IsInterface && x.Namespace == "Emplomania.Data.Services"))
            {
                //borrando la I del nombre la la interfaz
                var implType = Type.GetType(string.Format("Emplomania.Data.Services.{0}, Emplomania.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", interfaceType.Name.Substring(1)));
                if (implType != null)
                    kernel.Bind(interfaceType).To(implType).InThreadScope();
            }

            foreach (var interfaceType in typeof(ICategoryWebService).Assembly.GetTypes()
                .Where(x => x.IsInterface && x.Namespace == "Emplomania.Data.ApiClient.Services"))
            {
                //borrando la I del nombre la la interfaz
                var implType = Type.GetType(string.Format("Emplomania.Data.ApiClient.Services.{0}, Emplomania.Data.ApiClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", interfaceType.Name.Substring(1)));
                if (implType != null)
                    kernel.Bind(interfaceType).To(implType).InThreadScope();
            }
        }
    }
}
