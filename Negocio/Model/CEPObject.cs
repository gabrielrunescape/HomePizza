using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model {
    public class CEPObject {
        private String cep;

        public int ID { get; set; }

        public String CEP {
            get {
                if (!String.IsNullOrWhiteSpace(cep)) {
                    String mask = @"{0:00\.###\-###}";

                    String f = String.Format(mask, long.Parse(cep));
                    return f;
                } else {
                    return null;
                }
            }
            set {
                cep = value;
                cep.Replace(".", "").Replace("-", "");
            }
        }

        public String Logradouro { get; set; }
        public String Complemento { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }
        public String UF { get; set; }

        public override String ToString() {
            return CEP;
        }
    }
}
