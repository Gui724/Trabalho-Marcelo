using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using YeahGames.Modelo;

namespace YeahGames.XML
{
    public class ImportarExportar
    {

        public void criarArquivoXml(List<Jogo> lista)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Jogo>));
            diretorioExiste();
            FileStream fs = new FileStream(@"C:\YeahGames\jogo.xml", FileMode.OpenOrCreate);
            ser.Serialize(fs, lista);
            fs.Close();
        }

        public List<Jogo> lerXml(String fileName)
        {
            List<Jogo> pessoas = new List<Jogo>();
            XmlSerializer ser = new XmlSerializer(typeof(List<Jogo>));
            FileStream fs = new FileStream(@fileName, FileMode.OpenOrCreate);
            pessoas = ser.Deserialize(fs) as List<Jogo>;
            fs.Close();
            return pessoas;
        }

        private void diretorioExiste()
        {
            string diretorio = @"C:\YeahGames";

            if (!Directory.Exists(diretorio))
            {
                Directory.CreateDirectory(diretorio);

            }

        }
    }
}
