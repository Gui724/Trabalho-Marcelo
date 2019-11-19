using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using YeahGames.Modelo;

namespace YeahGames.DAO
{
    public class JogoDao
    {
        private MySqlConnection conn;
        private String connectionString = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;

        public List<Jogo> listar()
        {
            List<Jogo> listaJogo = new List<Jogo>();
            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                String query = "SELECT * FROM jogo";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Prepare();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Jogo jogo = new Jogo()
                    {
                        IdJogo = Convert.ToInt32(dr["id"]),
                        Nome = Convert.ToString(dr["Nome"]),
                        Categoria = Convert.ToString(dr["Categoria"]),
                        Preco = Convert.ToDecimal(dr["Preco"])
                    };
                    listaJogo.Add(jogo);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listaJogo;


        }

        public void inserir(Jogo jogo)
        {
            conn = new MySqlConnection(connectionString);
            conn.Open();
            String query = "INSERT INTO jogo (nome, categoria, preco) VALUES(@nome,@categoria,@preco);";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@nome", jogo.Nome);
            cmd.Parameters.AddWithValue("@categoria", jogo.Categoria);
            cmd.Parameters.AddWithValue("@preco", jogo.Preco);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    
    }
}
