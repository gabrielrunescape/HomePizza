using System;
using Negocio.DAO;
using System.Linq;
using System.Text;
using Negocio.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Negocio.Controller {
    public class PessoaController {
        public void Gravar(Pessoa pessoa) {
            PessoaDAO dao = new PessoaDAO();

            if (pessoa.ID != 0) {
                dao.Update(pessoa);
            } else {
                dao.Insert(pessoa);
            }
        }

        public void Apagar(Pessoa pessoa) {
            PessoaDAO dao = new PessoaDAO();

            dao.Delete(pessoa);
        }
    }
}
