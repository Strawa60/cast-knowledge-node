using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CastKnowledge.Domain.Entities.AuthorModel;
using CastKnowledge.Domain.Entities.Shared;


namespace CastKnowledge.Domain.Entities.PublicationModel
{
    public class Publication
    {
        public DateTime? publicationDate { get; set; }
        public string titlePol { get; set; }
        public string titleEng { get; set; }
        public string contentPol { get; set; }
        public string contentEng { get; set; }
        public string source { get; set; }

        public List<Author> authors;
        public List<KeyWords> descriptors;

        public Publication() { }

        public Publication(DateTime? _publicationDate, string _titlePol, string _titleEng, 
            string _contentPol, string _contentEng, string _source, List<Author> _authors) 
        {
            publicationDate = _publicationDate;
            titlePol = _titlePol;
            titleEng = _titleEng;
            contentPol = _contentPol;
            contentEng = _contentEng;
            source = _source;

            authors = new List<Author>();

            CopyAuthorsList(authors, _authors);
        }

        public Publication(DateTime? _publicationDate, string _titlePol, string _titleEng,
    string _contentPol, string _contentEng, string _source, List<Author> _authors, List<KeyWords> _descriptors)
        {
            publicationDate = _publicationDate;
            titlePol = _titlePol;
            titleEng = _titleEng;
            contentPol = _contentPol;
            contentEng = _contentEng;
            source = _source;

            authors = new List<Author>();
            descriptors = new List<KeyWords>();

            CopyAuthorsList(authors, _authors);
            CopyList(descriptors, _descriptors);
        }

        private void CopyAuthorsList(List<Author> publicationList, List<Author> copyList)
        {
            foreach (var q in copyList)
            {
                publicationList.Add(new Author { name = q.name, surname = q.surname, affiliation = q.affiliation, function = q.function });
            }
        }

        private void CopyList(List<KeyWords> descriptorsList, List<KeyWords> copyList)
        {
            foreach (var q in copyList)
            {
                descriptorsList.Add(new KeyWords { deskryptor = q.deskryptor });
            }
        }

    }
}
