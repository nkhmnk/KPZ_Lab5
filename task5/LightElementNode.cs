﻿using System.Collections.Generic;
using System;
using System.Text;
using System.Linq;


namespace task5
{
    public class LightElementNode : LightNode
    {
        private readonly List<LightNode> children;
        private readonly HashSet<string> cssClasses;

        public string TagName { get; }
        public DisplayType Display { get; }
        public ClosingType Closing { get; }
        public IReadOnlyCollection<string> CssClasses => cssClasses;
        public int ChildCount => children.Count;

        public LightElementNode(string tagName, DisplayType display = DisplayType.Block, ClosingType closing = ClosingType.Normal)
        {
            TagName = tagName ?? throw new ArgumentNullException(nameof(tagName));
            Display = display;
            Closing = closing;
            children = new List<LightNode>();
            cssClasses = new HashSet<string>();
        }

        public void AddChild(LightNode child)
        {
            children.Add(child ?? throw new ArgumentNullException(nameof(child)));
        }

        public void AddCssClass(string cssClass)
        {
            if (string.IsNullOrWhiteSpace(cssClass))
                throw new ArgumentException("CSS клас не може бути порожнім", nameof(cssClass));
            cssClasses.Add(cssClass);
        }

        public override string OuterHTML => GenerateHTML(0);
        public override string InnerHTML => GenerateHTML(0, innerOnly: true);

        private string GenerateHTML(int indentLevel, bool innerOnly = false)
        {
            var sb = new StringBuilder();
            string indent = new string(' ', indentLevel * 2);

            if (!innerOnly)
            {
                sb.Append(indent).Append('<').Append(TagName);

                if (cssClasses.Any())
                {
                    sb.Append(" class=\"")
                      .Append(string.Join(" ", cssClasses))
                      .Append('"');
                }

                if (Closing == ClosingType.SelfClosing)
                {
                    sb.AppendLine(" />");
                    return sb.ToString();
                }

                sb.AppendLine(">");
            }

            foreach (var child in children)
            {
                if (child is LightTextNode)
                {
                    sb.Append(indent).Append("  ").AppendLine(child.OuterHTML);
                }
                else
                {
                    sb.Append(((LightElementNode)child).GenerateHTML(indentLevel + 1));
                }
            }

            if (!innerOnly && Closing == ClosingType.Normal)
            {
                sb.Append(indent).Append("</").Append(TagName).AppendLine(">");
            }

            return sb.ToString();
        }
    }
}