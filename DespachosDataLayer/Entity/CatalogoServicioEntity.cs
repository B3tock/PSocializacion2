using System;
using System.Collections.Generic;
using System.Text;

namespace DespachosDataLayer.Entity
{
    public class CatalogoServicioEntity
    {
        public string nombre { get; set; }
        public string descricpion { get; set; }
        public float precio { get; set; }
        public string estado { get; set; }
        public string categoria { get; set; }
        public int codigoProveedor { get; set; }
    }
}
