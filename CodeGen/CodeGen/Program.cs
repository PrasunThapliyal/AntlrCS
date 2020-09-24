using System;
using Antlr4.StringTemplate;
using Antlr4.StringTemplate.Compiler;

namespace CodeGen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Template template = new Template("Hello, <name>");
            template.Add("name", "World");

            var x = template.Render();

            Console.WriteLine(x);
        }
    }
}
