using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL.Core
{
    public class Range : IEnumerator<object>
    {
        private Range(IEnumerable<Range> ranges)
        {
            Areas = new List<Range>(ranges);
        }

        private Range(Position start)
        {
            Start = start;
            End = start;
        }
        private Range(Position start, Position end)
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

        public readonly List<Range> Areas = null;
        private readonly Position Start, End;

        public bool IsContiguous
        {
            get
            {
                return Areas == null;
            }
        }

        public Range this[int row, int cell]
        {
            get
            {
                if(!IsContiguous)
                    return Areas.First()[row, cell];

                Position newPosition = Start + new Position(row, cell);
                if (newPosition > End)
                    throw new ArgumentOutOfRangeException("Range is not available in current range.");
                return new Range(newPosition);
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
                        ? Math.Abs(Start.Row - End.Row) * Math.Abs(Start.Cell - End.Cell)
                        : Areas.Sum(d => d.Count);
                }
                return __Count.Value;
            }
        }

        private object __Value = null;
        public object Value
        {
            get
            {
                // get first value
                if (__Value == null)
                {
                    __Value = IsContiguous
                        ? 10
                        : Areas.Count; //.Sum(d => d.Value);
                }
                return __Value;
            }
            set
            {
                __Value = value;
            }
        }

        //private void Iterate(Action<int,int> fn)
        //{
        //    for (int areaIndx = 0; areaIndx < Areas.Count; areaIndx++)
        //    {
        //        Area a = Areas[areaIndx];
        //        for (int rowIndx = a.Start.Row; rowIndx < (a.End.Row - a.Start.Row); rowIndx++)
        //        {
        //            for (int cellIndx = a.Start.Cell; cellIndx < (a.End.Cell - a.Start.Cell); cellIndx++)
        //            {
        //                // Act
        //                fn(rowIndx, cellIndx);
        //            }
        //        }
        //    }
        //}

        public object[] GetValues()
        {
            // return ALL values of ALL areas
            return new object[]{0};
        }

        private static char[] dotcommasplit = new char[] { ';' };
        public static Range FromString(string notation)
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
                        a = new Range(Position.FromString(poss[0]));
                    }
                    else
                    {
                        a = new Range(Position.FromString(poss[0]), Position.FromString(poss[1]));
                    }
                }
                else
                {
                    a = new Range(Position.FromString(sep));
                }
                if (isSingle)
                    return a;
                rs[i++] = a;
            }
            return new Range(rs);
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
