using System;
using System.Collections.Generic;
using System.Text;

namespace DespachosDataLayer.Entity
{
    public abstract class UsuarioEntity
    {
        public int codigo { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string tipoUsuario { get; set; }
        public string nit { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string sitioWeb { get; set; }
        public string direccion { get; set; }
        public bool estado { get; set; }
    }
}
