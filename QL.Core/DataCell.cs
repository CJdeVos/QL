using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Core
{
    public class DataCell : ICell
    {
        public object Value { get; set; }
        public string Formula { get; set; }
    }

}
