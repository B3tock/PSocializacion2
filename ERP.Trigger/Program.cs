using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;

using DespachosDataLayer.Entity;

namespace ERP.Trigger
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Datos del trigger:");

            string jSonString = System.Console.ReadLine();

            DespachoEntity despacho = Newtonsoft.Json.JsonConvert.DeserializeObject<DespachoEntity>(jSonString);

            System.Console.WriteLine("Deserializado");

            despacho.estado = "PENDIENTE"; // "OFERTADO" 
            despacho.fecha = DateTime.Now;

            despacho.codigo = (new DespachosBusinessLayer.Business.DespachoBusiness()).InsertarDespacho(despacho);

            System.Console.WriteLine("Despacho Creado:" + despacho.codigo );

            PublisherSubscriber.Controllers.PublishController controller = new PublisherSubscriber.Controllers.PublishController();
            PublisherSubscriber.Models.RequestPub request = new PublisherSubscriber.Models.RequestPub();
            request.Codigo_despacho = despacho.codigo.ToString();
            request.Direccion_destino = despacho.direccionDestino;
            request.Direccion_origen = despacho.direccionOrigen;
            request.Peso = despacho.peso.ToString();
            request.Volumen = despacho.volumen.ToString();

            controller.Post(request);

            System.Console.WriteLine("Enviado");

            System.Console.ReadLine();
        }
    }
}
