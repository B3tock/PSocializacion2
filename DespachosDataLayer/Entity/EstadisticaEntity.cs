using System;
using System.Collections.Generic;
using System.Text;

namespace DespachosDataLayer.Entity
{
    public class EstadisticaEntity
    {
        public float Precio { get; set; }
        public string Proveedor { get; set; }
        public string Catalogo { get; set; }
        public string Cliente { get; set; }
        public DateTime FechaDespacho { get; set; }
    }
}
