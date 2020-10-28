using System;
using System.Collections.Generic;
using System.Text;
using DespachosDataLayer.Entity;
using DespachosBusinessLayer.Business;

namespace Bridge.CanalComun
{
    public class Trasmision
    {
        public static string Completar( MensajeMd mensaje )
        {
            try
            {
                List<CatalogoServicioEntity> servicios = (new CatalogoBusiness()).ConsultarCatalogos();
                CatalogoServicioEntity servicioSeleccionado = null;
                foreach (var servicio in servicios)
                {
                    if (servicio.nombre.ToLower() == mensaje.servicio.ToLower() && servicio.codigoProveedor == mensaje.codigo_proveedor)
                    {
                        servicioSeleccionado = servicio;
                    }
                }

                if (servicioSeleccionado == null)
                {
                    return "SERVICIO NO EXISTE";
                }

                List<CotizacionEntity> cotizaciones = (new CotizacionBusiness()).ConsultarCotizaciones();
                CotizacionEntity cotizacionExistente = null;
                foreach (var cotizacion in cotizaciones)
                {
                    if (cotizacion.codigoDespacho == mensaje.codigo_despacho && cotizacion.codigoCatalogo == servicioSeleccionado.codigo)
                    {
                        cotizacionExistente = cotizacion;
                    }
                }

                if (cotizacionExistente != null)
                {
                    return "YA TIENE UNA COTIZACION CON ESE SERVICIO";
                }

                CotizacionEntity nuevaCotizacion = new CotizacionEntity();

                nuevaCotizacion.codigoCatalogo = servicioSeleccionado.codigo;
                nuevaCotizacion.codigoDespacho = mensaje.codigo_despacho;
                nuevaCotizacion.descripcion = mensaje.mensaje;
                nuevaCotizacion.estado = "PENDIENTE";
                nuevaCotizacion.fecha = DateTime.Now;
                nuevaCotizacion.precio = (float)mensaje.precio;

                int retorno = (new CotizacionBusiness()).InsertarCotizacion(nuevaCotizacion);

                if (retorno > 0)
                {
                    return "PROCESADO CORRECTAMENTE";
                }
                else
                {
                    return "OCURRIO UN ERROR EN LA INSERCION";
                }
            }
            catch(Exception ex)
            {
                return "OCURRIO UNA EXCEPCION EN LA INSERCION";
            }

        }
    }
}
