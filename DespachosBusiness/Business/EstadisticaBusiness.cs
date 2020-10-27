﻿using DespachosDataLayer.Access;
using DespachosDataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DespachosBusinessLayer.Business
{
    public class EstadisticaBusiness
    {
        EstadisticaDataAccess estadisticaDataAccess = new EstadisticaDataAccess();

        public List<EstadisticaEntity> ConsultarEstadisticas()
        {
            List<EstadisticaEntity> respuesta = estadisticaDataAccess.ConsultarEstadisticas();
            return respuesta;
        }
    }
}
