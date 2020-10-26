using PublisherSubscriber.Models;
using System;
using System.Collections.Generic;
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
        public RequestPub Post([FromBody] RequestPub requestPub)
        {
            return requestPub;
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
