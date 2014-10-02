using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastKnowledgeWebApp.Ontology
{
    interface IOwlXmlParser
    {
        OwlCollection ParseXml();
    }
}
