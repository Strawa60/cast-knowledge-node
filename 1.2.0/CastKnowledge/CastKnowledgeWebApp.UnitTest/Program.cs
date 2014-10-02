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

            OwlCollection owlColl = new OwlCollection();
            owlColl=owlColl.CreateOwlCollection();

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
