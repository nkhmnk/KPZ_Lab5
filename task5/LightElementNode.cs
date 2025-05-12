using System.Collections.Generic;
using System;
using System.Text;
using System.Linq;


namespace task5
{
    public class LightElementNode : LightNode, ILightNodeEnumerable
    {
        private readonly List<LightNode> children;
        private readonly HashSet<string> cssClasses;

        protected virtual void OnCreated() { }
        protected virtual void OnInserted(LightNode child) { }
        protected virtual void OnRemoved(LightNode child) { }
        protected virtual void OnStylesApplied() { }
        protected virtual void OnClassListApplied() { }
        protected virtual void OnTextRendered() { }


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

            OnCreated();
        }

        public void AddChild(LightNode child)
        {
            children.Add(child ?? throw new ArgumentNullException(nameof(child)));
            OnInserted(child);
        }

        public void AddCssClass(string cssClass)
        {
            if (string.IsNullOrWhiteSpace(cssClass))
                throw new ArgumentException("CSS клас не може бути порожнім", nameof(cssClass));
            cssClasses.Add(cssClass);


            OnClassListApplied();
            OnStylesApplied();
        }

        // Додано метод для видалення CSS класу
        public void RemoveCssClass(string cssClass)
        {
            if (string.IsNullOrWhiteSpace(cssClass))
                throw new ArgumentException("CSS клас не може бути порожнім", nameof(cssClass));
            cssClasses.Remove(cssClass);
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

        public void RemoveChild(LightNode child)
        {
            if (child == null) throw new ArgumentNullException(nameof(child));

            if (children.Remove(child))
            {
                OnRemoved(child);
            }
        }


        public IEnumerable<LightNode> EnumerateDepthFirst()
        {
            yield return this;

            foreach (var child in children)
            {
                if (child is LightElementNode element)
                {
                    foreach (var nested in element.EnumerateDepthFirst())
                        yield return nested;
                }
                else
                {
                    yield return child;
                }
            }
        }

        public IEnumerable<LightNode> EnumerateBreadthFirst()
        {
            var queue = new Queue<LightNode>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                yield return current;

                if (current is LightElementNode element)
                {
                    foreach (var child in element.children)
                    {
                        queue.Enqueue(child);
                    }
                }
            }
        }
        public void SetCssClasses(IEnumerable<string> classes)
        {
            cssClasses.Clear();
            foreach (var cls in classes)
            {
                if (!string.IsNullOrWhiteSpace(cls))
                    cssClasses.Add(cls);
            }
        }

    }
}