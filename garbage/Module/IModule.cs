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

        public IModuleResult GetAssessmentResult()
        {
            var node = ModuleInformation.GetModuleXMLNode(ModuleName);
            var assessment = AssessModule();
            var nextStepsText = node.SelectSingleNode($"./NextSteps/Step[@result='{assessment}']");
            var detailsText = node.SelectSingleNode("./Details");
            var moduleNameText = node.SelectSingleNode("./Name");
            var priorityText = node.SelectSingleNode("./Priority");
            var scoreText = nextStepsText.Attributes["score"];
            var categoryText = node.SelectSingleNode("./Category");
            
            if (nextStepsText == null || detailsText == null || moduleNameText == null || priorityText == null || scoreText == null)
                throw new XmlException("XML module definition is malformed");

            return new IModuleResult()
            {
                Details = detailsText.InnerXml.Trim(),
                Name = moduleNameText.InnerXml.Trim(),
                NextSteps = nextStepsText.InnerXml.Trim(),
                Priority = int.Parse(priorityText.InnerXml.Trim()),
                Assessment = assessment,
                Score = decimal.Parse(scoreText.InnerXml.Trim()),
                Category = categoryText?.InnerXml
            };
        }

        protected abstract string AssessModule();
    }
}
