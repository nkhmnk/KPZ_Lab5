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

        // Тепер передаємо tagName в конструктор базового класу
        public LightTextNode(string tagName, string text) : base(tagName)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            OnTextRendered();
        }

        protected virtual void OnTextRendered() { }

        public override string OuterHTML => Text;
        public override string InnerHTML => Text;
    }

}