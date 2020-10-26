using DespachosDataLayer.Entity;
using DespachosDataLayer.SQLServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DespachosDataLayer.Access
{
    public class CatalogoDataAccess : SQLDALAdapter
    {
        List<SqlParameter> listParameter = new List<SqlParameter>();

        public int InsertarCatalogos(CatalogoServicioEntity entidad)
        {
            List<SqlParameter> listParameter = new List<SqlParameter>();

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@NOMBRE",
                SqlDbType = SqlDbType.VarChar,
                Value = entidad.nombre
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@DESCRIPCION",
                SqlDbType = SqlDbType.VarChar,
                Value = entidad.descricpion
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@PRECIO",
                SqlDbType = SqlDbType.Float,
                Value = entidad.precio
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@ESTADO",
                SqlDbType = SqlDbType.VarChar,
                Value = entidad.estado
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@CATEGORIA",
                SqlDbType = SqlDbType.VarChar,
                Value = entidad.categoria
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@CODIGO_PROVEDOR",
                SqlDbType = SqlDbType.Int,
                Value = entidad.codigoProveedor
            });
            

            int id = 0;
            try
            {
                string resultado = GetDataBaseHelper().ExecuteProcedureScalar("SP_CREAR_CATALOGO", listParameter);
                id = !string.IsNullOrEmpty(resultado) ? Convert.ToInt32(resultado) : 0;
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            return id;
        }
    }
}
