using DespachosDataLayer.Entity;
using DespachosDataLayer.SQLServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
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
                Value = entidad.descripcion
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
        public List<CatalogoServicioEntity> ConsultarCatalogos()
        {
            List<CatalogoServicioEntity> respuesta = new List<CatalogoServicioEntity>();            
            try
            {
                DataSet resultado = GetDataBaseHelper().ExecuteProcedureToDataSet("SP_CONSULTAR_CATALOGOS");
                foreach (DataRow row in resultado.Tables[0].Rows)
                {
                    CatalogoServicioEntity catalogo = new CatalogoServicioEntity();
                    if (row["CODIGO"] != DBNull.Value)
                        catalogo.codigo = Convert.ToInt32(row["CODIGO"]);
                    if (row["NOMBRE"] != DBNull.Value)
                        catalogo.nombre = row["NOMBRE"].ToString();
                    if (row["DESCRIPCION"] != DBNull.Value)
                        catalogo.descripcion = row["DESCRIPCION"].ToString();
                    if (row["PRECIO"] != DBNull.Value)
                        catalogo.precio = float.Parse(row["PRECIO"].ToString());
                    if (row["ESTADO"] != DBNull.Value)
                        catalogo.estado = row["ESTADO"].ToString();
                    if (row["CATEGORIA"] != DBNull.Value)
                        catalogo.categoria = row["CATEGORIA"].ToString();
                    if (row["CODIGO_PROVEDOR"] != DBNull.Value)
                        catalogo.codigoProveedor = Convert.ToInt32(row["CODIGO_PROVEDOR"]);
                    respuesta.Add(catalogo);
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }            

            return respuesta;
        }
        public CatalogoServicioEntity ConsultarCatalogoPorID(int codigo)
        {           
            CatalogoServicioEntity catalogo = new CatalogoServicioEntity();

            List<SqlParameter> listParameter = new List<SqlParameter>();

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@CODIGO",
                SqlDbType = SqlDbType.Int,
                Value = codigo
            });

            try
            {
                DataSet resultado = GetDataBaseHelper().ExecuteProcedureToDataSet("SP_CONSULTAR_CATALOGO_ID", listParameter);
                foreach (DataRow row in resultado.Tables[0].Rows)
                {
                    if (row["CODIGO"] != DBNull.Value)
                        catalogo.codigo = Convert.ToInt32(row["CODIGO"]);
                    if (row["NOMBRE"] != DBNull.Value)
                        catalogo.nombre = row["NOMBRE"].ToString();
                    if (row["DESCRIPCION"] != DBNull.Value)
                        catalogo.descripcion = row["DESCRIPCION"].ToString();
                    if (row["PRECIO"] != DBNull.Value)
                        catalogo.precio = float.Parse(row["PRECIO"].ToString());
                    if (row["ESTADO"] != DBNull.Value)
                        catalogo.estado = row["ESTADO"].ToString();
                    if (row["CATEGORIA"] != DBNull.Value)
                        catalogo.categoria = row["CATEGORIA"].ToString();
                    if (row["CODIGO_PROVEDOR"] != DBNull.Value)
                        catalogo.codigoProveedor = Convert.ToInt32(row["CODIGO_PROVEDOR"]);
                    break;
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            return catalogo;
        }
        public int ActualizarCatalogo(CatalogoServicioEntity entidad)
        {
            List<SqlParameter> listParameter = new List<SqlParameter>();

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@CODIGO",
                SqlDbType = SqlDbType.VarChar,
                Value = entidad.codigo
            });

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
                Value = entidad.descripcion
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
                string resultado = GetDataBaseHelper().ExecuteProcedureScalar("SP_ACTUALIZAR_CATALOGO", listParameter);
                id = !string.IsNullOrEmpty(resultado) ? Convert.ToInt32(resultado) : 0;
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            return id;
        }
        public List<CatalogoServicioEntity> ConsultarCatalogosProveedor(int codigoProveedor)
        {
            List<CatalogoServicioEntity> respuesta = new List<CatalogoServicioEntity>();
            try
            {
                List<SqlParameter> listParameter = new List<SqlParameter>();

                listParameter.Add(new SqlParameter
                {
                    ParameterName = "@CODIGO_PROVEDOR",
                    SqlDbType = SqlDbType.Int,
                    Value = codigoProveedor
                });

                DataSet resultado = GetDataBaseHelper().ExecuteProcedureToDataSet("SP_CONSULTAR_CATALOGOS_PROVEEDOR", listParameter);
                foreach (DataRow row in resultado.Tables[0].Rows)
                {
                    CatalogoServicioEntity catalogo = new CatalogoServicioEntity();
                    if (row["CODIGO"] != DBNull.Value)
                        catalogo.codigo = Convert.ToInt32(row["CODIGO"]);
                    if (row["NOMBRE"] != DBNull.Value)
                        catalogo.nombre = row["NOMBRE"].ToString();
                    if (row["DESCRIPCION"] != DBNull.Value)
                        catalogo.descripcion = row["DESCRIPCION"].ToString();
                    if (row["PRECIO"] != DBNull.Value)
                        catalogo.precio = float.Parse(row["PRECIO"].ToString());
                    if (row["ESTADO"] != DBNull.Value)
                        catalogo.estado = row["ESTADO"].ToString();
                    if (row["CATEGORIA"] != DBNull.Value)
                        catalogo.categoria = row["CATEGORIA"].ToString();
                    if (row["CODIGO_PROVEDOR"] != DBNull.Value)
                        catalogo.codigoProveedor = Convert.ToInt32(row["CODIGO_PROVEDOR"]);
                    respuesta.Add(catalogo);
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            return respuesta;
        }
    }
}
