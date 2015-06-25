using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entidades = RegistroPersonas.Dominio;

namespace RegistroPersonas.Repositorio
{
   public class Foto
    {
       Contexto context;

       public Foto()
       {
           context = new Contexto();
       }


       public void GuardarFoto(entidades.Foto foto)
       {
           foto.Id = Guid.NewGuid();
           context.Fotos.Add(foto);
           context.SaveChanges();

       }

    }
}
