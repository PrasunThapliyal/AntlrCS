
namespace CodeGen
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Antlr4.StringTemplate;
    using Antlr4.StringTemplate.Compiler;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var templateReader = new TemplateReader();

            foreach (var template in templateReader.LoadTemplates())
            {
                template.Add("name", "World");
                template.Add("assemblyName", "World");
                template.Add("namespace", "World");
                template.Add("className", "World");
                template.Add("tableName", "World");
                template.Add("propertyName", "World");
                template.Add("csType", "World");
                template.Add("columnName", "World");
                template.Add("indexName", "World");
                template.Add("bagName", "World");
                template.Add("bagFKColumnName", "World");
                template.Add("bagType", "World");

                var x = template.Render();
                Console.WriteLine(x);
            }

        }

    }

    public class TemplateReader
    {
        public TemplateReader()
        {

        }

        public IEnumerable<Template> LoadTemplates()
        {
            var assembly = GetType().Assembly;
            foreach (var resourceName in assembly.GetManifestResourceNames())
            {
                using (var stream = assembly.GetManifestResourceStream(resourceName))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var text = reader.ReadToEnd();
                        yield return new Template(text);
                    }
                }
            }
        }

    }
}
