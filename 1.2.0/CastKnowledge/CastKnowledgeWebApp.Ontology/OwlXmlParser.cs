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
        public OwlXmlParser()
        {
            
        }
        private string[] ReadXml(string file)
        {
                string[] readText = File.ReadAllLines(@"D://DBOntology.owl");
                return readText;
        }

        public OwlCollection ParseXml()
        {
            var owlCollection = new OwlCollection();
            const string file = @"DBOntology.owl";
            char[] separator = {'#', '\"'};
            var owlObjProperty = new OwlObjectProperty();
            var owlClass = new OwlClass();
            bool objProp1 = false, objProp2 = false, objProp3 = false;
            bool class1 = false, class2 = false, class3 = false;
            

            string[] readedXml= ReadXml(file);

            foreach (var s in readedXml)
            {

                #region ParseObjectProperty

                if (System.Text.RegularExpressions.Regex.IsMatch(s, "ObjectProperty rdf:about"))
                {
                    string[] temp = s.Split(separator);
                    owlObjProperty.objPropertyName = temp[2];
                    objProp1 = true;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(s, "rdfs:domain rdf:resource"))
                {
                    string[] temp = s.Split(separator);
                    owlObjProperty.domain = temp[2];
                    objProp2 = true;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(s, "rdfs:range rdf:resource"))
                {
                    string[] temp = s.Split(separator);
                    owlObjProperty.range = temp[2];
                    objProp3 = true;
                    
                }

                if (objProp1==true && objProp2==true && objProp3==true)
                {
                    owlCollection.OwlObjPropertyCollection.Add(owlObjProperty);
                    owlObjProperty = new OwlObjectProperty();
                    objProp1 = false;
                    objProp2 = false;
                    objProp3 = false;
                }

                #endregion

                #region ParseClasses

                if (System.Text.RegularExpressions.Regex.IsMatch(s, "Class rdf:about"))
                {
                    string[] temp = s.Split(separator);
                    owlClass.className = temp[2];
                    class1 = true;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(s, "rdfs:subClassOf rdf:resource"))
                {
                    string[] temp = s.Split(separator);
                    owlClass.isSubClassOf = temp[2];
                    class2 = true;
                }

                if (System.Text.RegularExpressions.Regex.IsMatch(s, "</Class>"))
                {
                    owlCollection.OwlClassCollection.Add(owlClass);
                    owlClass = new OwlClass();
                    class1 = false;
                    class2 = false;
                }

                if (s== "    " && class1==true && class2==false)
                {
                    owlClass.isSubClassOf = null;
                    owlCollection.OwlClassCollection.Add(owlClass);
                    owlClass = new OwlClass();
                    class1 = false;
                    class2 = false;

                }
                #endregion
            }


            return owlCollection;
        }
    }
}
