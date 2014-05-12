using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Core
{
    public class QLWorkSheet
    {
        internal QLWorkSheet()
        {
        }


        /*public Range Cells
        {
            get
            {
                return new Range();
            }
        }*/

        public Range GetRange(string selector)
        {
            return Range.FromString(selector);
            // parse selector to return range
            //return new Range();
        }
    }
}
