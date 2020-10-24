using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge.CanalComun
{
    public class MensajeMd
    {
        public int codigo_despacho { get; set; }
        public int codigo_proveedor { get; set; }
        public string servicio { get; set; }
        public double precio { get; set; }
    }
}
