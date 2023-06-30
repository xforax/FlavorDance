using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacionIS.Modelo
{
    public class ProfesorModel
    {
        [Required(ErrorMessage = "El campo Id es obligatorio")]
        public int Id { get; set; }

        // [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Nombre { get; set; }

        //[Required(ErrorMessage = "El campo Apellido es obligatorio")]
        public string Apellido { get; set; }

        public string Experiencia { get; set; }
    }
}