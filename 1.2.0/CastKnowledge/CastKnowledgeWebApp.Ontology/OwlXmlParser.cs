using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastKnowledgeWebApp.Ontology
{
    public class OwlXmlParser : IOwlXmlParser
    {

        private string[] ReadXml(string file)
        {
                string[] readText = File.ReadAllLines(file);
                return readText;
        }

        public OwlCollection ParseXml()
        {
            OwlCollection owlCollection = new OwlCollection();
            string file = @"DBOntology.owl";
            char[] separator = {'#', '\"'};
            OwlObjectProperty objProperty = new OwlObjectProperty();
            bool t1 = false, t2 = false, t3 = false;
            

            string[] readedXml= ReadXml(file);

            foreach (var s in readedXml)
            {
                #region ParseObjectProperty

                if (System.Text.RegularExpressions.Regex.IsMatch(s, "ObjectProperty rdf:about"))
                {
                    string[] temp = s.Split(separator);
                    objProperty.objPropertyName = temp[2];
                    t1 = true;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(s, "rdfs:domain rdf:resource"))
                {
                    string[] temp = s.Split(separator);
                    objProperty.domain = temp[2];
                    t2 = true;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(s, "rdfs:range rdf:resource"))
                {
                    string[] temp = s.Split(separator);
                    objProperty.range = temp[2];
                    t3 = true;
                    
                }

                if (t1==true && t2==true && t3==true)
                {
                    owlCollection.OwlObjPropertyCollection.Add(objProperty);
                    objProperty = new OwlObjectProperty();
                    t1 = false;
                    t2 = false;
                    t3 = false;
                }

                #endregion


            }


            return owlCollection;
        }
    }
}
