using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argosy.Common.Attributes {
    public class DefaultSortAttribute : Attribute {
        public string PropertyName = null;
        public string Direction = null;

        public DefaultSortAttribute(string propertyName, string dir) {
            this.PropertyName = propertyName;
            this.Direction = dir;
        }
    }
}
