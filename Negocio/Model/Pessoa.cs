using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model {
    public class Pessoa {
        public int ID { get; set; }
        public String Nome { get; set; }
        public long CPF { get; set; }
        public long CNPJ { get; set; }
        public String Email { get; set; }
    }
}
