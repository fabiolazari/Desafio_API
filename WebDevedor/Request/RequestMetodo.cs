using LibraryDesafioAPI.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using WebDevedor.Models;
using WebDevedor.Controllers;

namespace WebDevedor.Request
{
    public class RequestMetodo
    {
        string Uri = "http://localhost:53930/api/Devedor";

        public async void BuscaDados()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(Uri))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                        devedor = JsonConvert.DeserializeObject<Devedor[]>(ProdutoJsonString).ToList();
                    }
                }
            }

            devedor = 
        }
    }
}