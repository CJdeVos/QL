using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Core
{
    public class QLWorkBook
    {
        private readonly QLWorkSheets __sheets = new QLWorkSheets();

        public QLWorkSheets WorkSheets
        {
            get
            {
                return __sheets;
            }
        }


        public static QLWorkBook Create()
        {
            return new QLWorkBook();
        }
    }
}
