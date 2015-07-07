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

        [HttpPost]
        public ActionResult GuardarPersona(entidades.Persona persona)
        {

            var personaExistente = repoPersona.ValidarIndentificacion(persona.Identificacion);


            if(personaExistente == null){

                repoPersona.GuardarPersona(persona);

                Session["id"] = persona.Identificacion;

                var usuario = repoPersona.BuscarPersonaPorIdentificacion(persona.Identificacion);

                return RedirectToAction("GuardarFoto", "Persona",new { id=usuario.Identificacion});

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

        [HttpPost]
        public ActionResult EliminarPersona(int identificacion)
        {
            repoPersona.EliminarPersona(identificacion);
            return Json(new { estado = "ok", mensaje = "Persona eliminada correctamente" }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GuardarFoto()
        {
            return View();
        }


        [HttpPost]
        public ActionResult GuardarFotos(HttpPostedFileBase imagen, entidades.Foto foto)
        {

        
            var nombreimagen = "";
            var rutaVirtual = "";
            
            

            nombreimagen = Path.GetFileName(imagen.FileName);
            rutaVirtual = Path.Combine(Server.MapPath("/imagenes/"), nombreimagen);

            imagen.SaveAs(rutaVirtual);
            

            foto.Id = Guid.NewGuid();
            foto.NombreFoto = nombreimagen;
            
            
            repoPersona.GuardarFoto(foto);

            return RedirectToAction("Index", "Home");
        }


        public ActionResult ValidarIdentificacion(int identificacion)
        {
                
                var usuarioexistente = repoPersona.BuscarPersonaPorIdentificacion(identificacion);

                if (usuarioexistente == null)
                {

                    return Json(new { estado = "ok",mensaje = "identificacion valida" }, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    return Json(new {mensaje = "esta identificacon ya existe" }, JsonRequestBehavior.AllowGet);
                }

        }

    }
}