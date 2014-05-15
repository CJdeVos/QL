using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Core
{
    public class WorkSheets
    {
        private readonly Dictionary<string, WorkSheet> __workSheets = new Dictionary<string, WorkSheet>();

        public WorkSheet Add()
        {
            return Add(NextName());
        }

        public WorkSheet Add(string _Name)
        {
            WorkSheet sheet = NewSheet();
            __workSheets.Add(_Name, sheet);
            return sheet;
        }

        private WorkSheet NewSheet()
        {
            return new WorkSheet();
        }

        private string NextName()
        {
            return String.Concat("Sheet", __workSheets.Keys.Count);
        }

    }
}
