using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Core
{
    public class QLWorkSheets
    {
        private readonly Dictionary<string, QLWorkSheet> __workSheets = new Dictionary<string,QLWorkSheet>();

        public QLWorkSheet Add()
        {
            return Add(NextName());
        }

        public QLWorkSheet Add(string _Name)
        {
            QLWorkSheet sheet = NewSheet();
            __workSheets.Add(_Name, sheet);
            return sheet;
        }

        private QLWorkSheet NewSheet()
        {
            return new QLWorkSheet();
        }

        private string NextName()
        {
            return String.Concat("Sheet", __workSheets.Keys.Count);
        }

    }
}
