using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasebandProbe.Module
{
    public class IModuleResult
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public string Assessment { get; set; }
        public int Priority { get; set; }
        public decimal Score { get; set; }
        public string NextSteps { get; set; }
        public string Category { get; set; }
    }
}
