namespace KsiegarniaCDA.Presentation.Interfaces
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using KsiegarniaCDA.DTO;

	public interface IBooksSearchView
	{
		#region Methods

		BooksSearchSearchCriteria GetSearchCriteria();

		void LoadComboAutorzy(IEnumerable<Item> data);

		void LoadComboGatunki(IEnumerable<Item> data);

		void ShowSearchResults(IEnumerable<BooksSearchSearchResult> searchResults);

		#endregion

	}
}
