using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            ModuleInformation.LoadXML();

            var mod = new ModuleWindowsUpdateEnabled();
            var res = mod.GetAssessmentResult();
            Console.WriteLine(Unescape(JsonConvert.SerializeObject(res)));

        }

        static string Unescape(string s)
        {
            return s.Replace("\\r", "\r").Replace("\\n", "\n").Replace("\\t", "\t");
        }
    }
}
