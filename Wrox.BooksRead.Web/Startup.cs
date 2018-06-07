using System;
using Microsoft.Owin;
using Owin;
using Unity;
using Wrox.BooksRead.Web.Repository;
using System.Web.Mvc;
using Wrox.BooksRead.Web.Controllers;
using Unity.AspNet.Mvc;
using System.Reflection;
using System.Linq;
using Unity.RegistrationByConvention;
using Unity.Injection;

[assembly: OwinStartupAttribute(typeof(Wrox.BooksRead.Web.Startup))]
namespace Wrox.BooksRead.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var unity = CreateUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(unity));
            ConfigureAuth(app);
        }

        private IUnityContainer CreateUnityContainer()
        {
            UnityContainer container = new UnityContainer();

            //var allAssemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies()
            //                 .Where(a => a.FullName.StartsWith("Wrox.BooksRead.Web.Repository", StringComparison.InvariantCultureIgnoreCase))
            //                 .Select(a => Assembly.Load(a.FullName))
            //                 .Concat(new[] { Assembly.GetExecutingAssembly() })
            //                 .ToArray();

            //var allTypes = AllClasses.FromAssemblies(allAssemblies);

            //#region Register All Types
            //container.RegisterTypes(allTypes, WithMappings.FromMatchingInterface, WithName.Default, WithLifetime.Transient);
            //#endregion


            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            //container.RegisterType<IController, DummyController>("dummy");
            //container.RegisterType<IController, AccountController>("account");
            // container.

            return container;
        }

    }
}
