using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionIS.Modelo
{
    public class AsistenciaModel
    {
        public int IdCliente { get; set; }
        public string NombreCom { get; set; }
        public int HoraCla { get; set; }
        public int IdDiaCla { get; set; }
        public string DiaCla { get; set; }
        public DateTime FechaCla { get; set; }
        public string NomProf { get; set; }
        public string NomGen { get; set; }
    }
}