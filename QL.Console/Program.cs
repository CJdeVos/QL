﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using QL.Core;

namespace QL.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Position pos = Position.FromString("Z78");
            Console.WriteLine("({0}, {1}): {2}", pos.Row, pos.Cell, pos.ToString());

            //Area a1 = new Area("B2", "B1");
            //Area b1 = new Area("J2", "I1");
            //Range r1 = a1 + b1;
            Range r2 = Range.FromString("A1:C3;A4:L9;JJ7;"); // +"K9:H3";
            //Console.WriteLine(r2[1, 1].Value);
            Console.WriteLine(r2[1, 1].Value);
            r2[1, 1].Value = 8;
            Console.WriteLine(r2[1, 1].Value);
            //object[] o = r2.GetValues();
            Console.WriteLine(r2.ToString());

            /*QLWorkBook wb = QLWorkBook.Create();
            QLWorkSheet sheet1 = wb.WorkSheets.Add("Sheet1");
            sheet1.GetRange("A1:A6").Value = 10;
            sheet1.GetRange("A2,A5").Value = 20;
            sheet1.Cells[1, 1].Value = 30;*/



            Console.WriteLine("-- enter to exit --");
            Console.ReadLine();
        }
    }
}
