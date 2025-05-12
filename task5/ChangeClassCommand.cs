using System;
using System.Collections.Generic;
using System.Linq;

namespace task5
{
    public class ChangeClassCommand : ICommand
    {
        private readonly LightElementNode element;
        private readonly string newClass;
        private List<string> oldClasses;

        public ChangeClassCommand(LightElementNode element, string newClass)
        {
            this.element = element ?? throw new ArgumentNullException(nameof(element));
            this.newClass = newClass;
        }

        public void Execute()
        {
            oldClasses = element.CssClasses.ToList(); // Зберігаємо попередні CSS-класи
            element.AddCssClass(newClass);            // Додаємо новий клас
        }

        public void Undo()
        {
            element.SetCssClasses(oldClasses); // Відновлюємо збережені CSS-класи
        }
    }
}
