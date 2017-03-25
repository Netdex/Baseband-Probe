using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasebandProbe.Category;
using BasebandProbe.Module;
using BasebandProbe.Module.Impl;
using BasebandProbe.Utility;
using Newtonsoft.Json;

namespace garbage
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoryInformation.LoadXML();
            ModuleInformation.LoadXML();

            var mod = new ModuleWindowsUpdateEnabled();
            var res = mod.GetAssessmentResult();
            Console.WriteLine(Unescape(JsonConvert.SerializeObject(res)));

            var lmd = ICategory.GetCategoryResult("CategoryVulnerablePlugins");
            Console.WriteLine(Unescape(JsonConvert.SerializeObject(lmd)));
        }

        static string Unescape(string s)
        {
            return s.Replace("\\r", "\r").Replace("\\n", "\n").Replace("\\t", "\t");
        }
    }
}
