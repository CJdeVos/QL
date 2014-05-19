using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Core
{
    public class Data
    {
        private Dictionary<int, Cell> allCells = new Dictionary<int, Cell>();

        public Cell this[Position position]
        {
            get
            {
                Cell cll = null;
                int hshcd = position.GetHashCode();
                if(!allCells.ContainsKey(hshcd)) {
                    cll = new Cell();
                    allCells.Add(hshcd, cll);
                }
                return allCells[hshcd];
            }
        }

        public Cell this[int row, int column]
        {
            get
            {
                return this[new Position(row, column)];
            }
        }

    }
}
