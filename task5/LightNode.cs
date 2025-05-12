using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public abstract class LightNode
    {
        public string TagName { get; }

        public abstract string OuterHTML { get; }
        public abstract string InnerHTML { get; }

        protected LightNode(string tagName)
        {
            TagName = tagName ?? throw new ArgumentNullException(nameof(tagName));
        }
    }
}
