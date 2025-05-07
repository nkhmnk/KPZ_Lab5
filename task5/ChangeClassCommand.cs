using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class ChangeClassCommand : ICommand
    {
        private readonly LightElementNode element;
        private readonly string newClass;
        private readonly string oldClass;

        public ChangeClassCommand(LightElementNode element, string newClass)
        {
            this.element = element;
            this.newClass = newClass;
            this.oldClass = string.Join(" ", element.CssClasses);
        }

        public void Execute()
        {
            element.AddCssClass(newClass);
        }

        public void Undo()
        {
            element.RemoveCssClass(newClass);
            element.AddCssClass(oldClass);
        }
    }
}
