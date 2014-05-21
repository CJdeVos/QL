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

        internal Data Data
        {
            get;
            private set;
        }

        public Range GetRange(string notation)
        {
            return Range.FromString(this, notation);
        }
    }
}

