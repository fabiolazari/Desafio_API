using LibraryDesafioAPI.Classes;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace FormDevedor
{
    public partial class FrmDevedor : Form
    {
        string Uri = "http://localhost:53930/api/Devedor";
        bool Novo = false;
        BindingSource dados = new BindingSource();

        public FrmDevedor()
        {
            InitializeComponent();
        }

        private void FrmDevedor_Load(object sender, EventArgs e)
        {
            GridDevedor.AllowUserToAddRows = false;
            GridDevedor.AllowUserToDeleteRows = false;
            GridDevedor.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridDevedor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridDevedor.RowHeadersVisible = false;
            GridDevedor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            GridDevedor.RowTemplate.Resizable = DataGridViewTriState.False;
            GridDevedor.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            CarregaDevedores();
        }

        private async void CarregaDevedores()
        {
			using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(Uri))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var ProdutoJsonString = await response.Content.ReadAsStringAsync();
                        dados.DataSource = new BindingList<Devedor>(JsonConvert.DeserializeObject<Devedor[]>(ProdutoJsonString).ToList());
                        GridDevedor.DataSource = dados;

						//Carregando TextBoxes
						TxtCodigoDevedor.DataBindings.Add("Text", dados, "CodigoDevedor", true, DataSourceUpdateMode.OnPropertyChanged);
                        TxtCodigoBanco.DataBindings.Add("Text", dados, "CodigoBanco", true, DataSourceUpdateMode.OnPropertyChanged);
                        TxtCodigoInterno.DataBindings.Add("Text", dados, "CodigoInterno", true, DataSourceUpdateMode.OnPropertyChanged);
                        TxtNomeCredor.DataBindings.Add("Text", dados, "NomeCredor", true, DataSourceUpdateMode.OnPropertyChanged);
                        TxtNumeroTitulo.DataBindings.Add("Text", dados, "NumeroTitulo", true, DataSourceUpdateMode.OnPropertyChanged);
                        TxtParcela.DataBindings.Add("Text", dados, "Parcela", true, DataSourceUpdateMode.OnPropertyChanged);
                        TxtNomeDevedor.DataBindings.Add("Text", dados, "NomeDevedor", true, DataSourceUpdateMode.OnPropertyChanged);
                        TxtCpfCnpj.DataBindings.Add("Text", dados, "CPF_CNPJ_Devedor", true, DataSourceUpdateMode.OnPropertyChanged);
                        TxtEndereco.DataBindings.Add("Text", dados, "Endereco_Devedor", true, DataSourceUpdateMode.OnPropertyChanged);
                        TxtBairro.DataBindings.Add("Text", dados, "Bairro_Devedor", true, DataSourceUpdateMode.OnPropertyChanged);
                        TxtCidade.DataBindings.Add("Text", dados, "Cidade_Devedor", true, DataSourceUpdateMode.OnPropertyChanged);
                        TxtCep.DataBindings.Add("Text", dados, "CEP_Devedor", true, DataSourceUpdateMode.OnPropertyChanged);
                        TxtUF.DataBindings.Add("Text", dados, "UF_Devedor", true, DataSourceUpdateMode.OnPropertyChanged);
                        TxtCidadePraca.DataBindings.Add("Text", dados, "Cidade_Praca_Pagamento", true, DataSourceUpdateMode.OnPropertyChanged);
                        TxtUFPraca.DataBindings.Add("Text", dados, "UF_Praca_Pagamento", true, DataSourceUpdateMode.OnPropertyChanged);
                        TxtValorTitulo.DataBindings.Add("Text", dados, "ValorTitulo", true, DataSourceUpdateMode.OnPropertyChanged);
                        TxtValorProtestar.DataBindings.Add("Text", dados, "ValorProtestar", true, DataSourceUpdateMode.OnPropertyChanged);
                        DatEmissao.DataBindings.Add("Text", dados, "DataEmissao", true, DataSourceUpdateMode.OnPropertyChanged);
                        DatVencimento.DataBindings.Add("Text", dados, "DataVencimento", true, DataSourceUpdateMode.OnPropertyChanged);
                        TxtTipoDocumento.DataBindings.Add("Text", dados, "TipoDocumento", true, DataSourceUpdateMode.OnPropertyChanged);
                        TxtOperacao.DataBindings.Add("Text", dados, "Operacao", true, DataSourceUpdateMode.OnPropertyChanged);
                        TxtValorParcela.DataBindings.Add("Text", dados, "Valor1aParcela", true, DataSourceUpdateMode.OnPropertyChanged);
                        TxtQuantidadeParcelas.DataBindings.Add("Text", dados, "QtdeParcelaContrato", true, DataSourceUpdateMode.OnPropertyChanged);
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter o dados: " + response.StatusCode);
                    }
                }
            }
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            BtnNovo.Enabled = false;
            BtnExcluir.Enabled = false;
            Novo = true;
            dados.Add(new Devedor());
            
            dados.MoveLast();
        }

        private async void BtnGravar_Click(object sender, EventArgs e)
        {
            int id_devedor = Convert.ToInt32(TxtCodigoDevedor.Text);
            if (Novo)
            {
                using (var client = new HttpClient())
                {
                    var serializedProduto = JsonConvert.SerializeObject(((Devedor)dados.Current));
                    var content = new StringContent(serializedProduto, Encoding.UTF8, "application/json");
                    HttpResponseMessage responseMessage = await client.PostAsync(Uri, content);
                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Falha ao incluir o registro: " + responseMessage.StatusCode);
                    }
                }
            }
            else
            {
                using (var client = new HttpClient())
                {
                    var serializedProduto = JsonConvert.SerializeObject(((Devedor)dados.Current));
                    var content = new StringContent(serializedProduto, Encoding.UTF8, "application/json");
                    HttpResponseMessage responseMessage = await client.PutAsync(String.Format("{0}/{1}", Uri, id_devedor), content);
                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Falha ao atualizar o registro: " + responseMessage.StatusCode);
                    }
                }
            }
            BtnNovo.Enabled = true;
            BtnExcluir.Enabled = true;
            
            Novo = false;
        }

        private async void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir esse Devedor?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                BtnNovo.Enabled = true;
                BtnExcluir.Enabled = true;

                int id_devedor = Convert.ToInt32(TxtCodigoDevedor.Text);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Uri);
                    HttpResponseMessage responseMessage = await client.DeleteAsync(String.Format("{0}/{1}", Uri, id_devedor));
                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Falha ao excluir o Devedor: " + responseMessage.StatusCode);
                    }
                }
                dados.RemoveCurrent();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            BtnNovo.Enabled = true;
            BtnExcluir.Enabled = true;
            dados.CancelEdit();
            dados.RemoveCurrent();
            dados.MoveFirst();
        }
    }
}
