using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Core
{
    public class Range : IEnumerator<object>
    {
        private Range(WorkSheet sheet)
        {
            Sheet = sheet;
        }

        private Range(WorkSheet sheet, IEnumerable<Range> ranges)
            : this(sheet)
        {
            Areas = new List<Range>(ranges);
        }

        private Range(WorkSheet sheet, Position start)
            : this(sheet)
        {
            Start = start;
            End = start;
        }
        private Range(WorkSheet sheet, Position start, Position end)
            : this(sheet)
        {
            if (start < end)
            {
                Start = start;
                End = end;
            }
            else
            {
                Start = end;
                End = Start;
            }
        }

        public WorkSheet Sheet
        {
            get;
            private set;
        }

        public readonly List<Range> Areas = null;
        private readonly Position Start, End;

        public bool IsContiguous
        {
            get
            {
                return Areas == null;
            }
        }

        public Range this[int row, int column]
        {
            get
            {
                if(!IsContiguous)
                    return Areas.First()[row, column];

                Position newPosition = Start + new Position(row, column);
                if (newPosition > End)
                    throw new ArgumentOutOfRangeException("Range is not available in current range.");
                return new Range(this.Sheet, newPosition);
            }
        }

        private int? __Count;
        public int Count
        {
            get
            {
                if (!__Count.HasValue)
                {
                    __Count = IsContiguous
                        ? Math.Abs(Start.Row - End.Row) * Math.Abs(Start.Column - End.Column)
                        : Areas.Sum(d => d.Count);
                }
                return __Count.Value;
            }
        }

        public object Value
        {
            get
            {
                return FirstCell().Value;
            }
            set
            {
                this.AllCells(cell => {
                    cell.Value = value; 
                }); 
            }
        }


        public string Formula
        {
            get
            {
                return this.FirstCell().Formula;
            }
            set
            {
                this.AllCells(cell => { 
                    cell.Formula = value; 
                });
            }
        }


        internal void AllCells(Action<Cell> act)
        {
            if (IsContiguous)
            {
                var data = this.Sheet.Data;

                int yStart = Math.Min(this.Start.Row, this.End.Row);
                int yEnd = Math.Abs(this.Start.Row - this.End.Row)+yStart;

                int xStart = Math.Min(this.Start.Column, this.End.Column);
                int xEnd = Math.Abs(this.Start.Column - this.End.Column)+xStart;

                for (int y = yStart; y <= yEnd; y++)
                {
                    for (int x = xStart; x <= xEnd; x++)
                    {
                        act(data[y, x]);
                    }
                }
            }
            else
                Areas.ForEach(rng => rng.AllCells(act));
        }

        internal Cell FirstCell()
        {
            if (IsContiguous) return this.Sheet.Data[this.Start.Row, this.Start.Column];
            return Areas.First().FirstCell();
        }

        internal Cell FirstCell(Action<Cell> act)
        {
            if (IsContiguous)
            {
                Cell cll = this.Sheet.Data[this.Start.Row, this.Start.Column];
                act(cll);
                return cll;
            }
            else
                return Areas.First().FirstCell(act);
        }

        public object[] GetValues()
        {
            object[] r = new object[this.Count];
            int cnt = 0;
            AllCells(cell=>{
                r[cnt++] = cell.Value;
            });
            return r;
        }

        private static readonly char[] dotcommasplit = new char[] { ';' };
        
        public static Range FromString(WorkSheet sheet, string notation)
        {
            string[] separates = notation.Split(dotcommasplit, StringSplitOptions.RemoveEmptyEntries);
            bool isSingle = separates.Length == 1;

            Range[] rs = new Range[separates.Length];
            int i = 0;
            foreach (string sep in separates)
            {
                Range a = null;
                if (sep.IndexOf(":") > 0)
                {
                    string[] poss = sep.Split(':');
                    if (poss.Length != 2)
                        throw new ArgumentOutOfRangeException(notation);

                    if (poss[0] == poss[1])
                    {
                        a = new Range(sheet, Position.FromString(poss[0]));
                    }
                    else
                    {
                        a = new Range(sheet, Position.FromString(poss[0]), Position.FromString(poss[1]));
                    }
                }
                else
                {
                    a = new Range(sheet, Position.FromString(sep));
                }
                if (isSingle)
                    return a;
                rs[i++] = a;
            }
            return new Range(sheet, rs);
        }

        public override string ToString()
        {
            return String.Join(";", Areas.Select(d=>
                d.Start == d.End
                    ? d.Start.ToString()
                    : String.Concat(d.Start, ":", d.End)));
        }




        #region IEnumerator<object> Members

        public object Current
        {
            get { 
                throw new NotImplementedException(); 
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEnumerator Members


        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
