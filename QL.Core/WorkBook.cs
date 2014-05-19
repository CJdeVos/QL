using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Core
{
    public class WorkBook
    {
        private readonly WorkSheets __sheets = new WorkSheets();

        public WorkSheets WorkSheets
        {
            get
            {
                return __sheets;
            }
        }


        public static WorkBook Create()
        {
            return new WorkBook();
        }
    }
}
