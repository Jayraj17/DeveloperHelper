using DH.Data.Contracts;
using DH.Data.Repository;
using DH.Service.Contract;
using DH.Service.Manager;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DH.API
{
     public static class UnityResolver
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            return container;
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IEmployeeManager, EmployeeManager>(new PerResolveLifetimeManager());
            container.RegisterType<IEmployeeRepository, EmployeeRepository>(new PerResolveLifetimeManager());

            container.RegisterType<IDepartmentManager, DepartmentManager>(new PerResolveLifetimeManager());
            container.RegisterType<IDepartmentRepository, DepartmentRepository>(new PerResolveLifetimeManager());

            container.RegisterType<IEducationManager, EducationManager>(new PerResolveLifetimeManager());
            container.RegisterType<IEducationRepository, EducationRepository>(new PerResolveLifetimeManager());



            //RegisterTypes(container);
            return container;
        }
    }
}