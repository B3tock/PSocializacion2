using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Bridge.SOAPAdapter
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiciosWCF" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiciosWCF.svc or ServiciosWCF.svc.cs at the Solution Explorer and start debugging.
    public class ServiciosWCF : IServiciosWCF
    {
        public string Ofertar(Bridge.CanalComun.MensajeMd mensajeXML)
        {
            return Bridge.CanalComun.Trasmision.Completar(mensajeXML);
        }
    }
}
