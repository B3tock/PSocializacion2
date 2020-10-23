using DespachosDataLayer.Access;
using DespachosDataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DespachosBusinessLayer.Business
{
    public class UsuarioBusiness
    {
        UsuarioDataAccess usuarioDataAccess = new UsuarioDataAccess();

        public long InsertarClientes(ClientesEntity entidad)
        {
            long resultado = usuarioDataAccess.InsertarClientes(entidad);
            return resultado;
        }
    }
}