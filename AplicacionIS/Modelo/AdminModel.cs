using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacionIS.Modelo
{
    public class AdminModel
    {
        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es obligatorio")]
        public string Password { get; set; }
    }
}