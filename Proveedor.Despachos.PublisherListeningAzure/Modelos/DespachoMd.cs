using System;
using System.Collections.Generic;
using System.Text;

namespace Proveedor.Despachos.PublisherListeningAzure.Modelos
{
    public class DespachoMd
    {
        public int codigo_despacho { get; set; }
        public int codigo_proveedor { get; set; }
        public float volumen { get; set; }
        public float peso { get; set; }
        public string direccion_origen { get; set; }
        public string direccion_destino { get; set; }
    }
}
