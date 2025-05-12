using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5._6__HtmlMemento
{
    public class HtmlMemento
    {
        public string HtmlSnapshot { get; }

        public HtmlMemento(string html)
        {
            HtmlSnapshot = html ?? throw new ArgumentNullException(nameof(html));
        }
    }
}
