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

        public Publisher pub = new Publisher();
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
        public RequestSub Post([FromBody] RequestSub requestSub)
        {
            Subscriber sub = new Subscriber();
            pub.Codigo = requestSub.Codigo_proveedor;
            pub.URL = requestSub.Url_Proveedor;
            sub.Subscribe(pub);
            return requestSub;
            //Publisher pub1 = new Publisher();
            //pub1.Na------------------------------------me = "Pub";
            //Subscriber sub1 = new Subscriber();
            //Subscriber sub2 = new Subscriber();
            //Subscriber sub3 = new Subscriber();
            //
            //sub1.Subscribe(pub1);
            //sub2.Subscribe(pub1);
            //sub3.Subscribe(pub1);
            //
            //pub1.Notify("This is First Message");
            //sub2.UnSubscribe(pub1);
            //
            //pub1.Notify("This Message will not show up for sub2");
            //return "funciona";

        }

        // PUT api/Subscriber/5
        public void Put(int id, [FromBody] string value)
        {
            Publisher pub = new Publisher();
        }

        // DELETE api/Subscriber/5
        public void Delete(int id)
        {

        }
    }
}
