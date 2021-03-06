﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvUtilLib
{
    public class CsvUtil
    {
        public static string[] GetHeaderFromCsv(string filename)
        {
            var csvText = File.ReadAllText(filename);
            var lines = csvText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var values = lines.Select(s => s.Split(',')).ToList();
            return values.FirstOrDefault();
        }

        public static List<string[]> GetDataFromCsv(string filename)
        {
            var csvText = File.ReadAllText(filename);
            var lines = csvText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var values = lines.Select(s => s.Split(',')).Skip(1).ToList();
            return values;
        }

        public static List<string[]> GetAllRowsFromCsv(string filename)
        {
            var csvText = File.ReadAllText(filename);
            var lines = csvText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var values = lines.Select(s => s.Split(',')).ToList();
            return values;
        }


        public static List<TModel> FromCsv<TModel>(string filename, Action<TModel, string[]> fit) where TModel : class, new()
        {
            var csvText = File.ReadAllText(filename);
            var lines = csvText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var values = lines.Select(s => s.Split(',')).ToList();
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
