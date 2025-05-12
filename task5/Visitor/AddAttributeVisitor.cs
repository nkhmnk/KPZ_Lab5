using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5.Visitor
{
    public class AddAttributeVisitor : IElementVisitor
    {
        private readonly string _attributeName;
        private readonly string _attributeValue;

        public AddAttributeVisitor(string attributeName, string attributeValue)
        {
            _attributeName = attributeName;
            _attributeValue = attributeValue;
        }

        public void Visit(LightElementNode element)
        {
            // Додаємо атрибут до елемента
            element.AddCssClass($"{_attributeName}=\"{_attributeValue}\"");
        }

        public void Visit(LightTextNode textNode)
        {
        }
    }

}
