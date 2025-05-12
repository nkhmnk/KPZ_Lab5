using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class AddElementCommand : ICommand
    {
        private readonly LightElementNode parent;
        private readonly LightElementNode child;

        public AddElementCommand(LightElementNode parent, LightElementNode child)
        {
            this.parent = parent;
            this.child = child;
        }

        public void Execute()
        {
            parent.AddChild(child);
        }

        public void Undo()
        {
            parent.RemoveChild(child);
        }
    }
}
