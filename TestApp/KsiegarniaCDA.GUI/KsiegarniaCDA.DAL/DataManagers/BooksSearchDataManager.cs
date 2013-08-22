namespace KsiegarniaCDA.DAL.DataManagers
{
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
			return DB.Autorzy.Select(a => new Item() { Value = a.Id, Text = a.Imie + " " + a.Nazwisko });
		}

		public IEnumerable<Item> GatunkiComboPobierz()
		{
			return DB.Gatunki.Select(g => new Item() { Value = g.Id, Text = g.Nazwa });
		}

		public IEnumerable<BooksSearchSearchResult> SearchBooks(BooksSearchSearchCriteria searchCriteria)
		{
			IEnumerable<Ksiazka> results = DB.Ksiazki;

			if (searchCriteria.IdAutora.HasValue)
			{
				results = results.Where(r => r.IdAutora == searchCriteria.IdAutora.Value);
			}
			if (searchCriteria.IdGatunku.HasValue)
			{
				results = results.Where(r => r.IdGatunku == searchCriteria.IdGatunku.Value);
			}
			if (!string.IsNullOrEmpty(searchCriteria.Opis))
			{
				results = results.Where(r => r.Opis.Contains(searchCriteria.Opis));
			}
			if (!string.IsNullOrEmpty(searchCriteria.Tytul))
			{
				results = results.Where(r => r.Opis.Contains(searchCriteria.Tytul));
			}
			if (!string.IsNullOrEmpty(searchCriteria.Wydawnictwo))
			{
				results = results.Where(r => r.Opis.Contains(searchCriteria.Wydawnictwo));
			}
			if (searchCriteria.RokWydania.HasValue)
			{
				results = results.Where(r => r.RokWydania.HasValue && r.RokWydania.Value.Year == searchCriteria.RokWydania.Value);
			}

			var returnResults = from result in results
								from autor in DB.Autorzy.Where(a => a.Id == result.IdAutora).DefaultIfEmpty()
								from gatunek in DB.Gatunki.Where(g => g.Id == result.IdGatunku).DefaultIfEmpty()
								select new BooksSearchSearchResult() 
								{
									IdKsiazki = result.Id,
									RokWydania = result.RokWydania.HasValue ? result.RokWydania.Value.Year.ToString() : string.Empty,
									Tytul = result.Tytul,
									Autor = autor != null ? autor.Imie + " " + autor.Nazwisko : string.Empty,
									Gatunek = gatunek != null ? gatunek.Nazwa : string.Empty,
								};


			return returnResults;
		}

		#endregion
	}
}
