using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace BasebandProbe.Module.Impl
{
    class ModuleSecurityPolicyScreenSaver : IModule
    {
        public ModuleSecurityPolicyScreenSaver() : base("ModuleSecurityPolicyScreenSaver")
        {
        }

        protected override string AssessModule()
        {
            int szScreenSaveActive = int.Parse((string)Registry.GetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop", "ScreenSaveActive", "0"));
            int szScreenSaverIsSecure = int.Parse((string)Registry.GetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop", "ScreenSaverIsSecure", "0"));
            int szScreenSaveTimeOut = int.Parse((string)Registry.GetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop", "ScreenSaveTimeOut", "0"));
            if (szScreenSaveActive == 1 && szScreenSaverIsSecure == 1)
            {
                if (szScreenSaveTimeOut < 30) return "screensaver-good";
                return "screensaver-long";
            }
            return "screensaver-none";
        }
    }
}
