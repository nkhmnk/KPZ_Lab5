using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class DebugElementNode : LightElementNode
    {
        public DebugElementNode(string tag) : base(tag) { }

        protected override void OnCreated()
        {
            Console.WriteLine($"[Hook] Element <{TagName}> created");
        }

        protected override void OnInserted(LightNode child)
        {
            Console.WriteLine($"[Hook] Child inserted into <{TagName}>: {child.GetType().Name}");
        }

        protected override void OnClassListApplied()
        {
            Console.WriteLine($"[Hook] Class list applied to <{TagName}>");
        }
    }

}
