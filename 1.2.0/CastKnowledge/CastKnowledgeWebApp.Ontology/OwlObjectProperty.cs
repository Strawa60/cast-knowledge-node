using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastKnowledgeWebApp.Ontology
{
    public class OwlObjectProperty : IOwlObjectProperty
    {
        public string objPropertyName { get; set; }
        public string domain { get; set; }
        public string range { get; set; }

        public OwlObjectProperty()
        {
            
        }

        public OwlObjectProperty(string _objPropertyName, string _domain, string _range)
        {

            objPropertyName = _objPropertyName;
            domain = _domain;
            range = _range;
        }

    }
}
