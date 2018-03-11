using Npgsql;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Negocio.DAO {
    /// <summary>
    /// Classe responsável pelo uso das informações com o banco de dados.
    /// </summary>
    public class Conexao {
        private NpgsqlConnection conn;
        private static Conexao conexao = null;

        /// <summary>
        /// Obtem uma conexão com o banco de dados atraves do arquivo DSN.
        /// </summary>
        /// <returns>Conexão ativa com o banco de dados.</returns>
        public static NpgsqlConnection getConnection() {
            String odbc = getODBC();
            NpgsqlConnection conn = new NpgsqlConnection(odbc);

            conn.Open();
            Console.WriteLine("!!! CONEXÃO REALIZA COM SUCESSO !!!\n");
            
            Console.WriteLine("Informações da conexão:");
            Console.WriteLine("\tConexão String:" + conn.ConnectionString);
            Console.WriteLine("\tConexão Timeout:" + conn.ConnectionTimeout);
            Console.WriteLine("\tBanco de Dados:" + conn.Database);
            Console.WriteLine("\tDataSource:" + conn.DataSource);
            Console.WriteLine("\tVersão do servidor:" + conn.ServerVersion);

            return conn;
        }

        /// <summary>
        /// Realiza procedimentos de INSERT, UPDADE e DELETE com o banco de dados.
        /// </summary>
        /// <param name="cmd">Comando a ser executado.</param>
        public static void CRUD(NpgsqlCommand cmd) {
            cmd.Connection = getConnection();
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Realiza uma consulta no banco de dados.
        /// </summary>
        /// <param name="cmd">Query da consulta.</param>
        /// <returns>DataReader para tratamento de dados.</returns>
        public static NpgsqlDataReader Select(NpgsqlCommand cmd) {
            cmd.Connection = getConnection();
            NpgsqlDataReader dr = cmd.ExecuteReader();
            
            return dr;
        }

        /// <summary>
        /// Obtem as informações do arquivo DSN e transforma em uma String connection.
        /// </summary>
        /// <returns>String connection.</returns>
        private static String getODBC() {
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

        /// <summary>
        /// Tenta fechar a conexão com o banco de dados
        /// </summary>
        public void close() {
            try {
                conn.Close();
            } catch (NpgsqlException ex) {
                Console.Write("ERRO \nMensagem: " + ex.Message + "\n" + "Source: " + ex.Source);
            }
        }
    }
}
