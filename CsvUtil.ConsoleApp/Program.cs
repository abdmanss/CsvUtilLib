using System;
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
            var resHeader = CsvUtilLib.CsvUtil.GetHeaderFromCsv($@"K:\Users\Ai\Downloads\جرد القمة.csv");
            var resAll = CsvUtilLib.CsvUtil.GetAllRowsFromCsv($@"K:\Users\Ai\Downloads\جرد القمة.csv");
            var resData = CsvUtilLib.CsvUtil.GetDataFromCsv($@"K:\Users\Ai\Downloads\جرد القمة.csv");
            var ms = resData.Select(v =>
            {
                var m = new CsvModel
                {
                    SN = v[0] != "" ? Convert.ToInt32(v[0]) : 0,
                    Code = v[1],
                    Parent = v[2],
                    Name = v[3],
                    Unit = v[4],
                    Qyantity = v[5] != "" ? Convert.ToDecimal(v[5]) : 0,
                    Cost = v[6] != "" ? Convert.ToDecimal(v[6]) : 0,
                    SalesPrice = v[7] != "" ? Convert.ToDecimal(v[7]) : 0,
                };
                return m;
            }).ToList();

            ms.ToString();

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
