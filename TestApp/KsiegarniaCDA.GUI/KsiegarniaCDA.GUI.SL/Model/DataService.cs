using System;
using KsiegarniaCDA.GUI.SL.KsiegarniaCDAServiceReference;
using System.Collections.Generic;

namespace KsiegarniaCDA.GUI.SL.Model
{
    public class DataService : IDataService
    {
        private readonly ServiceClient _serviceClient;

        #region Construktors

        public DataService()
        {
            _serviceClient = new ServiceClient();

        }

        #endregion

        #region Public Methods

        public void AutorzyComboPobierz(Action<IEnumerable<Item>, Exception> callback)
        {

            if (callback != null)
            {
                _serviceClient.AutorzyComboPobierzCompleted += (s, e) => callback(e.Result, e.Error);
                _serviceClient.AutorzyComboPobierzAsync();

            }
        }

        public void GatunkiComboPobierz(Action<IEnumerable<Item>, Exception> callback)
        {
            if (callback != null)
            {
                _serviceClient.GatunkiComboPobierzCompleted += (s, e) => callback(e.Result, e.Error);
                _serviceClient.GatunkiComboPobierzAsync();
            }
        }

        public void SearchBooks(Action<IEnumerable<BooksSearchSearchResult>, Exception> callback, BooksSearchSearchCriteria searchCriteria)
        {
            if (callback != null)
            {
                _serviceClient.SearchBooksCompleted += (s, e) => callback(e.Result, e.Error);
                _serviceClient.SearchBooksAsync(searchCriteria);
            }
        }

        #endregion



    }
}