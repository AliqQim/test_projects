using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Controllers;
using WebApplication1.Models;
using Microsoft.Practices.Unity.Mvc;
using Microsoft.Practices.Unity;

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

                B b = new B(typeof(HomeController).ToString(), new C());
                A a = new A(b);
                hc.A = a;


                //A a = _container.Resolve<A>(new ParameterOverride<B>())
                //hc.A = a;
            }
            return res;

        }
    }
}