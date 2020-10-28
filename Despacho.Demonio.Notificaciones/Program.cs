using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DespachosDataLayer.Entity;
using DespachosBusinessLayer.Business;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;

namespace Despacho.Demonio.Notificaciones
{
    class Program
    {
        static void Main(string[] args)
        {
            ciclo();            
        }


        public static void ciclo()
        {
            do
            {
                System.Console.WriteLine("Identificando Despachos pendientes");
                List<DespachoEntity> despachos = (new DespachoBusiness()).ConsultarDespachos();
                List<CotizacionEntity> cotizaciones = (new CotizacionBusiness()).ConsultarCotizaciones();
                List<ProveedorEntity> proveedores = (new ProveedorBusiness()).ConsultarProveedores();
                List<ClientesEntity> clientes = (new ClienteBusiness()).ConsultarClientes();

                List<CotizacionEntity> cotizacionesReview = new List<CotizacionEntity>();
                
                foreach ( var despacho in despachos )
                {
                    if( despacho.estado == "PENDIENTE" )
                    {
                        int ofertas = 0;
                        foreach( var proveedor in proveedores )
                        {
                            bool oferto = false;
                            foreach( var cotizacion in cotizaciones )
                            {
                                if( cotizacion.codigoProveedor == proveedor.codigo && despacho.codigo == cotizacion.codigoDespacho )
                                {
                                    cotizacionesReview.Add(cotizacion);
                                    oferto = true;
                                }
                            }
                            if( oferto )
                            {
                                ofertas++;
                            }
                        }
                        if( proveedores.Count() == ofertas )
                        {
                            despacho.estado = "ASIGNADO";
                            (new DespachoBusiness()).ActualizarDespacho(despacho);
                            System.Console.WriteLine("Despacho:" + despacho.codigo.ToString() + " :" + despacho.estado );

                            CotizacionEntity menor = null;

                            foreach( var cotizacion in cotizacionesReview )
                            {
                                if (menor == null) menor = cotizacion;
                                if( menor.precio > cotizacion.precio )
                                {
                                    menor = cotizacion;
                                }
                            }
                            foreach(var cotizacion in cotizacionesReview)
                            {
                                if( menor.codigo != cotizacion.codigo )
                                {
                                    cotizacion.estado = "RECHAZADA";
                                    (new CotizacionBusiness()).ActualizarCotizacion( cotizacion );
                                }
                            }
                            menor.estado = "APROBADA";
                            (new CotizacionBusiness()).ActualizarCotizacion(menor);
                            ProveedorEntity proveedorSeleccionado = null;
                            foreach( var proveedor in proveedores )
                            {
                                if(proveedor.codigo == menor.codigoProveedor )
                                {
                                    proveedorSeleccionado = proveedor;
                                }
                            }
                            System.Console.WriteLine("Cotizacion:" + proveedorSeleccionado.nombre + " :" + menor.estado);
                            string texto = "El proveedor seleccionado para su despacho es: " + proveedorSeleccionado.nombre + " valor:" + menor.precio.ToString();
                            string telefono = string.Empty;

                            foreach( var cliente in clientes )
                            {
                                if( cliente.codigo == despacho.codigoCliente )
                                {
                                    telefono = cliente.telefono;
                                }
                            }

                            controlSMS.Service SMSproxy = new controlSMS.Service();

                            string retorno = SMSproxy.SSA( telefono + "|" + texto + "|do-not-reply@controlsms.net|");

                            SMSproxy.Dispose();

                        }
                    }
                }
                System.Threading.Thread.Sleep(10000);
            } while (true);
        }
    }
}
