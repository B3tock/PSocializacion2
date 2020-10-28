using DespachosDataLayer.Access;
using DespachosDataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DespachosBusinessLayer.Business
{
    public class ProveedorBusiness
    {
        ProveedorDataAccess proveedorDataAccess = new ProveedorDataAccess();
        public List<ProveedorEntity> ConsultarProveedores()
        {
            return (new ProveedorDataAccess()).ConsultarProveedores();
        }
    }
}
