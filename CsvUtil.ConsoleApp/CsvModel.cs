using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvUtil.ConsoleApp
{
    public class CsvModel
    {
        public int SN { get; set; }
        public string Code { get; set; }
        public string Parent { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal Qyantity { get; set; }
        public decimal Cost { get; set; }
        public decimal SalesPrice { get; set; }
    }
}
