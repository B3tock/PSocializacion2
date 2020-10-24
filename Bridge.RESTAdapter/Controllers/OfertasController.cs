using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bridge.RESTAdapter.Controllers
{
    public class OfertasController : ApiController
    {
        public string Post( Bridge.CanalComun.MensajeMd mensajeRest )
        {
            return Bridge.CanalComun.Trasmision.Completar(mensajeRest);
        }
    }
}
