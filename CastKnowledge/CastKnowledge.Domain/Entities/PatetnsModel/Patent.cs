using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CastKnowledge.Domain.Entities.AuthorModel;

namespace CastKnowledge.Domain.Entities.PatetnsModel
{
    public class Patent
    {
        public decimal inventionID { get; set; }
        public DateTime? beginingDate { get; set; }
        public DateTime? endDate { get; set; }
        public DateTime? reportDate { get; set; }
        public string patentSymbol { get; set; }
        public string titlePol { get; set; }
        public string titleEng { get; set; }
        public string contentPol { get; set; }
        public string contentEng { get; set; }
        public string faculty { get; set; }
        public string url { get; set; }

        public List<Author> authors;

        public Patent() { }

        public Patent(decimal _inventionID, DateTime? _beginingDate, DateTime? _endDate, DateTime? _reportDate, 
            string _patentSymbol, string _titlePol , string _titleEng, string _contentPol, string _contentEng, 
            string _faculty, string _url, List<Author> _authors)
        {
            inventionID = _inventionID;
            beginingDate = _beginingDate;
            endDate = _endDate;
            reportDate = _reportDate;
            patentSymbol = _patentSymbol;
            titlePol = _titlePol;
            titleEng = _titleEng;
            contentPol = _contentPol;
            contentEng = _contentEng;
            faculty = _faculty;
            url = _url;

            authors = new List<Author>();
            CopyAuthorsList(authors, _authors);

        }

        private void CopyAuthorsList(List<Author> AuthorsList, List<Author> copyList)
        {
            foreach (var q in copyList)
            {
                AuthorsList.Add(new Author { name = q.name, surname = q.surname, affiliation = q.affiliation, function = q.function });
            }
        }
    }
}
