using CasoEstudio2.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;

namespace CasoEstudio2.Models
{
    public class CasasModel
    {
        readonly string urlApi = "https://localhost:44347/";
        public List<CasasEnt> ConsultarCasas()
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "ConsultarCasas";
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<List<CasasEnt>>().Result;
            }
        }

        public string AlquilarCasa(CasasEnt casa)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "AlquilarCasa";
                JsonContent contenido = JsonContent.Create(casa);
                var resp = client.PutAsync(url, contenido).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public decimal ConsultarPrecio(CasasEnt casa)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "ConsultarPrecio?q=" + casa.IdCasa;
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<decimal>().Result;
            }
        }

        public List<SelectListItem> Dropdown()
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "Dropdown";
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            }
        }
    }
}