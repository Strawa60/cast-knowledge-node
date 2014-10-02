using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastKnowledgeWebApp.Ontology
{
    public class OwlClass : IOwlClass
    {
        public string className { get; set; }
        public string isSubClassOf { get; set; }

        public OwlClass(string _className, string _isSubClass)
        {
            className = _className;
            isSubClassOf = _isSubClass;

        }

        public OwlClass()
        {
            
        }
    }

}
