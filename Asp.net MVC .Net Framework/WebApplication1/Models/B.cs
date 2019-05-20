using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class B
    {
        private readonly string _controllernameBasedKey;
        private readonly C _c;

        public B(string controllernameBasedKey, //имя параметра зарезервировано
            C c)
        {
            _controllernameBasedKey = controllernameBasedKey;
            _c = c;
        }

        public string Say() => $"Hey! B! {_controllernameBasedKey} AND C is: {_c}";
    }
}