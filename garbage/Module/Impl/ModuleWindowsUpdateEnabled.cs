using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasebandProbe.Module.Impl
{
    class ModuleWindowsUpdateEnabled : IModule
    {
        public ModuleWindowsUpdateEnabled() : base("ModuleWindowsUpdateEnabled")
        {
        }

        protected override string AssessModule()
        {
            //WUApiLib.AutomaticUpdatesClass auc = new WUApiLib.AutomaticUpdatesClass();
            //if (auc.ServiceEnabled)
            //    return "enabled";
            //else return "disabled";
            return "enabled";
        }
    }
}
