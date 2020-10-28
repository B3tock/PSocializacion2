using DespachosDataLayer.Entity;
using DespachosDataLayer.SQLServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DespachosDataLayer.Access
{
    public class EstadisticaDataAccess : SQLDALAdapter
    {
        List<SqlParameter> listParameter = new List<SqlParameter>();
        public List<EstadisticaEntity> ConsultarEstadisticas()
        {
            List<EstadisticaEntity> respuesta = new List<EstadisticaEntity>();
            try
            {
                DataSet resultado = GetDataBaseHelper().ExecuteProcedureToDataSet("SP_CONSULTAR_ESTADISTICAS");
                foreach (DataRow row in resultado.Tables[0].Rows)
                {
                    EstadisticaEntity estadistica = new EstadisticaEntity();
                    if (row["PRECIO"] != DBNull.Value)
                        estadistica.Precio = float.Parse(row["PRECIO"].ToString());
                    if (row["PROVEEDOR"] != DBNull.Value)
                        estadistica.Proveedor = row["PROVEEDOR"].ToString();
                    if (row["CATALOGO"] != DBNull.Value)
                        estadistica.Catalogo = row["CATALOGO"].ToString();
                    if (row["COMPLETO"] != DBNull.Value)
                        estadistica.Completo = row["COMPLETO"].ToString();
                    //if (row["FECHA"] != DBNull.Value)
                    //    estadistica.FechaDespacho = Convert.ToDateTime(row["FECHA"]);

                    respuesta.Add(estadistica);
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
