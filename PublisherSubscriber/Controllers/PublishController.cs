using PublisherSubscriber.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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

            ProveedoresMd pmd = new ProveedoresMd();

            //pmd.Codigo = requestPub.Codigo_proveedor;
            //pmd.Url_Consumo = requestPub.Url_Proveedor;

            CorePOSApi.Business.Data.context.DataModelService da = new CorePOSApi.Business.Data.context.DataModelService();
            string cadena = "SP_CONSULTAR_PROVEEDORES";
            SqlCommand comando = new SqlCommand(cadena, da._connection);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                clienteHttp.BaseAddress = new Uri(registros["URL_CONSUMO"].ToString());
                //clienteHttp.PostAsync();
            //    textBox1.AppendText(registros["codigo"].ToString());
            //    textBox1.AppendText(" - ");
            //    textBox1.AppendText(registros["descripcion"].ToString());
            //    textBox1.AppendText(" - ");
            //    textBox1.AppendText(registros["precio"].ToString());
            //    textBox1.AppendText(Environment.NewLine);
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
