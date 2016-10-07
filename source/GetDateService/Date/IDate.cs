using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;

namespace Date
{
    [ServiceContract]
    public interface IDate
    {

        [OperationContract]
        string GetCurrentDate();

    }
}
