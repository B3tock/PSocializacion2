using DespachosDataLayer.Entity;
using DespachosDataLayer.SQLServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DespachosDataLayer.Access
{
    public class DespachoDataAccess : SQLDALAdapter
    {
        List<SqlParameter> listParameter = new List<SqlParameter>();

        public List<DespachoEntity> ConsultarDespachos()
        {
            List<DespachoEntity> respuesta = new List<DespachoEntity>();
            try
            {
                DataSet resultado = GetDataBaseHelper().ExecuteProcedureToDataSet("SP_CONSULTAR_DESPACHOS");
                foreach (DataRow row in resultado.Tables[0].Rows)
                {
                    DespachoEntity catalogo = new DespachoEntity();
                    if (row["CODIGO"] != DBNull.Value)
                        catalogo.codigo = Convert.ToInt32(row["CODIGO"]);
                    if (row["FECHA"] != DBNull.Value)
                        catalogo.fecha = Convert.ToDateTime(row["FECHA"].ToString());
                    if (row["DIRECCION_ORIGEN"] != DBNull.Value)
                        catalogo.direccionOrigen = row["DIRECCION_ORIGEN"].ToString();
                    if (row["DIRECCION_DESTINO"] != DBNull.Value)
                        catalogo.direccionOrigen = row["DIRECCION_DESTINO"].ToString();
                    if (row["OBSERVACIONES"] != DBNull.Value)
                        catalogo.direccionOrigen = row["OBSERVACIONES"].ToString();
                    if (row["CODIGO_CLIENTE"] != DBNull.Value)
                        catalogo.codigoCliente = Convert.ToInt32(row["CODIGO_CLIENTE"]);
                    if (row["ESTADO"] != DBNull.Value)
                        catalogo.estado = row["ESTADO"].ToString();
                    if (row["PESO"] != DBNull.Value)
                        catalogo.peso = float.Parse(row["PESO"].ToString());
                    if (row["VOLUMEN"] != DBNull.Value)
                        catalogo.volumen = float.Parse(row["VOLUMEN"].ToString());
                    if (row["CLIENTE"] != DBNull.Value)
                        catalogo.NombreCliente = row["CLIENTE"].ToString();
                    if (row["RUTA"] != DBNull.Value)
                        catalogo.Ruta = row["RUTA"].ToString();

                    respuesta.Add(catalogo);
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            return respuesta;
        }

        public int InsertarDespacho(DespachoEntity entidad)
        {
            List<SqlParameter> listParameter = new List<SqlParameter>();

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@FECHA",
                SqlDbType = SqlDbType.DateTime,
                Value = entidad.fecha
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@DIRECCION_ORIGEN",
                SqlDbType = SqlDbType.VarChar,
                Value = entidad.direccionOrigen
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@DIRECCION_DESTINO",
                SqlDbType = SqlDbType.VarChar,
                Value = entidad.direccionDestino
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@OBSERVACIONES",
                SqlDbType = SqlDbType.VarChar,
                Value = entidad.observaciones
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@CODIGO_CLIENTE",
                SqlDbType = SqlDbType.Int,
                Value = entidad.codigoCliente
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@ESTADO",
                SqlDbType = SqlDbType.VarChar,
                Value = entidad.estado
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@PESO",
                SqlDbType = SqlDbType.Float,
                Value = entidad.peso
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@VOLUMEN",
                SqlDbType = SqlDbType.Float,
                Value = entidad.peso
            });

            int id = 0;
            try
            {
                string resultado = GetDataBaseHelper().ExecuteProcedureScalar("SP_CREAR_DESPACHO", listParameter);
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
