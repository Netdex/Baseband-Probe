﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasebandProbe.Category
{
    public class ICategory
    {
        public static ICategoryResult GetCategoryResult(string categoryID)
        {
            var cat = CategoryInformation.GetCategoryXMLNode(categoryID);
            if (cat == null)
                throw new ArgumentException("Category does not exist!");
            var nameNode = cat.SelectSingleNode("./Name");
            var idNode = cat.Attributes["name"];
            return new ICategoryResult()
            {
                Name = nameNode.InnerText,
                CategoryID = idNode.InnerText
            };
        }
    }
}
