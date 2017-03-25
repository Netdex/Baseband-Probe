using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BasebandProbe.Category
{
    class CategoryInformation
    {
        public static XmlNode RootNode { get; set; }

        public static void LoadXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.Categories);
            RootNode = doc.DocumentElement;
        }
        public static XmlNode GetCategoryXMLNode(string categoryName)
        {
            var node = RootNode.SelectSingleNode($"./Category[@name='{categoryName}']");
            if (node == null)
                throw new ArgumentException("Category does not exist!");
            return node;
        }
    }
}
