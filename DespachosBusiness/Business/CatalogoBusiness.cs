using DespachosDataLayer.Access;
using DespachosDataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DespachosBusinessLayer.Business
{
    public class CatalogoBusiness
    {
        CatalogoDataAccess catalogoDataAccess = new CatalogoDataAccess();

        public int InsertarCatalogos(CatalogoServicioEntity entidad)
        {
            int result = catalogoDataAccess.InsertarCatalogos(entidad);
            return result;
        }
    }
}
