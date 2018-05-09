using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argosy.BusinessLogic.Services.Client.Entities {
    public class FilterExpression {
        public string Field { get; set; }
        public string Operator { get; set; }
        public object Value { get; set; }
        public string Logic { get; set; }
        public IEnumerable<FilterExpression> Filters { get; set; }
    }
}
