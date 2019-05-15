using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace WebApplication1.App_Start
{
    public class MyDependencyResolver : UnityDependencyResolver, IDependencyResolver
    {
        public MyDependencyResolver(IUnityContainer container) : base(container)
        { }


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
            }
            return res;

        }
    }
}