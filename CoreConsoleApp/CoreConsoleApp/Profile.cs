using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsoleApp
{
    [DataContract]
    public class Profile
    {

        [DataMember]
        public int ProfileID { get; set; }
        [DataMember]
        public string? FirstName { get; set; }
        [DataMember]
        public string? LastName { get; set; }
        [DataMember]
        public string? Email { get; set; }
        [DataMember]
        public string? HomeAddress { get; set; }
    }
}
