using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Core
{
    public class QLWorkSheetRange
    {
        internal QLWorkSheetRange()
        {
        }

        public Range this[string cell1, string cell2]
        {
            get
            {
                Console.WriteLine(cell1);
                throw new NotImplementedException();
            }
        }
    }
}
