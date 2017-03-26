using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasebandProbe.Module.Impl
{
    class ModuleHomeNetworkEncryption : IModule
    {
        public ModuleHomeNetworkEncryption() : base("ModuleHomeNetworkEncryption")
        {
        }

        protected override string AssessModule()
        {
            var l = NetSHWlanEnumerate();
            foreach (string s in l)
            {
                var e = NetSHWlanSecurity(s);
                if (e.Equals("Open", StringComparison.OrdinalIgnoreCase))
                    return "has-open";
            }
            return "no-open";
        }

        public static List<string> NetSHWlanEnumerate()
        {
            var p = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "netsh",
                    Arguments = "wlan show profiles",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            p.Start();
            var s = p.StandardOutput.ReadToEnd();

            var spl = s.Split('\n');
            List<string> a = new List<string>();
            for (int i = 0; i < spl.Length - 9; i++)
            {
                int col = spl[i + 9].IndexOf(':');
                if (col == -1) break;
                a.Add(spl[i + 9].Substring(col + 1).Trim());
            }
            return a;
        }

        public static string NetSHWlanSecurity(string wlan)
        {
            var p = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "netsh",
                    Arguments = $"wlan show profiles \"{wlan}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            p.Start();

            var s = p.StandardOutput.ReadToEnd();
            var spl = s.Split('\n');

            return spl[27].Substring(spl[27].IndexOf(":") + 1).Trim();
        }
    }
}
