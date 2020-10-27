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
                ParameterName = "@PRECIO",
                SqlDbType = SqlDbType.Float,
                Value = entidad.precio
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
                    cotizacion.codigo = Convert.ToInt32(row["CODIGO"]);
                    cotizacion.fecha = Convert.ToDateTime(row["FECHA"]);                    
                    cotizacion.precio = float.Parse(row["PRECIO"].ToString());
                    cotizacion.codigoCatalogo = Convert.ToInt32(row["CODIGO_CATALOGO"]);
                    cotizacion.descripcion = row["DESCRIPCION"].ToString();
                    cotizacion.estado = row["ESTADO"].ToString();
                    cotizacion.codigoDespacho = Convert.ToInt32(row["CODIGO_DESPACHO"]);
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
