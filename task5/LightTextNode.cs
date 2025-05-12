using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class LightTextNode : LightNode
    {
        public string Text { get; }
        public string AdditionalText { get; }

        // Конструктор класса
        public LightTextNode(string text, string additionalText = "") : base("text")
        {
            Text = text;
            AdditionalText = additionalText;
        }

        // Реализация абстрактного свойства OuterHTML
        public override string OuterHTML => $"<>{Text}{(string.IsNullOrEmpty(AdditionalText) ? "" : $" {AdditionalText}")}</>";

        // Реализация абстрактного свойства InnerHTML
        public override string InnerHTML => Text + (string.IsNullOrEmpty(AdditionalText) ? "" : $" {AdditionalText}");
    }

}