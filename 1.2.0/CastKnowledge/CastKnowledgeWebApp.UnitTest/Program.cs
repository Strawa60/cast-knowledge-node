using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CastKnowledgeWebApp.Ontology;

namespace CastKnowledgeWebApp.UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            OwlXmlParser oxp = new OwlXmlParser();
            oxp.ParseXml();

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
