using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Core
{
    public class WorkSheet
    {
        internal WorkSheet()
        {
            Data = new Data();
        }


        /*public Range Cells
        {
            get
            {
                return new Range();
            }
        }*/

        internal Data Data
        {
            get;
            private set;
        }

        public Range GetRange(string selector)
        {
            return Range.FromString(this, selector);
            // parse selector to return range
            //return new Range();
        }
    }
}
