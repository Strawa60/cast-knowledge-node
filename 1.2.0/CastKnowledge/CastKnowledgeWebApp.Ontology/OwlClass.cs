using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastKnowledgeWebApp.Ontology
{
    public class OwlClass : IOwlClass
    {
        public string className { get; private set; }
        public bool isSubClass { get; private set; }

        public OwlClass(string _className, bool _isSubClass)
        {
            className = _className;
            isSubClass = _isSubClass;

        }
    }

}
