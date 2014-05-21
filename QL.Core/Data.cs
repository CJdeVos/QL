using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Core
{
    internal class Data
    {
        private readonly Dictionary<Position, DataCell> _allCells = new Dictionary<Position, DataCell>();

        internal DataCell this[Position position]
        {
            get
            {
                if (_allCells.ContainsKey(position))
                    return _allCells[position];
                return null;
            }
            set
            {
                _allCells[position] = value;
            }
        }
    }
}
