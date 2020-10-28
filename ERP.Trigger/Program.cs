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
            despacho.direccionDestino = "BOGOTA soacha";
            despacho.direccionOrigen = "BARRANQUILLA soledad";
            //despacho.Ruta 
            despacho.estado = "PENDIENTE"; // "OFERTADO" 
            despacho.fecha = DateTime.Now;
            despacho.NombreCliente = "";
            despacho.observaciones = "Camaron";
            despacho.peso = 1;
            despacho.volumen = 1;

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
