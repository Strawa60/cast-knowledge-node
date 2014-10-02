using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastKnowledgeWebApp.Ontology
{
    public class OwlCollection
    {
        public List<OwlClass> OwlClassCollection;
        public List<OwlObjectProperty> OwlObjPropertyCollection;

        public OwlCollection()
        {
            OwlObjPropertyCollection = new List<OwlObjectProperty>();
            OwlClassCollection = new List<OwlClass>();

        }
    }
}
