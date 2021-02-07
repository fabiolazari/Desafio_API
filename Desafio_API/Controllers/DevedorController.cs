using LibraryDesafioAPI.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Desafio_API.Controllers
{
    public class DevedorController : ApiController
    {
        // GET: api/Devedor
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new Devedor().GetAll());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/Devedor/5
        public IHttpActionResult Get(int id)
        {
            Devedor _return = new Devedor(id);
            if (_return.CodigoDevedor == 0)
            {
                return NotFound();
            }
            return Ok(_return);
        }

        // POST: api/Devedor
        public IHttpActionResult Post(Devedor value)
        {
            try
            {
                value.Insert();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok();
        }

        // PUT: api/Devedor/5
        public IHttpActionResult Put(int id, Devedor value)
        {
            Devedor devedor = new Devedor(id);
            devedor.CodigoDevedor = value.CodigoDevedor;
            devedor.CodigoBanco = value.CodigoBanco;
            devedor.CodigoInterno = value.CodigoInterno;
            devedor.NomeCredor = value.NomeCredor;
            devedor.NumeroTitulo = value.NumeroTitulo;
            devedor.Parcela = value.Parcela;
            devedor.NomeDevedor = value.NomeDevedor;
            devedor.CPF_CNPJ_Devedor = value.CPF_CNPJ_Devedor;
            devedor.Endereco_Devedor = value.Endereco_Devedor;
            devedor.Bairro_Devedor = value.Bairro_Devedor;
            devedor.Cidade_Devedor = value.Cidade_Devedor;
            devedor.CEP_Devedor = value.CEP_Devedor;
            devedor.UF_Devedor = value.UF_Devedor;
            devedor.Cidade_Praca_Pagamento = value.Cidade_Praca_Pagamento;
            devedor.UF_Praca_Pagamento = value.UF_Praca_Pagamento;
            devedor.ValorTitulo = value.ValorTitulo;
            devedor.ValorProtestar = value.ValorProtestar;
            devedor.DataEmissao = value.DataEmissao;
            devedor.DataVencimento = value.DataVencimento;
            devedor.TipoDocumento = value.TipoDocumento;
            devedor.Operacao = value.Operacao;
            devedor.Valor1aParcela = value.Valor1aParcela;
            devedor.QtdeParcelaContrato = value.QtdeParcelaContrato;
	
            try
            {
                devedor.Update();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok();
        }

        // DELETE: api/Devedor/5
        public IHttpActionResult Delete(int id)
        {
            Devedor devedor = new Devedor(id);
            try
            {
                devedor.Delete();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok();
        }
    }
}
