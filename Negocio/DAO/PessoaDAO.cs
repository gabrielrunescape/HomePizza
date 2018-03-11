using Npgsql;
using System;
using System.Data;
using System.Linq;
using System.Text;
using Negocio.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Negocio.DAO {
    public class PessoaDAO {
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

        public void Delete(Pessoa pessoa) {
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM Pessoa WHERE ID = @ID";

            cmd.Parameters.AddWithValue("@ID", pessoa.ID);

            Conexao.CRUD(cmd);
        }

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
                p.CPF = (long) dr["CPF"];
                p.CNPJ = (long) dr["CNPJ"];
                p.Email = (String) dr["Email"];
            } else {
                p = null;
            }

            return p;
        }

        public IList<Pessoa> Select(String nome) {
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Pessoa LIKE Nome = @Nome";

            IList<Pessoa> pessoas = new List<Pessoa>();
            cmd.Parameters.AddWithValue("@Nome", "%" + nome + "%");
            NpgsqlDataReader dr = Conexao.Select(cmd);

            if (dr.HasRows) {
                while (dr.Read()) {
                    Pessoa p = new Pessoa();

                    p.ID = (int) dr["ID"];
                    p.Nome = (String) dr["Nome"];
                    p.CPF = (long) dr["CPF"];
                    p.CNPJ = (long) dr["CNPJ"];
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
