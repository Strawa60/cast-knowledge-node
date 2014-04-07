using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastKnowledge.Domain.Entities.AuthorModel
{
    public class Author
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string affiliation { get; set; }
        public string function { get; set; }

        public Author() { }

        public Author(string _name, string _surname, string _affiliation, string _function)
        {
            name = _name;
            surname = _surname;
            affiliation = _affiliation;
            function = _function;
        }
    }
}
