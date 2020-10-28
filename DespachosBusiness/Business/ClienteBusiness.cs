using DespachosDataLayer.Access;
using DespachosDataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DespachosBusinessLayer.Business
{
    public class ClienteBusiness
    {
        ClienteDataAccess clienteDataAccess = new ClienteDataAccess();
        public List<ClientesEntity> ConsultarClientes()
        {
            return (new ClienteDataAccess()).ConsultarClientes();
        }
    }
}
