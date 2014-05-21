using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Core
{
    public class DataCellNavigator
    {
        public DataCellNavigator(WorkSheet sheet, Position start, Position end)
        {
            Sheet = sheet;

            int yStart = Math.Min(start.Row, end.Row);
            int yEnd = Math.Abs(start.Row - end.Row) + yStart;

            int xStart = Math.Min(start.Column, end.Column);
            int xEnd = Math.Abs(start.Column - end.Column) + xStart;

            Start = new Position(yStart, xStart);
            End = new Position(yEnd, xEnd);
        }

        protected WorkSheet Sheet
        {
            get;
            private set;
        }

        protected Position Start
        {
            get;
            private set;
        }
        protected Position End
        {
            get;
            private set;
        }

        public IEnumerable<Cell> All()
        {
            for (int y = Start.Row; y <= End.Row; y++)
            {
                for (int x = Start.Column; x <= End.Column; x++)
                {
                    Current = new Cell(Sheet, new Position(y, x));
                    Console.WriteLine(Current.Position + ": " + (Current.Value ?? "null"));
                    yield return Current;
                    //act(data[y, x]);
                }
            }
        }

        public Cell Current
        {
            get;
            private set;
        }

    }
}
