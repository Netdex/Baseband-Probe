using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace BasebandProbe.Module.Impl
{
    class ModuleAutorunDisabled : IModule
    {
        public ModuleAutorunDisabled() : base("ModuleAutorunDisabled")
        {
        }

        protected override string AssessModule()
        {
            //string root = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\policies\Explorer\";
            //int val = (int) Registry.GetValue(root, "NoDriveTypeAutoRun", 0);
            //if (val != 0)
            //    return "autorun-on";
            /*else*/ return "autorun-off";
        }
    }
}
