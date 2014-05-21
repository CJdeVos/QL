using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Core
{
    public class Cell : ICell
    {

        internal Cell(WorkSheet sheet, Position position)
        {
            WorkSheet = sheet;
            Position = position;
        }


        protected WorkSheet WorkSheet { get; private set; }
        internal Position Position { get; private set; }


        protected bool? IsStored { get; private set; }
        protected DataCell DataCell { get; private set; }
        private void EnsureDataCell()
        {
            if (DataCell == null) // first run 
            {
                DataCell = WorkSheet.Data[Position];
                if (DataCell == null)
                {
                    DataCell = new DataCell();
                    IsStored = false;
                }
                else
                {
                    IsStored = true;
                }
            }
        }

        private void EnsureDataCellStored()
        {
            if (!IsStored.HasValue)
                EnsureDataCell();
            if (IsStored.Value == false)
            {
                WorkSheet.Data[Position] = DataCell;
            }
        }

        public object Value
        {
            get
            {
                EnsureDataCell();
                return DataCell.Value;
            }
            set
            {
                EnsureDataCellStored();
                DataCell.Value = value;
            }
        }

        public string Formula
        {
            get
            {
                EnsureDataCell();
                return DataCell.Formula;
            }
            set
            {
                EnsureDataCellStored();
                DataCell.Formula = value;
            }
        }
    }
}
