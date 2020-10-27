using DespachosDataLayer.Access;
using DespachosDataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DespachosBusinessLayer.Business
{
    public class CotizacionBusiness
    {
        CotizacionDataAccess cotizacionDataAccess = new CotizacionDataAccess();

        public int InsertarCotizacion(CotizacionEntity entidad)
        {
            int id = cotizacionDataAccess.InsertarCotizacion(entidad);
            return id;
        }
        public List<CotizacionEntity> ConsultarCotizaciones()
        {
            List<CotizacionEntity> result = cotizacionDataAccess.ConsultarCotizaciones();
            return result;
        }
        public CotizacionEntity ConsultarCotizacionPorID(int codigo)
        {
            CotizacionEntity result = cotizacionDataAccess.ConsultarCotizacionPorID(codigo);
            return result;
        }
        public int ActualizarCotizacion(CotizacionEntity entidad)
        {
            int id = cotizacionDataAccess.ActualizarCotizacion(entidad);
            return id;
        }
    }
}
