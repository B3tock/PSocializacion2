using DespachosDataLayer.Entity;
using DespachosDataLayer.SQLServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml.Linq;

namespace DespachosDataLayer.Access
{
    public class UsuarioDataAccess : SQLDALAdapter
    {
        public long InsertarClientes(ClientesEntity entidad)
        {
            List<SqlParameter> listParameter = new List<SqlParameter>();

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@LOGIN",
                SqlDbType = SqlDbType.VarChar,
                Value = entidad.login
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@PASSWORD",
                SqlDbType = SqlDbType.VarChar,
                Value = entidad.password
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@TIPO_USUARIO",
                SqlDbType = SqlDbType.VarChar,
                Value = entidad.tipoUsuario
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@NIT",
                SqlDbType = SqlDbType.VarChar,
                Value = entidad.nit
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@NOMBRE",
                SqlDbType = SqlDbType.VarChar,
                Value = entidad.nombre
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@TELEFONO",
                SqlDbType = SqlDbType.VarChar,
                Value = entidad.telefono
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@RAZON_SOCIAL",
                SqlDbType = SqlDbType.VarChar,
                Value = entidad.razonSocial
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@CORREO",
                SqlDbType = SqlDbType.VarChar,
                Value = entidad.correo
            });

            listParameter.Add(new SqlParameter
            {
                ParameterName = "@SITIO_WEB",
                SqlDbType = SqlDbType.VarChar,
                Value = entidad.sitioWeb
            });            

            int idusuario = 0;
            try
            {
                string resultado = GetDataBaseHelper().ExecuteProcedureScalar("SP_CREAR_USUARIO", listParameter).ToString();
                idusuario = !string.IsNullOrEmpty(resultado) ? Convert.ToInt32(resultado) : 0;
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            return idusuario;
        }
    }
}
