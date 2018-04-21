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
    public class CEPObjectDAO {
        /// <summary>
        /// Insere um endereço com CEP no banco de dados.
        /// </summary>
        /// <param name="cep">Valores a serem inseridos.</param>
        public void Insert(CEPObject cep) {
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO CEP (CEP, Logradouro, Complemento, Bairro, Cidade, UF) VALUES (CEP = @CEP, Logradouro = @Logradouro, Complemento = @Complemento, Bairro = @Bairro, Cidade = @Cidade, UF = @UF)";

            cmd.Parameters.AddWithValue("@CEP", cep.CEP.Replace(".", "").Replace("-", ""));
            cmd.Parameters.AddWithValue("@Logradouro", cep.Logradouro);
            cmd.Parameters.AddWithValue("@Complemento", cep.Complemento);
            cmd.Parameters.AddWithValue("@Bairro", cep.Bairro);
            cmd.Parameters.AddWithValue("@Cidade", cep.Cidade);
            cmd.Parameters.AddWithValue("@UF", cep.UF);

            Conexao.CRUD(cmd);
        }

        /// <summary>
        /// Altera um endereço de CEP existente no banco de dados.
        /// </summary>
        /// <param name="cep">Valores a serem alterados.</param>
        public void Update(CEPObject cep) {
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE CEP SET CEP = @CEP, Logradouro = @Logradouro, Complemento = @Complemento, Bairro = @Bairro, Cidade = @Cidade, UF = @UF WHERE ID = @ID";
            
            cmd.Parameters.AddWithValue("@ID", cep.ID);
            cmd.Parameters.AddWithValue("@CEP", cep.CEP.Replace(".", "").Replace("-", ""));
            cmd.Parameters.AddWithValue("@Logradouro", cep.Logradouro);
            cmd.Parameters.AddWithValue("@Complemento", cep.Complemento);
            cmd.Parameters.AddWithValue("@Bairro", cep.Bairro);
            cmd.Parameters.AddWithValue("@Cidade", cep.Cidade);
            cmd.Parameters.AddWithValue("@UF", cep.UF);

            Conexao.CRUD(cmd);
        }

        /// <summary>
        /// Apaga um endereço de CEP existente.
        /// </summary>
        /// <param name="cep">CEP a ser apagado.</param>
        public void Delete(CEPObject cep) {
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM CEP WHERE ID = @ID";

            cmd.Parameters.AddWithValue("@ID", cep.ID);

            Conexao.CRUD(cmd);
        }

        /// <summary>
        /// Obtém um endereço de CEP do banco de dados.
        /// </summary>
        /// <param name="id">Código identificador do CEP.</param>
        /// <returns>Endereço de CEP encontrado.</returns>
        public CEPObject Select(int id) {
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM CEP WHERE ID = @ID";

            CEPObject c = new CEPObject();
            cmd.Parameters.AddWithValue("@ID", id);
            NpgsqlDataReader dr = Conexao.Select(cmd);

            if (dr.HasRows) {
                dr.Read();

                c.ID = id;
                c.CEP = ((long) dr["CEP"]) + "";
                c.Logradouro = (String) dr["Logradouro"];
                
                if (dr["Complemento"] == DBNull.Value) {
                    c.Complemento = "";
                } else {
                    c.Complemento = (String) dr["Complemento"];
                }

                c.Bairro = (String) dr["Bairro"];
                c.Cidade = (String) dr["Cidade"];
                c.UF = (String) dr["UF"];
            } else {
                c = null;
            }

            return c;
        }

        /// <summary>
        /// Obtém um endereço de CEP do banco de dados.
        /// </summary>
        /// <param name="id">Código de Endereço Postal.</param>
        /// <returns>Endereço de CEP encontrado.</returns>
        public CEPObject Select(long cep) {
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM CEP WHERE CEP = @CEP";

            CEPObject c = new CEPObject();
            cmd.Parameters.AddWithValue("@CEP", cep);
            NpgsqlDataReader dr = Conexao.Select(cmd);

            if (dr.HasRows) {
                dr.Read();

                c.ID = (int) dr["ID"];
                c.CEP = ((long) dr["CEP"]) + "";
                c.Logradouro = (String) dr["Logradouro"];

                if (dr["Complemento"] == DBNull.Value) {
                    c.Complemento = "";
                } else {
                    c.Complemento = (String)dr["Complemento"];
                }

                c.Bairro = (String) dr["Bairro"];
                c.Cidade = (String) dr["Cidade"];
                c.UF = (String) dr["UF"];
            } else {
                c = null;
            }

            return c;
        }

        /// <summary>
        /// Retorna todos os valores da Tabela CEP.
        /// </summary>
        /// <returns>RowsItens da tabela</returns>
        public IList<CEPObject> Select() {
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM CEP";

            IList<CEPObject> cep = new List<CEPObject>();
            NpgsqlDataReader dr = Conexao.Select(cmd);

            if (dr.HasRows) {
                while (dr.Read()) {
                    CEPObject c = new CEPObject();

                    c.ID = (int) dr["ID"];
                    c.CEP = ((long) dr["CEP"]) + "";
                    c.Logradouro = (String) dr["Logradouro"];

                    if (dr["Complemento"] == DBNull.Value) {
                        c.Complemento = "";
                    } else {
                        c.Complemento = (String)dr["Complemento"];
                    }

                    c.Bairro = (String) dr["Bairro"];
                    c.Cidade = (String) dr["Cidade"];
                    c.UF = (String) dr["UF"];

                    cep.Add(c);
                }
            } else {
                cep = null;
            }

            return cep;
        }
    }
}
