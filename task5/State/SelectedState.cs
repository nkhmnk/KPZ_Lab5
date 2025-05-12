using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5.State
{
    public class SelectedState : IElementState //Вибраний елемент
    {
        public void AddClass(LightElementNode element, string cssClass)
        {
            element.AddCssClass("selected");
        }

        public void RemoveClass(LightElementNode element, string cssClass)
        {
            element.RemoveCssClass("selected");
        }
    }

}
