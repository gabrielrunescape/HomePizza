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
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace HomePizza.View {
    /// <summary>
    /// Lógica interna para Home.xaml
    /// </summary>
    public partial class Home : Window {
        public Home() {
            InitializeComponent();
        }

        private void onClickButton(object sender, RoutedEventArgs e) {
            String texto = txtSearch.Text.Trim();

            PessoaDAO dao = new PessoaDAO();
            IList<Pessoa> list = dao.Select(texto);

            dataGrid.ItemsSource = list;
        }

        private void onClickButton(object sender, TouchEventArgs e) {
            MessageBox.Show("Você apertou o botão", null, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
