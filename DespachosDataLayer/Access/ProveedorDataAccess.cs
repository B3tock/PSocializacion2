using DespachosDataLayer.Entity;
using DespachosDataLayer.SQLServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DespachosDataLayer.Access
{
    public class ProveedorDataAccess : SQLDALAdapter
    {

        List<SqlParameter> listParameter = new List<SqlParameter>();

        public List<ProveedorEntity> ConsultarProveedores()
        {
            List<ProveedorEntity> respuesta = new List<ProveedorEntity>();
            try
            {
                DataSet resultado = GetDataBaseHelper().ExecuteProcedureToDataSet("SP_CONSULTAR_PROVEEDORES");
                foreach (DataRow row in resultado.Tables[0].Rows)
                {
                    ProveedorEntity proveedor = new ProveedorEntity();
                    if (row["CODIGO"] != DBNull.Value)
                        proveedor.codigo = Convert.ToInt32(row["CODIGO"]);
                    if (row["NOMBRE"] != DBNull.Value)
                        proveedor.nombre = row["NOMBRE"].ToString();
                    if (row["CORREO"] != DBNull.Value)
                        proveedor.correo = row["CORREO"].ToString();
                    if (row["TELEFONO"] != DBNull.Value)
                        proveedor.telefono = row["TELEFONO"].ToString();
                    respuesta.Add(proveedor);
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
