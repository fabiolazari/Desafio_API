using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDevedor.Models
{
    public class Devedor
    {

        public int CodigoDevedor { get; set; }
        public int CodigoBanco { get; set; }
        public int CodigoInterno { get; set; }
        public string NomeCredor { get; set; }
        public long NumeroTitulo { get; set; }
        public int Parcela { get; set; }
        public string NomeDevedor { get; set; }
        public string CodigoCPF_CNPJ_Devedor { get; set; }
        public double ValorTitulo { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public int Valor1aParcela { get; set; }

    }
}