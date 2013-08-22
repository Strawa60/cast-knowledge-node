using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KsiegarniaCDA.DTO
{
    public class BooksSearchSearchCriteria
    {

        public int? idAutora { get; set; }
        public int? idGatunku { get; set; }
        public string tytul { get; set; }
        public string opis { get; set; }
        public int? rokWydania { get; set; }
        public string wydawnictwo { get; set; }
    }
}
