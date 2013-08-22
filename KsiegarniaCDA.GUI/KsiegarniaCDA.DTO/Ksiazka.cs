using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KsiegarniaCDA.DTO
{
    public class Ksiazka
    {
        public int id { get; set; }
        public string tytul { get; set; }
        public int idAutora { get; set; }
        public int idGatunku { get; set; }
        public DateTime rokWydania { get; set; }
        public string wydawnictwo { get; set; }
        public string opis { get; set; }

    }
}
