using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublisherSubscriber.Models
{
    public class RequestPub
    {
        public string Codigo_despacho { get; set;}
        public string Codigo_proveedor { get; set; }
        public string Volumen { get; set; }
        public string Peso { get; set; }
        public string Direccion_origen { get; set; }
        public string Direccion_destino { get; set; }

    }
}