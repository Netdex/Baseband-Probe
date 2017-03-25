using System;
using System.Xml;

namespace BasebandProbe.Module
{
    public abstract class IModule
    {
        public string ModuleName { get; set; }

        protected IModule(string moduleName)
        {
            ModuleName = moduleName;
        }

        public ModuleResult GetAssessmentResult()
        {
            var node = ModuleInformation.GetModuleXMLNode(ModuleName);
            var assessment = AssessModule();
            var nextStepsText = node.SelectSingleNode($"./NextSteps/Step[@result='{assessment}']");
            var detailsText = node.SelectSingleNode("./Details");
            var moduleNameText = node.Attributes["name"];
            var priorityText = node.SelectSingleNode("./Priority");
            var scoreText = nextStepsText.Attributes["score"];

            if (nextStepsText == null || detailsText == null || moduleNameText == null || priorityText == null || scoreText == null)
                throw new XmlException("XML module definition is malformed");

            return new ModuleResult()
            {
                Details = detailsText.InnerText.Trim(),
                Name = moduleNameText.InnerText.Trim(),
                NextSteps = nextStepsText.InnerText.Trim(),
                Priority = int.Parse(priorityText.InnerText.Trim()),
                Assessment = assessment,
                Score = decimal.Parse(scoreText.InnerText.Trim())
            };
        }

        protected abstract string AssessModule();
    }
}
