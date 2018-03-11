using Npgsql;
using System;
using System.Data;
using System.Linq;
using System.Text;
using Negocio.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Negocio.DAO {
    /// <summary>
    /// Classe responsável por controlar todas as informações da tabela Pessoa.
    /// </summary>
    public class PessoaDAO {
        /// <summary>
        /// Insere uma Pessoa no banco de dados.
        /// </summary>
        /// <param name="pessoa">Valores a serem inseridos.</param>
        public void Insert(Pessoa pessoa) {
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Pessoa (Nome, CPF, CNPJ, Email) VALUES (@Nome, @CPF, @CNPJ, @Email)";

            cmd.Parameters.AddWithValue("@CPF", pessoa.CPF);
            cmd.Parameters.AddWithValue("@CNPJ", pessoa.CNPJ);
            cmd.Parameters.AddWithValue("@Nome", pessoa.Nome);
            cmd.Parameters.AddWithValue("@Email", pessoa.Email);

            Conexao.CRUD(cmd);
        }

        /// <summary>
        /// Altera uma Pessoa existente no banco de dados.
        /// </summary>
        /// <param name="pessoa">Valores a serem alterados.</param>
        public void Update(Pessoa pessoa) {
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Pessoa SET Nome = @Nome, CPF = @CPF, CNPJ = @CNPJ, Email = @Email WHERE ID = @ID";
            
            cmd.Parameters.AddWithValue("@ID", pessoa.ID);
            cmd.Parameters.AddWithValue("@CPF", pessoa.CPF);
            cmd.Parameters.AddWithValue("@CNPJ", pessoa.CNPJ);
            cmd.Parameters.AddWithValue("@Nome", pessoa.Nome);
            cmd.Parameters.AddWithValue("@Email", pessoa.Email);

            Conexao.CRUD(cmd);
        }

        /// <summary>
        /// Apaga uma Pessoa existente.
        /// </summary>
        /// <param name="pessoa">Pessoa a ser apagada.</param>
        public void Delete(Pessoa pessoa) {
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM Pessoa WHERE ID = @ID";

            cmd.Parameters.AddWithValue("@ID", pessoa.ID);

            Conexao.CRUD(cmd);
        }

        /// <summary>
        /// Obtém uma Pessoa do banco de dados.
        /// </summary>
        /// <param name="id">Código identificador da Pessoa.</param>
        /// <returns>Pessoa encontrada.</returns>
        public Pessoa Select(int id) {
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Pessoa WHERE ID = @ID";

            Pessoa p = new Pessoa();
            cmd.Parameters.AddWithValue("@ID", id);
            NpgsqlDataReader dr = Conexao.Select(cmd);

            if (dr.HasRows) {
                dr.Read();

                p.ID = id;
                p.Nome = (String) dr["Nome"];
                p.CPF = (String) (dr["CPF"] + "");
                p.CNPJ = (String) (dr["CNPJ"] + "");
                p.Email = (String) dr["Email"];
            } else {
                p = null;
            }

            return p;
        }

        /// <summary>
        /// Retorna Pessoas com certo nome.
        /// </summary>
        /// <param name="nome">Valor a ser usado pela clausula like.</param>
        /// <returns>Pessoas encontradas.</returns>
        public IList<Pessoa> Select(String nome) {
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Pessoa WHERE Nome LIKE @Nome";
            cmd.Parameters.AddWithValue("@Nome", "%" + nome + "%");

            IList<Pessoa> pessoas = new List<Pessoa>();
            NpgsqlDataReader dr = Conexao.Select(cmd);

            if (dr.HasRows) {
                while (dr.Read()) {
                    Pessoa p = new Pessoa();

                    p.ID = (int) dr["ID"];
                    p.Nome = (String) dr["Nome"];
                    p.CPF = (String) (dr["CPF"] + "");
                    p.CNPJ = (String) (dr["CNPJ"] + "");
                    p.Email = (String) dr["Email"];

                    pessoas.Add(p);
                }
            } else {
                pessoas = null;
            }

            return pessoas;
        }
    }
}
