using System;
using Negocio.DAO;
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
using System.Windows.Navigation;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace HomePizza.View {
    /// <summary>
    /// Interação lógica para ClientesPage.xam
    /// </summary>
    public partial class ClientesPage : Page {
        private PessoaDAO dao = new PessoaDAO();

        /// <summary>
        /// Construtor simples para início da aplicação.
        /// </summary>
        public ClientesPage() {
            InitializeComponent();

            dataGrid.ItemsSource = dao.Select();
            
        }

        /// <summary>
        /// Evento ao mudar o texto do TextBox.
        /// </summary>
        /// <param name="sender">Objeto a ser enviado.</param>
        /// <param name="e">TextChangedEvent do TextBox.</param>
        private void txtNameSearch_TextChanged(object sender, TextChangedEventArgs e) {
            String search = txtNameSearch.Text;

            if (String.IsNullOrWhiteSpace(search) || String.IsNullOrEmpty(search)) {
                dataGrid.ItemsSource = dao.Select();
            } else {
                int idx = comboBox.SelectedIndex + 1;
                dataGrid.ItemsSource = dao.Select(search, idx);
            }
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            Pessoa pessoa = (Pessoa) dataGrid.SelectedItem;
            
            PessoaEditWindow wpf = new PessoaEditWindow(pessoa, false);

            wpf.Width = 1020;
            wpf.ShowDialog();
        }
    }
}
