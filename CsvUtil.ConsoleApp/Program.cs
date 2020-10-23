﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvUtil.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = CsvUtilLib.CsvUtil.FromCsv<CsvModel>($@"K:\Users\Ai\Downloads\جرد القمة.csv", (m, v) =>
            {
                m.SN = v[0] != "" ? Convert.ToInt32(v[0]) : 0;
                m.Code = v[1];
                m.Parent = v[2];
                m.Name = v[3];
                m.Unit = v[4];
                m.Qyantity = v[5] != "" ? Convert.ToDecimal(v[5]) : 0;
                m.Cost = v[6] != "" ? Convert.ToDecimal(v[6]) : 0;
                m.SalesPrice = v[7] != "" ? Convert.ToDecimal(v[7]) : 0;
            });
        }
    }
}
