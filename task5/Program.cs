using System;
using System.Text;
using task5;

namespace LightHTML
{
    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

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

            // Виконуємо команди
            var div = new LightElementNode("div");
            var p1 = new LightElementNode("p");
            p1.AddChild(new LightTextNode("Hello"));

            var invoker = new CommandInvoker();

            // Команди
            var addCommand = new AddElementCommand(div, p1);
            invoker.ExecuteCommand(addCommand);

            var changeClassCommand = new ChangeClassCommand(p1, "highlight");
            invoker.ExecuteCommand(changeClassCommand);

            Console.WriteLine("=== HTML після виконання команд ===");
            Console.WriteLine(div.OuterHTML);

            // Відміна останньої команди (ChangeClassCommand)
            invoker.Undo();
            Console.WriteLine("\n=== HTML після скасування зміни класу ===");
            Console.WriteLine(div.OuterHTML);

            // Відміна попередньої команди (AddElementCommand)
            invoker.Undo();
            Console.WriteLine("\n=== HTML після скасування додавання елемента ===");
            Console.WriteLine(div.OuterHTML);

            // Ітерація через елементи
            Console.WriteLine("=== DFS (глибина) ===");
            foreach (var node in ul.EnumerateDepthFirst())
            {
                Console.WriteLine(node.OuterHTML);
            }

            Console.WriteLine("=== BFS (ширина) ===");
            foreach (var node in ul.EnumerateBreadthFirst())
            {
                Console.WriteLine(node.OuterHTML);
            }
        }
    }
}