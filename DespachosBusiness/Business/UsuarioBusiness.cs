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

        public int InsertarClientes(ClientesEntity entidad)
        {
            int resultado = usuarioDataAccess.InsertarClientes(entidad);
            return resultado;
        }

        public ClientesEntity Loginusuario(ClientesEntity entidad)
        {
            ClientesEntity resultado = usuarioDataAccess.Loginusuario(entidad);
            return resultado;
        }
    }
}