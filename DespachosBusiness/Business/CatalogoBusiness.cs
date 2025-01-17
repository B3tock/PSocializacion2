﻿using DespachosDataLayer.Access;
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
        public List<CatalogoServicioEntity> ConsultarCatalogos()
        {
            List<CatalogoServicioEntity> result = catalogoDataAccess.ConsultarCatalogos();
            return result;
        }
        public CatalogoServicioEntity ConsultarCatalogoPorID(int codigo)
        {
            CatalogoServicioEntity result = catalogoDataAccess.ConsultarCatalogoPorID(codigo);
            return result;
        }
        public int ActualizarCatalogo(CatalogoServicioEntity entidad)
        {
            int result = catalogoDataAccess.ActualizarCatalogo(entidad);
            return result;
        }
        public List<CatalogoServicioEntity> ConsultarCatalogosProveedor(int codigoProveedor)
        {
            List<CatalogoServicioEntity> result = catalogoDataAccess.ConsultarCatalogosProveedor(codigoProveedor);
            return result;
        }
    }
}
