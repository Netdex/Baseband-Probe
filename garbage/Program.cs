using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using BasebandProbe.Category;
using BasebandProbe.Module;
using BasebandProbe.Module.Impl;
using BasebandProbe.Server;
using BasebandProbe.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace garbage
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoryInformation.LoadXML();
            ModuleInformation.LoadXML();

            var Modules = new IModule[]
            {
                new ModuleWindowsUpdateEnabled()
            };

            var ModuleResults = new ModuleResult[Modules.Length];

            for (int i = 0; i < Modules.Length; i++)
            {
                ModuleResults[i] = Modules[i].GetAssessmentResult();
            }

            JObject flast = new JObject();
            var CategoryResults = new CategoryResult[CategoryInformation.CategoryIDs.Count];
            for (int i = 0; i < CategoryResults.Length; i++)
            {
                CategoryResults[i] = ICategory.GetCategoryResult(CategoryInformation.CategoryIDs[i]);
            }
        
            var arr = new JArray();
            foreach (var i in ModuleResults)
            {
                arr.Add(JObject.FromObject(i));
            }
            flast["modules"] = arr;

            arr = new JArray();
            foreach (var i in CategoryResults)
            {
                arr.Add(JObject.FromObject(i));
            }
            flast["categories"] = arr;


            string code = Unescape(flast.ToString());

            WebServer ws = new WebServer(x =>
            {
                return code;
            }, "http://localhost:19247/data/");
            ws.Run();

            Console.ReadKey();
            ws.Stop();
        }

        static string Unescape(string s)
        {
            return s.Replace("\\r", "").Replace("\\n", "").Replace("\\t", "");
        }
    }
}
