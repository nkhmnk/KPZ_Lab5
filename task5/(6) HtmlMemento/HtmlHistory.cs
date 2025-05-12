using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5._6__HtmlMemento
{
    public class HtmlHistory
    {
        private readonly Stack<HtmlMemento> history = new Stack<HtmlMemento>();

        public void Save(HtmlMemento memento)
        {
            history.Push(memento);
        }

        public HtmlMemento Undo()
        {
            if (history.Count == 0)
                return null; // Зробіть окрему перевірку перед викликом
            return history.Pop();
        }

        public bool CanUndo
        {
            get { return history.Count > 0; }
        }
    }
}
