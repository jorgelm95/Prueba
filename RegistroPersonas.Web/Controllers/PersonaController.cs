using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using entidades = RegistroPersonas.Dominio;
using repositorio = RegistroPersonas.Repositorio;

namespace RegistroPersonas.Web.Controllers
{
    public class PersonaController : Controller
    {
        repositorio.Persona repoPersona = new repositorio.Persona();

        public ActionResult ListarPersonas()
        {
            List<entidades.Persona> personas = new List<entidades.Persona>();
            personas = repoPersona.ListaPersonas();
            return View(personas);
        }


        public ActionResult GuardarPersona()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GuardarPersona(entidades.Persona persona)
        {

            var personaExistente = repoPersona.ValidarIndentificacion(persona.Identificacion);

            if(personaExistente == null){

                repoPersona.GuardarPersona(persona);
                return Json(new { estado = "ok", mensaje = "registro exitoso" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { estado = "existente", mensaje = "esta persona ya esta registrada" }, JsonRequestBehavior.AllowGet);
            }
       
        }

        public ActionResult ActualizarPersona()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ActualizarPersona(entidades.Persona persona)
        {


            repoPersona.ActualizarPerson(persona);
            return Json(new{estado= "ok"}, JsonRequestBehavior.AllowGet);
        }


        public ActionResult EliminarPersona(int identificacion)
        {
            repoPersona.EliminarPersona(identificacion);
            return Json(new { estado = "ok", mensaje = "Persona eliminada correctamente" }, JsonRequestBehavior.AllowGet);
        }
            

        [HttpPost]
        public ActionResult GuardarFoto(int identificacion, HttpPostedFileBase imagen, string posicion,string descripcion)
        {

            entidades.Foto fotoguardar = new entidades.Foto();
            var nombreimagen = "";
            var rutaVirtual = "";
            var persona = repoPersona.BuscarPersonaPorIdentificacion(identificacion);

            nombreimagen = Path.GetFileName(imagen.FileName);
            rutaVirtual = Path.Combine(Server.MapPath("/imagenes/"), nombreimagen);

            imagen.SaveAs(rutaVirtual);
            

            fotoguardar.Id = Guid.NewGuid();
            fotoguardar.NombreFoto = nombreimagen;
            fotoguardar.IdPersona = persona.Id;
            fotoguardar.ubicacion = posicion;
            fotoguardar.persona = persona;

            persona.Fotos.Add(fotoguardar);
            repoPersona.GuardarFoto(fotoguardar);

            return Json(new { estado = "ok", mensaje = "imagen subida con exito" }, JsonRequestBehavior.AllowGet);
        }
    }
}