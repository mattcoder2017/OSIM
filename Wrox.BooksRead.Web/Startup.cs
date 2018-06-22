﻿using System;
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
using System.Web.Http;
using Wrox.BooksRead.Web.Models;

[assembly: OwinStartupAttribute(typeof(Wrox.BooksRead.Web.Startup))]
namespace Wrox.BooksRead.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var unity = CreateUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(unity));
          //  GlobalConfiguration.Configuration.DependencyResolver = new Unity.UnityDependencyResolver(unity);

            ConfigureAuth(app);
        }

        private IUnityContainer CreateUnityContainer()
        {
            UnityContainer container = new UnityContainer();

            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            //var ProductRepo = new ProductRepository();
            container.RegisterType<Product>(new InjectionProperty("ProductRepo"));

            //container.RegisterType<IController, DummyController>("dummy");
            //container.RegisterType<IController, AccountController>("account");
            // container.

            return container;
        }

    }
}
