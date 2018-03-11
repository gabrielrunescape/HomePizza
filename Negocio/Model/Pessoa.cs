using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model {
    /// <summary>
    /// Atributos da classe Pessoa.
    /// </summary>
    public class Pessoa {
        private String cpf;
        private String cnpj;

        /// <summary>
        /// Código identificador da Pessoa.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Nome da Pessoa.
        /// </summary>
        public String Nome { get; set; }

        /// <summary>
        /// CPF da Pessoa. Diferente do banco de dados,
        /// A String permite trabalhar melhor a manipulação
        /// De informações para melhor visualização.
        /// </summary>
        public String CPF {
            get {
                if (!String.IsNullOrWhiteSpace(cpf)) {
                    String mask = @"{0:000\.###\.###\-##}";

                    String f = String.Format(mask, long.Parse(cpf));
                    return f;
                } else {
                    return null;
                }
            } set {
                cpf = value;
                cpf.Replace(".", "").Replace("-", "").Replace("/", "");
            }
        }

        /// <summary>
        /// CNPJ da Pessoa. Diferente do banco de dados,
        /// A String permite trabalhar melhor a manipulação
        /// De informações para melhor visualização.
        /// </summary>
        public String CNPJ {
            get {
                if (!String.IsNullOrWhiteSpace(cnpj)) {
                    String mask = @"{0:00\.###\.###\/####\-##}";

                    return String.Format(mask, long.Parse(cnpj));
                } else {
                    return null;
                }
            }
            set {
                cnpj = value;
                cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            }
        }
        
        /// <summary>
        /// Correio Eletrônico da Pessoa.
        /// </summary>
        public String Email { get; set; }
    }
}
