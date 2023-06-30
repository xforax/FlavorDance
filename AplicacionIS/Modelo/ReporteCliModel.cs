using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacionIS.Modelo
{
    public class ReporteCliModel
    {
        public int Idcli { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public int Hora { get; set; }

    }
}