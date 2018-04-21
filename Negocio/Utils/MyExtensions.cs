using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Negocio.Utils {
    public static class MyExtensions {
        public static Object DefaultDbNull<T>(this Object value, object defaultValue) {
            if(value == Convert.DBNull ) {
                return (T) defaultValue;
            }

            return (T) value;
	    }
    }
}
