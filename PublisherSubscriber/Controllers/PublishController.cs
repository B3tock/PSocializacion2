using PublisherSubscriber.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Net.Http.Formatting;

namespace PublisherSubscriber.Controllers
{
    public class PublishController : ApiController
    {
        // GET: api/Publish
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Publish/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Publish
        public string Post([FromBody] RequestPub requestPub)
        {
            HttpClient clienteHttp = new HttpClient();        
            //Abrir conexion
            CorePOSApi.Business.Data.context.DataModelService da = new CorePOSApi.Business.Data.context.DataModelService();
            string cadena = "SP_CONSULTAR_PROVEEDORES";
            SqlCommand comando = new SqlCommand(cadena, da._connection);
            //Ejecuto consulta de proveedores
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                string url_consumo = registros["URL_CONSUMO"].ToString();
                if  (url_consumo != "")
                {
                    string[] separatingStrings = { "api", "QQQ" };

                    string[] url = url_consumo.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
                    // HttpContent httpContent = new StringContent(requestPub, Encoding.UTF8, "application/json");
                    clienteHttp.BaseAddress = new Uri(url[0]);
                    var request = clienteHttp.PostAsync("api/" + url[1], requestPub, new JsonMediaTypeFormatter()).Result;

                }

            }
            da._connection.Close();

            return "Oferta enviada";
        }

        // PUT: api/Publish/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Publish/5
        public void Delete(int id)
        {
        }
    }
}
