using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CastKnowledgeWebApp.Ontology.Ontology;

namespace CastKnowledgeWebApp.Ontology
{
    public class OwlCollection: IOwlCollection
    {
        public List<OwlClass> OwlClassCollection;
        public List<OwlObjectProperty> OwlObjPropertyCollection;

        public OwlCollection()
        {
            OwlObjPropertyCollection = new List<OwlObjectProperty>();
            OwlClassCollection = new List<OwlClass>();

        }

        public OwlCollection CreateOwlCollection()
        {
            OwlXmlParser parseXml = new OwlXmlParser();
            return parseXml.ParseXml();
        }
    }
}
