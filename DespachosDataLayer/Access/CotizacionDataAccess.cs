using DespachosDataLayer.Entity;
using DespachosDataLayer.SQLServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DespachosDataLayer.Access
{
    public class CotizacionDataAccess : SQLDALAdapter
    {
        List<SqlParameter> listParameter = new List<SqlParameter>();
        public int InsertarCotizacion(CotizacionEntity entidad)
        {
            List<SqlParameter> listParameter = new List<SqlParameter>();

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@PRECIO",
                SqlDbType = SqlDbType.Float,
                Value = entidad.precio
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@CODIGO_CATALOGO",
                SqlDbType = SqlDbType.Int,
                Value = entidad.codigoCatalogo
            });          

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@DESCRIPCION",
                SqlDbType = SqlDbType.VarChar,
                Value = entidad.descripcion
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@ESTADO",
                SqlDbType = SqlDbType.VarChar,
                Value = entidad.estado
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@CODIGO_DESPACHO",
                SqlDbType = SqlDbType.Int,
                Value = entidad.codigoDespacho
            });


            int id = 0;
            try
            {
                string resultado = GetDataBaseHelper().ExecuteProcedureScalar("SP_CREAR_COTIZACION", listParameter);
                id = !string.IsNullOrEmpty(resultado) ? Convert.ToInt32(resultado) : 0;
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            return id;
        }
        public List<CotizacionEntity> ConsultarCotizaciones()
        {
            List<CotizacionEntity> respuesta = new List<CotizacionEntity>();            
            try
            {
                DataSet resultado = GetDataBaseHelper().ExecuteProcedureToDataSet("SP_CONSULTAR_COTIZACIONES");
                foreach (DataRow row in resultado.Tables[0].Rows)
                {
                    CotizacionEntity cotizacion = new CotizacionEntity();
                    if (row["CODIGO"] != DBNull.Value)
                        cotizacion.codigo = Convert.ToInt32(row["CODIGO"]);
                    if (row["FECHA"] != DBNull.Value)
                        cotizacion.fecha = Convert.ToDateTime(row["FECHA"]);
                    if (row["PRECIO"] != DBNull.Value)
                        cotizacion.precio = float.Parse(row["PRECIO"].ToString());
                    if (row["CODIGO_CATALOGO"] != DBNull.Value)
                        cotizacion.codigoCatalogo = Convert.ToInt32(row["CODIGO_CATALOGO"]);
                    if (row["DESCRIPCION"] != DBNull.Value)
                        cotizacion.descripcion = row["DESCRIPCION"].ToString();
                    if (row["ESTADO"] != DBNull.Value)
                        cotizacion.estado = row["ESTADO"].ToString();
                    if (row["CODIGO_DESPACHO"] != DBNull.Value)
                        cotizacion.codigoDespacho = Convert.ToInt32(row["CODIGO_DESPACHO"]);
                    if (row["CATALOGO"] != DBNull.Value)
                        cotizacion.nombreCatalogo = row["CATALOGO"].ToString();
                    if (row["DIRECCION_ORIGEN"] != DBNull.Value)
                        cotizacion.direccionOrigen = row["DIRECCION_ORIGEN"].ToString();
                    if (row["DIRECCION_DESTINO"] != DBNull.Value)
                        cotizacion.direccionDestino = row["DIRECCION_DESTINO"].ToString();
                    if (row["PROVEEDOR"] != DBNull.Value)
                        cotizacion.proveedor = row["PROVEEDOR"].ToString();
                    if (row["CODIGO_PROVEEDOR"] != DBNull.Value)
                        cotizacion.codigoProveedor = Convert.ToInt32(row["CODIGO_PROVEEDOR"].ToString());
                    respuesta.Add(cotizacion);
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            return respuesta;
        }
        public CotizacionEntity ConsultarCotizacionPorID(int codigo)
        {
            CotizacionEntity cotizacion = new CotizacionEntity();

            List<SqlParameter> listParameter = new List<SqlParameter>();

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@CODIGO",
                SqlDbType = SqlDbType.VarChar,
                Value = codigo
            });

            try
            {
                DataSet resultado = GetDataBaseHelper().ExecuteProcedureToDataSet("SP_CONSULTAR_COTIZACION_ID", listParameter);
                foreach (DataRow row in resultado.Tables[0].Rows)
                {
                    cotizacion.codigo = Convert.ToInt32(row["CODIGO"]);
                    cotizacion.fecha = Convert.ToDateTime(row["FECHA"]);                    
                    cotizacion.precio = float.Parse(row["PRECIO"].ToString());
                    cotizacion.codigoCatalogo = Convert.ToInt32(row["CODIGO_CATALOGO"]);
                    cotizacion.descripcion = row["DESCRIPCION"].ToString();
                    cotizacion.estado = row["ESTADO"].ToString();                    
                    cotizacion.codigoDespacho = Convert.ToInt32(row["CODIGO_DESPACHO"]);
                    break;
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            return cotizacion;
        }
        public int ActualizarCotizacion(CotizacionEntity entidad)
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
                ParameterName = "@PRECIO",
                SqlDbType = SqlDbType.Float,
                Value = entidad.precio
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@CODIGO_CATALOGO",
                SqlDbType = SqlDbType.Int,
                Value = entidad.codigoCatalogo
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@DESCRIPCION",
                SqlDbType = SqlDbType.VarChar,
                Value = entidad.descripcion
            });            

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@ESTADO",
                SqlDbType = SqlDbType.VarChar,
                Value = entidad.estado
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@CODIGO_DESPACHO",
                SqlDbType = SqlDbType.VarChar,
                Value = entidad.codigoDespacho
            });
            
            int id = 0;
            try
            {
                string resultado = GetDataBaseHelper().ExecuteProcedureScalar("SP_ACTUALIZAR_COTIZACION", listParameter);
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
