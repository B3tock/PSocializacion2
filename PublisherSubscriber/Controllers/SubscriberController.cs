using PublisherSubscriber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using PublisherSubscriber;

using System.Web.Http;
using System.Web.Caching;

namespace PublisherSubscriber.Controllers
{

    public class SubscriberController : ApiController
    {

        // GET api/Subscriber
        //public IEnumerable<Publisher> Get()
        public string  Get()
        {
            return "Vacio";
        }

        // GET api/Subscriber/5
        public string Get(int id)
        {
            return "value";
        }

// POST api/Subscriber
        public string Post([FromBody] RequestSub requestSub)
        {
            ProveedoresMd pmd = new ProveedoresMd();

            pmd.Codigo = requestSub.Codigo_proveedor;
            pmd.Url_Consumo = requestSub.Url_Proveedor;

            CorePOSApi.Business.Data.context.DataModelService da = new CorePOSApi.Business.Data.context.DataModelService();

            da.ExecuteNonQueryModel<Models.ProveedoresMd>("dbo.SP_UPDATE_PROVEEDORES_URL", pmd);
            return "Subscripción realizada con éxito";

        }

        // PUT api/Subscriber/5
        public string Put(int id, [FromBody] RequestSub requestSub)
        {
            ProveedoresMd pmd = new ProveedoresMd();

            pmd.Codigo = requestSub.Codigo_proveedor;
            pmd.Url_Consumo = "";

            CorePOSApi.Business.Data.context.DataModelService da = new CorePOSApi.Business.Data.context.DataModelService();

            da.ExecuteNonQueryModel<Models.ProveedoresMd>("dbo.SP_UPDATE_PROVEEDORES_URL", pmd);
            return "Subscripción cancelada";

        }

        // DELETE api/Subscriber/5
        public void Delete(int id)
        {

        }
    }
}
