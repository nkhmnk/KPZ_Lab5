using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5.State
{
    public class HoveredState : IElementState //Наведення на елемент
    {
        public void AddClass(LightElementNode element, string cssClass)
        {
            // Додаємо стиль для Hovered
            element.AddCssClass("hovered");
        }

        public void RemoveClass(LightElementNode element, string cssClass)
        {
            element.RemoveCssClass("hovered");
        }
    }

}
