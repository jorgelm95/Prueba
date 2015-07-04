using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entidades = RegistroPersonas.Dominio;

namespace RegistroPersonas.Repositorio
{
    public class Persona
    {
        Contexto context;

        public Persona()
        {
            context = new Contexto();
        }


        public void GuardarPersona(entidades.Persona persona)
        {
            persona.Id = Guid.NewGuid();
            //persona.FechaNacimiento = DateTime.Now;//
            context.Personas.Add(persona);

            context.SaveChanges();
        }


        public void ActualizarPerson(entidades.Persona persona)
        {
            var personaActualizar = context.Personas.FirstOrDefault(p => p.Identificacion == persona.Identificacion);

            personaActualizar.Nombres = persona.Nombres;
            personaActualizar.Apellidos = persona.Apellidos;
            personaActualizar.Identificacion = persona.Identificacion;
            personaActualizar.Sexo = persona.Sexo;
            personaActualizar.FechaNacimiento = persona.FechaNacimiento;
            personaActualizar.Profesion = persona.Profesion;

            context.SaveChanges();

        }


        public entidades.Persona BuscarPersonaPorIdentificacion(int identificacion)
        {
            return context.Personas.FirstOrDefault(p => p.Identificacion == identificacion);
        }

        public void EliminarPersona(int identificacion)
        {
            var personaEliminar = context.Personas.FirstOrDefault(p => p.Identificacion == identificacion);
           // personaEliminar.Fotos.RemoveAll(f => f.IdPersona == id);
            context.Personas.Remove(personaEliminar);

            context.SaveChanges();
        }



       


        public List<entidades.Persona> ListaPersonas() {

            List<entidades.Persona> Personas = new List<entidades.Persona>();

           return  Personas = context.Personas.ToList();
        
        }

        public entidades.Persona ValidarIndentificacion(int identificacion)
        {
            var personaIdentificada = context.Personas.FirstOrDefault(p => p.Identificacion == identificacion);
            return personaIdentificada;
        }

        public void  GuardarFoto(entidades.Foto foto)
        {
            context.Fotos.Add(foto);
            context.SaveChanges();
        }

    }
}
