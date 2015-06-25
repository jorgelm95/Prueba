using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entidades = RegistroPersonas.Dominio;
namespace RegistroPersonas.Repositorio
{
   public  class Contexto : DbContext
   {

       public Contexto(): base("RegistroPersonas")
       {

       }

       public DbSet<entidades.Persona> Personas { get; set; }
       public DbSet<entidades.Foto> Fotos { get; set; }
       
   }
}
