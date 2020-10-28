using DespachosDataLayer.Access;
using DespachosDataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DespachosBusinessLayer.Business
{
    public class DespachoBusiness
    {
        DespachoDataAccess despachoDataAccess = new DespachoDataAccess();
        public List<DespachoEntity> ConsultarDespachos()
        {
            List<DespachoEntity> respuesta = new List<DespachoEntity>();
            respuesta = despachoDataAccess.ConsultarDespachos();
            return respuesta;
        }

        public int InsertarDespacho(DespachoEntity entidad)
        {
            return despachoDataAccess.InsertarDespacho(entidad);
        }

        public int ActualizarDespacho(DespachoEntity entidad)
        {
            return despachoDataAccess.ActualizarDespacho(entidad);
        }

    }
}