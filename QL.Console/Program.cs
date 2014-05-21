using System;
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
            WorkBook b = new WorkBook();
            var sheet1 = b.WorkSheets.Add("Sheet1");
            Range sr1 = sheet1.GetRange("A1:K4");
            sr1.Value = 90;
            Range sr2 = sheet1.GetRange("A2");
            sr2.Value = 190;
            Console.WriteLine(sr1.Value);
            Console.WriteLine(sr2.Value);

            Range sr3 = sheet1.GetRange("A1:K9");
            object v = sr3.GetValues();
            Console.WriteLine(String.Join(", ", sr3.GetValues().Select(d => (d ?? "null").ToString())));

            Range srFrmula = sheet1.GetRange("E9");
            srFrmula.Formula = "= A1 * 2";


            Position pos = Position.FromString("Z78");
            Console.WriteLine("({0}, {1}): {2}", pos.Row, pos.Column, pos.ToString());

            //Area a1 = new Area("B2", "B1");
            //Area b1 = new Area("J2", "I1");
            //Range r1 = a1 + b1;
            
            
            //Range r2 = Range.FromString("A1:C3;A4:L9;JJ7;"); // +"K9:H3";
            //Console.WriteLine(r2.Value);
            ////Console.WriteLine(r2[1, 1].Value);
            //Console.WriteLine(r2[1, 1].Value);
            //r2[1, 1].Value = 8;
            //Console.WriteLine(r2[1, 1].Value);
            ////object[] o = r2.GetValues();
            //Console.WriteLine(r2.ToString());

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
