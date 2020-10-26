using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Bridge.SOAPAdapter
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiciosWCF" in both code and config file together.
    [ServiceContract]
    public interface IServiciosWCF
    {
        [OperationContract]
        string Ofertar(Bridge.CanalComun.MensajeMd mensajeXML);
    }
}
