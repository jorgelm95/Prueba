using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroPersonas.Dominio
{
   public  class Foto
    {
        public Guid Id { get; set; }
        public string NombreFoto { get; set; }
        public string ubicacion { get; set; }
        public string Descripcion { get; set; }

       [NotMapped]
        public Guid IdPersona { get; set; }
      
       


    }
}
