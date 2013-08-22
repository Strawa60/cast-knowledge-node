// -----------------------------------------------------------------------
// <copyright file="BooksSearchPresenter.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace KsiegarniaCDA.Presentation.Presenters
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
using KsiegarniaCDA.Presentation.Interfaces;
	using KsiegarniaCDA.DTO;
using KsiegarniaCDA.DAL.DataManagers;

	/// <summary>
	/// TODO: Update summary.
	/// </summary>
	public class BooksSearchPresenter
	{
		#region Fields

		private IBooksSearchView _view = null;
		private BooksSearchDataManager _booksSearchDataManager = null;

		#endregion

		#region Constructors

		public BooksSearchPresenter(IBooksSearchView view)
		{
			_view = view;
			_booksSearchDataManager = new BooksSearchDataManager();
		}

		#endregion

		#region Public methods

		public void InitPage()
		{
			var autorzy = _booksSearchDataManager.AutorzyComboPobierz();
			autorzy = (new Item[] { new Item() { Value = string.Empty, Text = string.Empty } }).Concat(autorzy.OrderBy(a => a.Text));
			_view.LoadComboAutorzy(autorzy);

			var gatunki = _booksSearchDataManager.GatunkiComboPobierz();
			gatunki = (new Item[] { new Item() { Value = string.Empty, Text = string.Empty } }).Concat(gatunki.OrderBy(g => g.Text));
			_view.LoadComboGatunki(gatunki);
		}

		public void Search()
		{
			BooksSearchSearchCriteria searchCriteria = _view.GetSearchCriteria();

			IEnumerable<BooksSearchSearchResult> searchResults = _booksSearchDataManager.SearchBooks(searchCriteria);
			
			_view.ShowSearchResults(searchResults);
		}

		#endregion
	}
}
