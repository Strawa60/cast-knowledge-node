using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using KsiegarniaCDA.DAL.DataManagers;
using KsiegarniaCDA.DTO;

namespace KsiegarniaCDA.WCFService
{
    public class Service : IService
    {
        #region Fields

        private BooksSearchDataManager _booksSearchDataManager = null;

        #endregion

        #region Construktors

        public Service()
        {
            _booksSearchDataManager = new BooksSearchDataManager();
        }

        #endregion

        #region Public Methods

        public IEnumerable<Item> AutorzyComboPobierz()
        {
            return _booksSearchDataManager.AutorzyComboPobierz();
        }

        public IEnumerable<Item> GatunkiComboPobierz()
        {
            return _booksSearchDataManager.GatunkiComboPobierz();
        }

        public IEnumerable<BooksSearchSearchResult> SearchBooks(BooksSearchSearchCriteria searchCriteria)
        {
            return _booksSearchDataManager.SearchBooks(searchCriteria);
        }

        #endregion


    }
}
