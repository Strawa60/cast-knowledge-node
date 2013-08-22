

namespace KsiegarniaCDA.DAL.DataManagers
{
    //??????????????WTF
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using KsiegarniaCDA.DTO;
    using DB;

    public class BooksSearchDataManager
    {
        #region Public methods

        public IEnumerable<Item> AutorzyComboPobierz()
        {
            return DB.Autorzy.Select(a => new Item() { Value = a.id, Text = a.imie + " " + a.nazwisko });
        }

        public IEnumerable<Item> GatunkiComboPobierz()
        {
            return DB.Gatunki.Select(g => new Item() { Value = g.id, Text = g.nazwa });
        }

        public IEnumerable<BooksSearchSearchResult> SearchBooks(BooksSearchSearchCriteria searchCriteria)
        {
            IEnumerable<Ksiazka> results = DB.Ksiazki;

            if (searchCriteria.idAutora.HasValue)
            {
                results = results.Where(r => r.idAutora == searchCriteria.idAutora.Value);
            }
            if (searchCriteria.idGatunku.HasValue)
            {
                results = results.Where(r => r.idGatunku == searchCriteria.idGatunku.Value);
            }
            if (!string.IsNullOrEmpty(searchCriteria.opis))
            {
                results = results.Where(r => r.opis.Contains(searchCriteria.opis));
            }
            if (!string.IsNullOrEmpty(searchCriteria.tytul))
            {
                results = results.Where(r => r.opis.Contains(searchCriteria.tytul));
            }
            if (!string.IsNullOrEmpty(searchCriteria.wydawnictwo))
            {
                results = results.Where(r => r.opis.Contains(searchCriteria.wydawnictwo));
            }
            if (searchCriteria.rokWydania.HasValue)
            {
                results = results.Where(r => r.rokWydania.HasValue && r.rokWydania.Value.Year == searchCriteria.rokWydania.Value);
            }

            var returnResults = from result in results
                                from autor in DB.Autorzy.Where(a => a.id == result.idAutora).DefaultIfEmpty()
                                from gatunek in DB.Gatunki.Where(g => g.id == result.idGatunku).DefaultIfEmpty()
                                select new BooksSearchSearchResult()
                                {
                                    idKsiazki = result.id,
                                    rokWydania = result.rokWydania.HasValue ? result.rokWydania.Value.Year.ToString() : string.Empty,
                                    tytul = result.tytul,
                                    autor = autor != null ? autor.imie + " " + autor.nazwisko : string.Empty,
                                    gatunek = gatunek != null ? gatunek.nazwa : string.Empty,
                                };


            return returnResults;
        }

        #endregion
    }
}
