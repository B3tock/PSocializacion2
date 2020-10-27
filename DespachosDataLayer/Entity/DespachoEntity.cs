using System;
using System.Collections.Generic;
using System.Text;

namespace DespachosDataLayer.Entity
{
    public class DespachoEntity
    {
        public int codigo { get; set; }
        public DateTime fecha { get; set; }
        public string direccionOrigen { get; set; }
        public string direccionDestino { get; set; }
        public string observaciones { get; set; }
        public int codigoCliente { get; set; }
        public string estado { get; set; }
        public float peso { get; set; }
        public float volumen { get; set; }
        public string NombreCliente { get; set; }
        public string Ruta { get; internal set; }
    }
}
