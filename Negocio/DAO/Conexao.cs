using Npgsql;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Negocio.DAO {
    public class Conexao {
        private NpgsqlConnection conn;
        private static Conexao conexao = null;

        public Conexao() {
            NpgsqlConnection conn = new NpgsqlConnection(this.getODBC());

            conn.Open();
            Console.WriteLine("!!! CONEXÃO REALIZA COM SUCESSO !!!\n");
            
            Console.WriteLine("Informações da conexão:");
            Console.WriteLine("\tConexão String:" + conn.ConnectionString);
            Console.WriteLine("\tConexão Timeout:" + conn.ConnectionTimeout);
            Console.WriteLine("\tBanco de Dados:" + conn.Database);
            Console.WriteLine("\tDataSource:" + conn.DataSource);
            Console.WriteLine("\tVersão do servidor:" + conn.ServerVersion);
        }

        public static void CRUD(NpgsqlCommand cmd) {
            cmd.Connection = getConnection();
            cmd.ExecuteNonQuery();
        }

        public static NpgsqlDataReader Select(NpgsqlCommand cmd) {
            cmd.Connection = getConnection();
            NpgsqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            return dr;
        }

        public static NpgsqlConnection getConnection() {
            if (conexao == null) {
                conexao = new Conexao();
            }

            return conexao.conn;
        }

        private String getODBC() {
            String odbc = "";
            String[] dsn = File.ReadAllLines(@"C:\dsninfo.dsn"); ;

            if (File.Exists(@"C:\dsninfo.dsn")) {
                foreach (string line in dsn) {
                    if (!line.Equals(dsn[0])) {
                        odbc += line + ";";
                    }
                }

                return odbc;
            } else {
                Console.WriteLine("Arquivo não encontrado em C:\\!");

                return null;
            }
        }

        public void close() {
            try {
                conn.Close();
            } catch (NpgsqlException ex) {
                Console.Write("ERROR \nMessage: " + ex.Message + "\n" + "Source: " + ex.Source);
            }
        }
    }
}
