using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace BasebandProbe.Module.Impl
{
    class ModuleUACEnabled : IModule
    {
        public ModuleUACEnabled() : base("ModuleUACEnabled")
        {
        }

        protected override string AssessModule()
        {
            string root = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System";
            int[] map = { 0, 5, 4, 3, 2, 1 };
            int dwConsentPromptBehaviorAdmin = (int)Registry.GetValue(root, "ConsentPromptBehaviorAdmin", 0); // 5
            int dwValidateAdminCodeSignatures = (int)Registry.GetValue(root, "ValidateAdminCodeSignatures", 0); // 1
            int dwEnableSecureUIAPaths = (int)Registry.GetValue(root, "EnableSecureUIAPaths", 0); // 1
            int dwEnableLUA = (int)Registry.GetValue(root, "EnableLUA", 0); // 1
            int dwPromptOnSecureDesktop = (int)Registry.GetValue(root, "PromptOnSecureDesktop", 0); // 1
            int dwEnableVirtualization = (int)Registry.GetValue(root, "EnableVirtualization", 0); // 1

            int sum = map[dwConsentPromptBehaviorAdmin] + dwValidateAdminCodeSignatures + dwEnableSecureUIAPaths +
                      dwEnableLUA + dwPromptOnSecureDesktop + dwEnableVirtualization;
            double f = 1.0 * sum / (5 + 1 + 1 + 1 + 1 + 1);
            if (f > 0.66)
            {
                return "always-notify";
            }
            else if (f > 0.33)
            {
                return "sometimes-notify";
            }
            else
            {
                return "never-notify";
            }
        }
    }
}
