using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CastKnowledgeWebApp.Ontology;
using CastKnowledgeWebApp.SearchEngine;
using CastKnowledgeWebApp.Domain;

namespace CastKnowledgeWebApp.UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {

            //OwlCollection owlColl = new OwlCollection();
            //owlColl=owlColl.CreateOwlCollection();
            HashSet<Dostawca> asd = new HashSet<Dostawca>();
            Search aaa = new Search("stop");


            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
