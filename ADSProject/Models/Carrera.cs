using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADSProject.Models
{
    [Table("Carrera")]
    public class Carrera
    {
        public int id { get; set; }
        [Display(Name ="Código")]
        [MaxLength(length: 3, ErrorMessage = "La longitud del campo no puede ser mayor a 3 caracteres.")]
        [Required(ErrorMessage = "Este campo no puede quedar vacio")]
        public string codigo { get; set; }
        [Display(Name= "Nombre")]
        [MinLength(length: 5, ErrorMessage = "La longitud del campo no puede ser menor de 5 caracteres")]
        [MaxLength(length: 40, ErrorMessage = "La longitud del campo no puede ser mayor de 40 caracteres")]
        [Required]
        public string nombre { get; set; }
    }
}