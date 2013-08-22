using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KsiegarniaCDA.DTO
{
    public class Autor
    {
        public int id { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public DateTime dataUrodzenia { get; set; }
    }
}
