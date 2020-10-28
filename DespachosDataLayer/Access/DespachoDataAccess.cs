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

        public List<DespachoEntity> ConsultarDespachosPorCliente(int codigo)
        {
            List<DespachoEntity> respuesta = new List<DespachoEntity>();

            List<SqlParameter> listParameter = new List<SqlParameter>();

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@CODIGO",
                SqlDbType = SqlDbType.Int,
                Value = codigo
            });
            try
            {
                DataSet resultado = GetDataBaseHelper().ExecuteProcedureToDataSet("SP_CONSULTAR_DESPACHOS_CLIENTES", listParameter);
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
                        catalogo.direccionDestino = row["DIRECCION_DESTINO"].ToString();
                    if (row["OBSERVACIONES"] != DBNull.Value)
                        catalogo.observaciones = row["OBSERVACIONES"].ToString();
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
    }
}
