using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Core
{
    public class Data
    {


        public Cell this[int row, int column]
        {
            get
            {
                return new Cell();
            }
        }

    }
}
