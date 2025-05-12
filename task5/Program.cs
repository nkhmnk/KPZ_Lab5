using System;
using System.Text;
using task5;
using task5.State;
using System.Collections.Generic;

namespace LightHTML
{
    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Створення елементів для списку
            var ul = new LightElementNode("ul");
            ul.AddCssClass("my-list");

            var li1 = new LightElementNode("li");
            li1.AddChild(new LightTextNode("Перший елемент списку"));

            var li2 = new LightElementNode("li");
            li2.AddChild(new LightTextNode("Другий елемент списку"));

            var li3 = new LightElementNode("li");
            li3.AddChild(new LightTextNode("Третій елемент списку"));

            ul.AddChild(li1);
            ul.AddChild(li2);
            ul.AddChild(li3);

            // Створення контейнера для додавання елементів
            var div = new LightElementNode("div");
            var p1 = new LightElementNode("p");
            p1.AddChild(new LightTextNode("Hello"));

            // Створення інвокера для команд
            var invoker = new CommandInvoker();

            // Команда для додавання елемента
            var addCommand = new AddElementCommand(div, p1);
            invoker.ExecuteCommand(addCommand);
            Console.WriteLine("=== HTML після виконання команди додавання елемента ===");
            Console.WriteLine(div.OuterHTML); // Показуємо результат додавання

            // Команда для зміни класу
            var changeClassCommand = new ChangeClassCommand(p1, "highlight");
            invoker.ExecuteCommand(changeClassCommand);
            Console.WriteLine("\n=== HTML після зміни класу ===");
            Console.WriteLine(div.OuterHTML); // Показуємо результат зміни класу

            // Відміна останньої команди (зміни класу)
            invoker.Undo();
            Console.WriteLine("\n=== HTML після скасування зміни класу ===");
            Console.WriteLine(div.OuterHTML); // Показуємо результат після скасування

            // Відміна попередньої команди (додавання елемента)
            invoker.Undo();
            Console.WriteLine("\n=== HTML після скасування додавання елемента ===");
            Console.WriteLine(div.OuterHTML); // Показуємо результат після скасування

            // Ітерація через елементи (DFS)
            Console.WriteLine("=== DFS (глибина) ===");
            foreach (var node in ul.EnumerateDepthFirst())
            {
                Console.WriteLine(node.OuterHTML); // Виводимо кожен елемент
            }

            // Ітерація через елементи (BFS)
            Console.WriteLine("=== BFS (ширина) ===");
            foreach (var node in ul.EnumerateBreadthFirst())
            {
                Console.WriteLine(node.OuterHTML); // Виводимо кожен елемент
            }

            // Перевірка нормального стану
            div.AddClass("normal");
            Console.WriteLine("\n=== HTML після додавання класу 'normal' ===");
            Console.WriteLine(div.OuterHTML);

            // Зміна стану на "Hovered"
            div.SetState(new HoveredState());
            div.AddClass("hovered");
            Console.WriteLine("\n=== HTML після зміни на 'Hovered' ===");
            Console.WriteLine(div.OuterHTML);

            // Зміна стану на "Selected"
            div.SetState(new SelectedState());
            div.AddClass("selected");
            Console.WriteLine("\n=== HTML після зміни на 'Selected' ===");
            Console.WriteLine(div.OuterHTML);
        }
    }
}
