using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacionIS.Modelo
{
    public class ClienteModel
    {
        [Required(ErrorMessage = "El campo Id es obligatorio")]
        public int Id { get; set; }

        // [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Nombre { get; set; }

        //[Required(ErrorMessage = "El campo Apellido es obligatorio")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo Id Sexo es obligatorio")]
        public int IdSexo { get; set; }

        //DESCRIPCION SEXO
        public string Sexo { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Nacimiento es obligatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:YYYY-MM-dd}")]
        public DateTime Fecha_nacimiento { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Inscripcion es obligatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:YYYY-MM-dd}")]
        public DateTime Fecha_inscripcion { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es obligatorio")]
        public string Password { get; set; }
    }
}