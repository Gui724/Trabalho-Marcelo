using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using YeahGames.DAO;
using YeahGames.Modelo;

namespace YeahGames
{
    /// <summary>
    /// Lógica interna para Cadastrar.xaml
    /// </summary>
    public partial class Cadastrar : Window
    {
        public Cadastrar()
        {
            InitializeComponent();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Jogo jogo = new Jogo()
            {
                Nome = txtNome.Text,
                Categoria = txtCategoria.Text,
                Preco = Convert.ToDecimal(txtPreco.Text)
            };

            JogoDao dao = new JogoDao();
            dao.inserir(jogo);
            MessageBox.Show("Jogo cadastrado com sucesso!");
        }
    }
}
