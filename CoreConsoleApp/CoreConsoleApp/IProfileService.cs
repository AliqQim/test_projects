using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CoreConsoleApp
{
    [ServiceContract]
    public interface IProfileService
    {
        [OperationContract]
        [FaultContract(typeof(MissingProfileFault))]
        Profile GetProfile(int profileID);
    }
}
