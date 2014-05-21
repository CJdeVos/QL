using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace QL.Core
{
    public struct Position
    {
        private const bool IsZeroBased = false;
        private const int Modifier = IsZeroBased ? -1 : 0;

        public Position(int row, int column)
            : this()
        {
            this.Row = row;
            this.Column = column;
        }

        public int Row
        {
            get;
            set;
        }

        public int Column
        {
            get;
            set;
        }

        public override string ToString()
        {
            string s = "";
            var v = Column - Modifier;
            var vlast = (v % 26);

            while (vlast > 0)
            {
                s = String.Concat((char)(vlast - 1 + 65), s);
                v /= 26;
                vlast = (v % 26);
            }
            return String.Concat(s, Row - Modifier);
        }

        public static Position FromString(string notation)
        {
            CharEnumerator ce = notation.GetEnumerator();
            ce.MoveNext();

            // COLUMN
            int column = 0;
            int rcChar = ce.Current.GetCharIndex();
            if (rcChar == -1)
                throw new ArgumentOutOfRangeException("rcNotation", "rcNotation must start with a character.");

            while (rcChar > -1)
            {
                column *= 26;
                column += (rcChar + 1);
                if (!ce.MoveNext())
                    throw new ArgumentOutOfRangeException("rcNotation", "rcNotation missing number.");
                rcChar = ce.Current.GetCharIndex();
            }

            // ROW
            int row = 0;
            rcChar = ce.Current.GetIntIndex();
            if (rcChar <= 0)
                throw new ArgumentOutOfRangeException("rcNotation", "rcNotation must have a number.");

            while (rcChar > -1)
            {
                row *= 10;
                if (rcChar > 0)
                    row += rcChar;
                if (!ce.MoveNext())
                    break;
                rcChar = ce.Current.GetIntIndex();
            }

            return new Position(row + Modifier, column + Modifier);
        }

        public static Position operator +(Position p1, Position p2)
        {
            return new Position(p1.Row + p2.Row, p1.Column + p2.Column);
        }

        public static bool operator <(Position p1, Position p2)
        {
            return p1.Row <= p2.Row && p1.Column <= p2.Column;
        }

        public static bool operator >(Position p1, Position p2)
        {
            return p1.Row >= p2.Row && p1.Column >= p2.Column;
        }

        public static bool operator ==(Position p1, Position p2)
        {
            return p1.Row == p2.Row && p1.Column == p2.Column;
        }

        public static bool operator !=(Position p1, Position p2)
        {
            return p1.Row != p2.Row || p1.Column != p2.Column;
        }

        public override int GetHashCode()
        {
            return (Row * 16556) + Column;
        }

        public override bool Equals(object obj)
        {
            if(!(obj is Position))
                return false;

            return this == (Position)obj;
        }

    }
}
