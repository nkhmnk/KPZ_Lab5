using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task5.Visitor;

namespace task5
{
    public class LightTextNode : LightNode
    {
        public string Text { get; }
        public string AdditionalText { get; }

        public LightTextNode(string text, string additionalText = "") : base("text")
        {
            Text = text;
            AdditionalText = additionalText;
        }

        public override string OuterHTML => $"<>{Text}{(string.IsNullOrEmpty(AdditionalText) ? "" : $" {AdditionalText}")}</>";

        public override string InnerHTML => Text + (string.IsNullOrEmpty(AdditionalText) ? "" : $" {AdditionalText}");

        public void Accept(IElementVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

}