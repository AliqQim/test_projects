using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsoleApp
{
    public class MissingProfileFault
    {
        public MissingProfileFault(string message)
        {
            this.Message = message;
        }

        [DataMember]
        public string Message { get; set; }
    }
}
