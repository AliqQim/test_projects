using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class A
    {
        private readonly B _b;

        public A(B b)
        {
            _b = b;
        }
        public string Write() => $"inner B says: {_b.Say()}";
    }
}