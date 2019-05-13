using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class B
    {
        private readonly string _controllernameBasedKey;

        public B(string controllernameBasedKey)
        {
            _controllernameBasedKey = controllernameBasedKey;
        }

        public string Say() => $"Hey! B! {_controllernameBasedKey}";
    }
}