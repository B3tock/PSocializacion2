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

            DespachoEntity despacho = new DespachoEntity();

            despacho.codigoCliente = 1;
            despacho.direccionDestino = "MANIZALEZ CENTRO";
            despacho.direccionOrigen = "BOGOTA FONTIBON";
            //despacho.Ruta 
            despacho.estado = "PENDIENTE"; // "OFERTADO" 
            despacho.fecha = DateTime.Now;
            despacho.NombreCliente = "";
            despacho.observaciones = "PS5 pirata";
            despacho.peso = 20;
            despacho.volumen = 60;

            despacho.codigo = (new DespachosBusinessLayer.Business.DespachoBusiness()).InsertarDespacho(despacho);

            PublisherSubscriber.Controllers.PublishController controller = new PublisherSubscriber.Controllers.PublishController();
            PublisherSubscriber.Models.RequestPub request = new PublisherSubscriber.Models.RequestPub();
            request.Codigo_despacho = despacho.codigo.ToString();
            request.Direccion_destino = despacho.direccionDestino;
            request.Direccion_origen = despacho.direccionOrigen;
            request.Peso = despacho.peso.ToString();
            request.Volumen = despacho.volumen.ToString();

            controller.Post(request);
            
        }
    }
}
