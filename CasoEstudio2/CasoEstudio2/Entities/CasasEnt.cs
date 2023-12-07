﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CasoEstudio2.Entities
{
    public class CasasEnt
    {
        public long IdCasa { get; set; }

        public string DescripcionCasa { get; set; }

        public decimal PrecioCasa { get; set; }

        public string UsuarioAlquiler { get; set; }

        public DateTime FechaAlquiler { get; set; }

        public string FechaAlquilerFormateada => FechaAlquiler.ToString("dd/MM/yyyy");
    }
}