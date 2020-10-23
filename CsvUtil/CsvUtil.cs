using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvUtilLib
{
    public class CsvUtil
    {
        public static List<TModel> FromCsv<TModel>(string filename, Action<TModel, string[]> fit) where TModel : class, new()
        {
            var csvText = File.ReadAllText(filename);
            var lines = csvText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var values = lines.Select(s =>
            {
                var vs = s.Split(',');
                return vs;
            }).ToList();
            var items = values.Select(s =>
            {
                var m = new TModel();
                if (s != values.First())
                    fit(m, s);
                return m;
            }).ToList();
            return items;
        }
    }
}
