using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace BasebandProbe.Module.Impl
{
    class ModuleAntivirusInstalled : IModule
    {
        public ModuleAntivirusInstalled() : base("ModuleAntivirusInstalled")
        {
        }

        protected override string AssessModule()
        {
            if (AntivirusInstalled())
                return "antivirus-activated";
            else return "no-antivirus";
        }

        public static bool AntivirusInstalled()
        {

            string wmipathstr = @"\\" + Environment.MachineName + @"\root\SecurityCenter2";
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmipathstr, "SELECT * FROM AntiVirusProduct");
                ManagementObjectCollection instances = searcher.Get();
                return instances.Count > 0;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }

    }
}
