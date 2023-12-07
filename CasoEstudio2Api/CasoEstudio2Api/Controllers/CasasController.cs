using CasoEstudio2Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CasoEstudio2Api.Controllers
{
    public class CasasController : ApiController
    {
        [HttpGet]
        [Route("ConsultarCasas")]
        public List<CasasSistema> ConsultarCasas()
        {
            using (var context = new CasoEstudioMNEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;
                var casas = context.Database.SqlQuery<CasasSistema>("ConsultarCasas").ToList();

                foreach (var casa in casas)
                {
                    if (casa.UsuarioAlquiler == null)
                    {
                        casa.UsuarioAlquiler = string.Empty;
                    }

                    if (casa.FechaAlquiler == null)
                    {
                        casa.FechaAlquiler = DateTime.MinValue;
                    }
                }

                return casas;

            }
        }

        [HttpPut]
        [Route("AlquilarCasa")]
        public string AlquilarCasa(CasasEnt casa)
        {
            try
            {
                using (var context = new CasoEstudioMNEntities())
                {
                    var Casa = (from c in context.CasasSistema
                                where c.IdCasa == casa.IdCasa
                                select c).FirstOrDefault();
                    if (Casa != null)
                    {
                        Casa.UsuarioAlquiler = casa.UsuarioAlquiler;
                        Casa.FechaAlquiler = DateTime.Now;
                    }
                    context.SaveChanges();
                    return "OK";
                }
            } catch (Exception)
            {
                return string.Empty;
            }
        }

        [HttpGet]
        [Route("ConsultarPrecio")]
        public decimal ConsultarPrecio(long q)
        {
            try
            {
                using (var context = new CasoEstudioMNEntities()) 
                {
                    var precio = (from c in context.CasasSistema
                                  where c.IdCasa == q
                                  select c.PrecioCasa).FirstOrDefault();
                    return precio;
                }
            }catch (Exception)
            {
                return -1;
            }
        }

        [HttpGet]
        [Route("Dropdown")]
        public List<System.Web.Mvc.SelectListItem> Dropdown()
        {
            try
            {
                using (var context = new CasoEstudioMNEntities())
                {
                    var datos = (from c in context.CasasSistema
                                 where c.UsuarioAlquiler == null
                                 select c).ToList();

                    var respuesta = new List<System.Web.Mvc.SelectListItem>();
                    foreach (var item in datos)
                    {
                        respuesta.Add(new System.Web.Mvc.SelectListItem { Value = item.IdCasa.ToString(), Text = item.DescripcionCasa });
                    }
                    return respuesta;
                }
            }
            catch (Exception)
            {
                return new List<System.Web.Mvc.SelectListItem>();
            }
        }

    }
}
