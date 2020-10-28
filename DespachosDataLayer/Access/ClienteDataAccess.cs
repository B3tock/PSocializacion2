using DespachosDataLayer.Entity;
using DespachosDataLayer.SQLServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DespachosDataLayer.Access
{
    public class ClienteDataAccess : SQLDALAdapter
    {

        List<SqlParameter> listParameter = new List<SqlParameter>();

        public List<ClientesEntity> ConsultarClientes()
        {
            List<ClientesEntity> respuesta = new List<ClientesEntity>();
            try
            {
                DataSet resultado = GetDataBaseHelper().ExecuteProcedureToDataSet("SP_CONSULTAR_CLIENTES");
                foreach (DataRow row in resultado.Tables[0].Rows)
                {
                    ClientesEntity clientes = new ClientesEntity();
                    if (row["CODIGO"] != DBNull.Value)
                        clientes.codigo = Convert.ToInt32(row["CODIGO"]);
                    if (row["NOMBRE"] != DBNull.Value)
                        clientes.nombre = row["NOMBRE"].ToString();
                    if (row["CORREO"] != DBNull.Value)
                        clientes.correo = row["CORREO"].ToString();
                    if (row["TELEFONO"] != DBNull.Value)
                        clientes.telefono = row["TELEFONO"].ToString();
                    respuesta.Add(clientes);
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
