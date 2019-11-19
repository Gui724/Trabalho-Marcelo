using Microsoft.Win32;
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
using YeahGames.XML;

namespace YeahGames
{
    /// <summary>
    /// Lógica interna para Importar.xaml
    /// </summary>
    public partial class Importar : Window
    {
        public Importar()
        {
            InitializeComponent();
        }

        private void BtnExportar_Click(object sender, RoutedEventArgs e)
        {
            JogoDao dao = new JogoDao();
            ImportarExportar xml = new ImportarExportar();
            xml.criarArquivoXml(dao.listar());
            MessageBox.Show("Dados exportados com sucesso!");
        }

        private void BtnImportar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml) | *.xml";
            if (openFileDialog.ShowDialog() == true)
            {
                ImportarExportar xml= new ImportarExportar();
                JogoDao dao = new JogoDao();
                foreach (Jogo jogo in xml.lerXml(openFileDialog.FileName))
                {
                    dao.inserir(jogo);
                }
            }

            MessageBox.Show("Dados importados com sucesso!");

        }
    }
}
