using System;
using System.Collections.Generic;
using System.Text;

namespace DespachosDataLayer.Entity
{
    public class CotizacionEntity
    {
        public int codigo { get; set; }
        public DateTime fecha { get; set; }
        public float precio { get; set; }
        public int codigoCatalogo { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
        public int codigoDespacho { get; set; }
        public string nombreCatalogo { get; internal set; }
        public string direccionOrigen { get; internal set; }
        public string direccionDestino { get; internal set; }
        public string proveedor { get; internal set; }
        public int codigoProveedor { get; internal set; }
    }
}
