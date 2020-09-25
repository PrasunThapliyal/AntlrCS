
namespace CodeGen
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection.Metadata.Ecma335;
    using Antlr4.StringTemplate;
    using Antlr4.StringTemplate.Compiler;
    using Newtonsoft.Json.Schema;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var schemaReader = new JsonSchemaReader();
            JSchema fibersReportSchema = schemaReader.ReadJsonSchema();

            var templateReader = new TemplateReader();

            foreach (var template in templateReader.LoadTemplates())
            {
                var properties = new List<int> { 1, 2, 3 }.Select(property =>
                {
                    return new
                    {
                        PropertyName = "McpProjectId",
                        CsType = "string",
                        ColumnName = "mcpProjectId",
                        IndexName = "Fibers_McpProjectIdIdx",
                        SqlType = "text"
                    };
                });

                var bags = new List<int> { 1 }.Select(bag =>
                {
                    return new
                    {
                        BagName = "Data",
                        BagFKColumnName = "fibersReport",
                        BagClassName = "FibersReportItem"
                    };
                });

                template.Add("name", "World");
                template.Add("assemblyName", "World");
                template.Add("namespace", "World");
                template.Add("className", "World");
                template.Add("tableName", "World");
                template.Add("properties", properties);
                template.Add("bags", bags);
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

    public class JsonSchemaReader
    {
        public JSchema ReadJsonSchema()
        {
            // We have the fibers report schema defined in FibersReport.json
            // This in-turn has ref to FibersReportItem.json

            // Whenever we have a ref, we must read the referred json firt (Parsing as schema not required, just read the text) 
            // And add the referred objects json schema text to the resolver
            // And then use this resolver to parse the original schema

            var fibersReportItemJsonSchemaAsText = File.ReadAllText(@"FibersReportItem.json");
            JSchemaPreloadedResolver resolver = new JSchemaPreloadedResolver();
            //var fibersReportItemSchema = JSchema.Parse(fibersReportItemJsonSchemaAsText, resolver); // Not required here (See A)

            resolver.Add(new Uri("FibersReportItem.json", UriKind.RelativeOrAbsolute), fibersReportItemJsonSchemaAsText);
            var fibersReportJsonSchemaAsText = File.ReadAllText(@"FibersReport.json");
            var fibersReportSchema = JSchema.Parse(fibersReportJsonSchemaAsText, resolver); // (A) This would then parse the referred object as well

            return fibersReportSchema;

            // However, the resulting schema has referred object completely embedded inline (not cool)
        }

        public JSchema ReadJsonSchema1()
        {
            var fibersReportJsonSchemaAsText = File.ReadAllText(@"FibersReport.json");
            var fibersReportSchema = JSchema.Parse(
                fibersReportJsonSchemaAsText, 
                new JSchemaReaderSettings { ResolveSchemaReferences = false });

            // However, this just removes the type/ref of the referred object, leaving behind just the name
            // Kind of incomplete - not cool either

            return fibersReportSchema;
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
