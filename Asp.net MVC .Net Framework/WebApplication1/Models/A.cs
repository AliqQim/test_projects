using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class A
    {
        private readonly B _b;
        private readonly D _d;

        public A(B b, D d)
        {
            _b = b;
            _d = d;
        }
        public string Write() => $"inner B says: {_b.Say()}; D is {_d}";
    }
}