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

       [Required]
       public int Identificacion { get; set; }
       
       [Required]
       [MaxLength(20)]
        public String Nombres { get; set; }
      
       [Required]
       [MaxLength(20)]
       public String Apellidos { get; set; }
       [Required]
       public string Sexo { get; set; }

       
       public DateTime FechaNacimiento { get; set; }

       [Required]
       public string Profesion { get; set; }

       public virtual List<Foto> Fotos { get; set; }

    }
}
