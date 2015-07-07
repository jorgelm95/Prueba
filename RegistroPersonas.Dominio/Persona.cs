using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroPersonas.Dominio
{
   public  class Persona
    {
        public Guid Id { get; set; }

       [Required (ErrorMessage="El cambo es requerido")]
       public int Identificacion { get; set; }
       
       [Required(ErrorMessage="El cambo es requerido")]
       [MaxLength(20)]
        public String Nombres { get; set; }

       [Required(ErrorMessage = "El cambo es requerido")]
       [MaxLength(20)]
       public String Apellidos { get; set; }

       [Required(ErrorMessage = "El cambo es requerido")]
       public string Sexo { get; set; }

       [Required(ErrorMessage = "El cambo es requerido")]
       public DateTime FechaNacimiento { get; set; }

       [Required(ErrorMessage = "El cambo es requerido")]
       public string Profesion { get; set; }

       public virtual List<Foto> listaFotos { get; set; }

    }
}
