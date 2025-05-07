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

            // var ul = new LightElementNode("ul");
            var ul = new DebugElementNode("ul");
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

            Console.WriteLine("=== Зовнішній HTML ===");
            Console.WriteLine(ul.OuterHTML);

            Console.WriteLine("=== Внутрішній HTML ===");
            Console.WriteLine(ul.InnerHTML);
        }
    }
}