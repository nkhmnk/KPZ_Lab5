using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5.State
{
    public class NormalState : IElementState //Нормальний стан
    {
        public void AddClass(LightElementNode element, string cssClass)
        {
            element.AddCssClass(cssClass); // Додаємо клас до елемента
        }

        public void RemoveClass(LightElementNode element, string cssClass)
        {
            element.RemoveCssClass(cssClass); // Видаляємо клас з елемента
        }
    }

}
