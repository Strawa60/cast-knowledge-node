using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KsiegarniaCDA.DTO
{
    public class BooksSearchSearchResult
    {
        public int idKsiazki { get; set; }
        public string tytul { get; set; }
        public string autor { get; set; }
        public string gatunek { get; set; }
        public string rokWydania { get; set; }
    }
}
