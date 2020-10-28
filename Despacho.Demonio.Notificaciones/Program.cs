using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DespachosDataLayer.Entity;
using DespachosBusinessLayer.Business;
using System.Runtime.InteropServices;

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
                        }
                    }
                }
                System.Threading.Thread.Sleep(10000);
            } while (true);
        }
    }
}
