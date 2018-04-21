using System;
using System.Linq;
using System.Text;
using Negocio.Model;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace HomePizza.View {
    /// <summary>
    /// Lógica interna para PessoaEditWindow.xaml
    /// </summary>
    public partial class PessoaEditWindow : Window {
        public PessoaEditWindow() {
            InitializeComponent();
        }

        public PessoaEditWindow(Pessoa pessoa, bool edit) {
            InitializeComponent();

            try {
                tbTitulo.Text = pessoa.ID + " " + pessoa.Razao + " - Home Pizza";

                if (edit == false) {
                    rbPJ.IsEnabled = false;
                    rbPF.IsEnabled = false;
                    cbCliente.IsEnabled = false;
                    cbFornecedor.IsEnabled = false;
                    cbFuncionario.IsEnabled = false;
                    txtRazao.IsEnabled = false;
                    txtFantasia.IsEnabled = false;
                    txtCNPJ.IsEnabled = false;
                    txtIdentidade.IsEnabled = false;
                    txtEmail.IsEnabled = false;
                    txtTelefone.IsEnabled = false;
                    txtNumero.IsEnabled = false;
                }

                if (String.IsNullOrEmpty(pessoa.CNPJ)) {
                    txtCNPJ.Text = pessoa.CPF;
                }

                txtRazao.Text = pessoa.Razao;
                txtFantasia.Text = pessoa.Fantasia;
                txtIdentidade.Text = pessoa.IE;
                txtEmail.Text = pessoa.Email;
                txtTelefone.Text = pessoa.Telefone;
                txtCodigo.Text = pessoa.CEP.ID + "";
                txtLogradouro.Text = pessoa.CEP.Logradouro + ", " + pessoa.CEP.Bairro;
                txtNumero.Text = pessoa.Numero + "";
                txtCEP.Text = pessoa.CEP.CEP;
                txtMunicipio.Text = pessoa.CEP.Cidade + " - " + pessoa.CEP.UF;
            } catch (NullReferenceException ex) {
                MessageBox.Show(ex.Source, ex.Message, MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
