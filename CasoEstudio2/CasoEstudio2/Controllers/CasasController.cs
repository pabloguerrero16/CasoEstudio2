using CasoEstudio2.Entities;
using CasoEstudio2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CasoEstudio2.Controllers
{
    public class CasasController : Controller
    {
        CasasModel model = new CasasModel();

        [HttpGet]
        public ActionResult ConsultarCasas()
        {
            var datos = model.ConsultarCasas();
            var ordenados = datos.OrderBy(item => item.UsuarioAlquiler != null).ThenBy(item => item.UsuarioAlquiler).ToList();
            return View(ordenados);
        }

        [HttpGet]
        public ActionResult AlquilarCasas()
        {
            ViewBag.Dropdown = model.Dropdown();
            if (ViewBag.Dropdown == null || !(ViewBag.Dropdown is List<SelectListItem>) || ((List<SelectListItem>)ViewBag.Dropdown).Count == 0)
            {
                ViewBag.ErrorMessage = "No hay casas disponibles";
                return View();
            }
            return View();
        }

        [HttpPost]
        public ActionResult AlquilarCasas(CasasEnt ent)
        {
            var resp = model.AlquilarCasa(ent);
            if (resp != "")
            {
                return RedirectToAction("ConsultarCasas","Casas");
            } 
            else
            {
                ViewBag.MensajeUsuario = "No se ha podido realizar el abono";
                return View();
            }
        }

    }
}