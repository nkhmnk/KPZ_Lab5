using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class RemoveElementCommand : ICommand
    {
        private readonly LightElementNode parent;
        private readonly LightElementNode child;

        public RemoveElementCommand(LightElementNode parent, LightElementNode child)
        {
            this.parent = parent;
            this.child = child;
        }

        public void Execute()
        {
            parent.RemoveChild(child);
        }

        public void Undo()
        {
            parent.AddChild(child);
        }
    }
}
