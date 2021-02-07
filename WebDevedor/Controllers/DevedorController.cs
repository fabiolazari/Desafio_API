using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using LibraryDesafioAPI.Classes;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Ajax.Utilities;
using System.Configuration;

namespace WebDevedor.Controllers
{
    public class DevedorController : Controller
    {
        List<Devedor> dev = new List<Devedor>();
        Devedor devEdit = new Devedor();
        string Uri = "http://localhost:53930/api/Devedor";
        
        // GET: Devedor
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(Uri))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                        dev = JsonConvert.DeserializeObject<Devedor[]>(ProdutoJsonString).ToList();
                    }
                }
            }
            return View(dev.ToList());
        }

        // GET: Devedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Devedor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CodigoDevedor,CodigoBanco,CodigoInterno,NomeCredor,NumeroTitulo,Parcela,NomeDevedor,CPF_CNPJ_Devedor,Endereco_Devedor,Bairro_Devedor,Cidade_Devedor,CEP_Devedor,UF_Devedor,Cidade_Praca_Pagamento,UF_Praca_Pagamento,ValorTitulo,ValorProtestar,DataEmissao,DataVencimento,TipoDocumento,Operacao,Valor1aParcela,QtdeParcelaContrato")] Devedor devedor)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    var serializedProduto = JsonConvert.SerializeObject(devedor);
                    var content = new StringContent(serializedProduto, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(Uri, content);
                }
                return RedirectToAction("Index");
            }
            return View(devedor);
        }

        // GET: Devedor/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(Uri + "/" + id);
                var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                devEdit = JsonConvert.DeserializeObject<Devedor>(ProdutoJsonString);
            }
            return View(devEdit);
        }

        // POST: Devedor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CodigoDevedor,CodigoBanco,CodigoInterno,NomeCredor,NumeroTitulo,Parcela,NomeDevedor,CPF_CNPJ_Devedor,Endereco_Devedor,Bairro_Devedor,Cidade_Devedor,CEP_Devedor,UF_Devedor,Cidade_Praca_Pagamento,UF_Praca_Pagamento,ValorTitulo,ValorProtestar,DataEmissao,DataVencimento,TipoDocumento,Operacao,Valor1aParcela,QtdeParcelaContrato")] Devedor devedor)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    var serializedProduto = JsonConvert.SerializeObject(devedor);
                    var content = new StringContent(serializedProduto, Encoding.UTF8, "application/json");
                    var result = await client.PutAsync(String.Format("{0}/{1}", Uri, devEdit.CodigoDevedor), content);
                }
                return RedirectToAction("Index");
            }
            return View(devedor);
        }

        // GET: Devedor/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(Uri + "/" + id);
                var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                devEdit = JsonConvert.DeserializeObject<Devedor>(ProdutoJsonString);
            }
            ViewData["Id"] = devEdit.CodigoDevedor;
            ViewData["Nome"] = devEdit.NomeDevedor;
            return View(devEdit);
        }

        // POST: Devedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Devedor devedor = new Devedor(id);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Uri);
                HttpResponseMessage responseMessage = await client.DeleteAsync(String.Format("{0}/{1}", Uri, id));
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // devEdit.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
