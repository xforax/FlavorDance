using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacionIS.Modelo
{
    public class ClaseModel
    {
        [Required(ErrorMessage = "El campo Hora es obligatorio")]
        public int Hora { get; set; }

        [Required(ErrorMessage = "El campo Dia id es obligatorio")]
        public int Dia { get; set; }

        [Required(ErrorMessage = "El campo Profesor id es obligatorio")]
        public int Profesor { get; set; }

        [Required(ErrorMessage = "El campo Genero id es obligatorio")]
        public int Genero { get; set; }

        public string NomDia { get; set; }
        public string NomProf { get; set; }
        public string NomGen { get; set; }
    }
}