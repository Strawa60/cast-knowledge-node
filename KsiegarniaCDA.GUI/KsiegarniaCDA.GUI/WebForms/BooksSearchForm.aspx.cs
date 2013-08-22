using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KsiegarniaCDA.Presentation.Interfaces;
using KsiegarniaCDA.Presentation.Presenters;

namespace KsiegarniaCDA.GUI.WebForms
{
    public partial class BooksSearchForm : System.Web.UI.Page, IBooksSearchView
    {
        #region Fields

        private BooksSearchPresenter _presenter = null;

        #endregion

        #region Protected methods

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            _presenter = new BooksSearchPresenter(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsPostBack)
            {
                _presenter.InitPage();
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            _presenter.Search();
        }
    }
}