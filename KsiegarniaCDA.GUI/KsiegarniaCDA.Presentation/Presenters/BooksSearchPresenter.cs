using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KsiegarniaCDA.Presentation.Interfaces;

namespace KsiegarniaCDA.Presentation.Presenters
{
    
    public class BooksSearchPresenter
    {
        #region Fields

        private IBooksSearchView _view;

        #endregion


        #region Construktors

        public BooksSearchPresenter(IBooksSearchView view)
        {
            _view = view;
        }

        #endregion


        #region Public methods

        public void InitPage()
        {

        }

        public void Search()
        {

        }

        #endregion
    }
}
