using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BasebandProbe.Module
{
    class ModuleInformation
    {
        public static XmlNode RootNode { get; set; }

        public static void LoadXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.Modules);
            RootNode = doc.DocumentElement;
        }
        public static XmlNode GetModuleXMLNode(string moduleName)
        {
            var node = RootNode.SelectSingleNode($"./Module[@name='{moduleName}']");
            if(node == null)
                throw new ArgumentException("Module does not exist!");
            return node;
        }
    }
}
