using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace WebApplication1.App_Start
{
    public class MyDependencyResolver : UnityDependencyResolver, IDependencyResolver
    {
        public MyDependencyResolver(IUnityContainer container) : base(container)
        { }


        object IDependencyResolver.GetService(Type serviceType)
        {
            return base.GetService(serviceType);
        }
    }
}