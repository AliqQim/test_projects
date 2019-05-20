﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Resolution;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace WebApplication1.App_Start
{
    public class MyDependencyResolver : UnityDependencyResolver, IDependencyResolver
    {
        private readonly IUnityContainer _container;

        public MyDependencyResolver(IUnityContainer container) : base(container)
        {
            _container = container;
        }


        object IDependencyResolver.GetService(Type serviceType)
        {
            object res = base.GetService(serviceType);
            if (res is HomeController hc)
            {
                //в реальном примере, тут было несколько потомков базового контроллера, так что передаваемое 
                //имя класса не будет захардкоженным
                //по той же причине мы не можем этот код положить на уровень Unity (кажись)

                hc.A = _container.Resolve<A>(new ParameterOverride("controllernameBasedKey", typeof(HomeController).ToString()));
            }
            return res;

        }
    }
}