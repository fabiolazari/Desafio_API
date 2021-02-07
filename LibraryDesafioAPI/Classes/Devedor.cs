using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryDesafioAPI.Classes
{
    public partial class Devedor : Backwork<Devedor>, ICRUD
    {

		private int _CodigoDevedor;
        [Key]
        [DisplayName("Código Devedor")]
        [DataObjectField(true, true, false)]
        public int CodigoDevedor
        {
            get { return _CodigoDevedor; }
            set
            {
                _CodigoDevedor = value;
                this._isModified = true;
            }
        }

        private int _CodigoBanco;
        [DisplayName("Código Banco")]
        [DataObjectField(false, false, false)]
        public int CodigoBanco
        {
            get { return _CodigoBanco; }
            set
            {
                _CodigoBanco = value;
                this._isModified = true;
            }
        }

        private string _CodigoInterno;
        [DisplayName("Código Interno")]
        [DataObjectField(false, false, false)]
        public string CodigoInterno
        {
            get
            {
                return _CodigoInterno;
            }
            set
            {
                _CodigoInterno = value;
                this._isModified = true;
            }
        }

        private string _NomeCredor;
        [DisplayName("Credor")]
        [DataObjectField(false, false, false)]
        public string NomeCredor
        {
            get
            {
                return _NomeCredor;
            }
            set
            {
                _NomeCredor = value;
                this._isModified = true;
            }
        }

        private long _NumeroTitulo;
        [DisplayName("Título")]
        [DataObjectField(false, false, false)]
        public long NumeroTitulo
        {
            get
            {
                return _NumeroTitulo;
            }
            set
            {
                _NumeroTitulo = value;
                this._isModified = true;
            }
        }

        private int _Parcela;
        [DisplayName("Parcela")]
        [DataObjectField(false, false, false)]
        public int Parcela
        {
            get
            {
                return _Parcela;
            }
            set
            {
                _Parcela = value;
                this._isModified = true;
            }
        }

        private string _NomeDevedor;
        [DisplayName("Devedor")]
        [DataObjectField(false, false, false)]
        public string NomeDevedor
        {
            get
            {
                return _NomeDevedor;
            }
            set
            {
                _NomeDevedor = value;
                this._isModified = true;
            }
        }

        private string _CPF_CNPJ_Devedor;
        [DisplayName("CPF Devedor")]
        [DataObjectField(false, false, false)]
        public string CPF_CNPJ_Devedor
        {
            get
            {
                return _CPF_CNPJ_Devedor;
            }
            set
            {
                _CPF_CNPJ_Devedor = value;
                this._isModified = true;
            }
        }

        private string _Endereco_Devedor;
        [DisplayName("Endereço")]
        [DataObjectField(false, false, true)]
        public string Endereco_Devedor
        {
            get
            {
                return _Endereco_Devedor;
            }
            set
            {
                _Endereco_Devedor = value;
                this._isModified = true;
            }
        }

        private string _Bairro_Devedor;
        [DisplayName("Bairro")]
        [DataObjectField(false, false, true)]
        public string Bairro_Devedor
        {
            get
            {
                return _Bairro_Devedor;
            }
            set
            {
                _Bairro_Devedor = value;
                this._isModified = true;
            }
        }

        private string _Cidade_Devedor;
        [DisplayName("Cidade")]
        [DataObjectField(false, false, true)]
        public string Cidade_Devedor
        {
            get
            {
                return _Cidade_Devedor;
            }
            set
            {
                _Cidade_Devedor = value;
                this._isModified = true;
            }
        }

        private int _CEP_Devedor;
        [DisplayName("CEP")]
        [DataObjectField(false, false, true)]
        public int CEP_Devedor
        {
            get
            {
                return _CEP_Devedor;
            }
            set
            {
                _CEP_Devedor = value;
                this._isModified = true;
            }
        }

        private string _UF_Devedor;
        [DisplayName("UF")]
        [DataObjectField(false, false, true)]
        public string UF_Devedor
        {
            get
            {
                return _UF_Devedor;
            }
            set
            {
                _UF_Devedor = value;
                this._isModified = true;
            }
        }

        private string _Cidade_Praca_Pagamento;
        [DisplayName("Cidade Praça")]
        [DataObjectField(false, false, true)]
        public string Cidade_Praca_Pagamento
        {
            get
            {
                return _Cidade_Praca_Pagamento;
            }
            set
            {
                _Cidade_Praca_Pagamento = value;
                this._isModified = true;
            }
        }

        private string _UF_Praca_Pagamento;
        [DisplayName("UF Praça")]
        [DataObjectField(false, false, true)]
        public string UF_Praca_Pagamento
        {
            get
            {
                return _UF_Praca_Pagamento;
            }
            set
            {
                _UF_Praca_Pagamento = value;
                this._isModified = true;
            }
        }

        private decimal _ValorTitulo;
        [DisplayName("Valor Título")]
        [DataObjectField(false, false, false)]
        public decimal ValorTitulo
        {
            get
            {
                return _ValorTitulo;
            }
            set
            {
                _ValorTitulo = value;
                this._isModified = true;
            }
        }

        private decimal _ValorProtestar;
        [DisplayName("Valor à Protestar")]
        [DataObjectField(false, false, true)]
        public decimal ValorProtestar
        {
            get
            {
                return _ValorProtestar;
            }
            set
            {
                _ValorProtestar = value;
                this._isModified = true;
            }
        }

        private DateTime _DataEmissao;
        [DisplayName("Emissão"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataObjectField(false, false, false)]
        public DateTime DataEmissao
        {
            get
            {
                return _DataEmissao;
            }
            set
            {
                _DataEmissao = value;
                this._isModified = true;
            }
            
        }

        private DateTime _DataVencimento;
        [DisplayName("Vencimento"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataObjectField(false, false, false)]
        public DateTime DataVencimento
        {
            get
            {
                return _DataVencimento;
            }
            set
            {
                _DataVencimento = value;
                this._isModified = true;
            }
        }

        private string _TipoDocumento;
        [DisplayName("Tipo Documento")]
        [DataObjectField(false, false, true)]
        public string TipoDocumento
        {
            get
            {
                return _TipoDocumento;
            }
            set
            {
                _TipoDocumento = value;
                this._isModified = true;
            }
        }

        private string _Operacao;
        [DisplayName("Operação")]
        [DataObjectField(false, false, true)]
        public string Operacao
        {
            get
            {
                return _Operacao;
            }
            set
            {
                _Operacao = value;
                this._isModified = true;
            }
        }

        private decimal _Valor1aParcela;
        [DisplayName("Valor 1ªParcela")]
        [DataObjectField(false, false, false)]
        public decimal Valor1aParcela
        {
            get
            {
                return _Valor1aParcela;
            }
            set
            {
                _Valor1aParcela = value;
                this._isModified = true;
            }
        }

        private int _QtdeParcelaContrato;
        [DisplayName("Quant.Parcelas")]
        [DataObjectField(false, false, false)]
        public int QtdeParcelaContrato
        {
            get
            {
                return _QtdeParcelaContrato;
            }
            set
            {
                _QtdeParcelaContrato = value;
                this._isModified = true;
            }
        }

        private bool _isNew;
        [Browsable(false)]
        public bool IsNew => _isNew;

        private bool _isModified;
        [Browsable(false)]
        public bool IsModified => _isModified;
    }
}
