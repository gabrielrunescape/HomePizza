using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model {
    class Login : Pessoa {
        public int ID { get; set; }
        public String UserName { get; set; }
        public String PassWord { get; set; }
        public DateTime DataCriacao { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
