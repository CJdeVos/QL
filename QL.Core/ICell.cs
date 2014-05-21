using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Core
{
    public interface ICell
    {
        object Value { get; set; }
        string Formula { get; set; }
    }

}
