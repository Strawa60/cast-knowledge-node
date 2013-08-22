using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KsiegarniaCDA.Presentation.Interfaces;
using KsiegarniaCDA.Presentation.Presenters;
using KsiegarniaCDA.DTO;

namespace KsiegarniaCDA.GUI.WebForms
{
    public partial class BooksSearchForm : System.Web.UI.Page, IBooksSearchView
    {
        #region Fields

        private BooksSearchPresenter _presenter = null;

        #endregion

        #region Properties

        private int? IdAutora
        {
            get
            {
                return ParseInt(drpAutorzy.SelectedValue);
            }
            set
            {
                drpAutorzy.SelectedValue = ParseString(value);
            }
        }

        private int? IdGatunku
        {
            get
            {
                return ParseInt(drpGatunki.SelectedValue);
            }
            set
            {
                drpGatunki.SelectedValue = ParseString(value);
            }
        }

        private int? RokWydania
        {
            get
            {
                return ParseInt(txtRokWydania.Text);
            }
            set
            {
                txtRokWydania.Text = ParseString(value);
            }
        }

        private string Tytul
        {
            get
            {
                return txtTytul.Text;
            }
            set
            {
                txtTytul.Text = value;
            }
        }

        private string Opis
        {
            get
            {
                return txtOpis.Text;
            }
            set
            {
                txtOpis.Text = value;
            }
        }

        private string Wydawnictwo
        {
            get
            {
                return txtWydawnictwo.Text;
            }
            set
            {
                txtWydawnictwo.Text = value;
            }
        }

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

        

        protected void Page_Load(object sender, EventArgs e)
        {

            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            _presenter.Search();
        }

        #endregion

        #region Private Methods

        private int? ParseInt(string value)
        {
            int parsedValue;
            if (!int.TryParse(value, out parsedValue))
            {
                return null;
            }
            return (int?)parsedValue;
        }

        private string ParseString(int? value)
        {
            return value.HasValue ? value.Value.ToString() : string.Empty;
        }



        #endregion

        #region Public Methods

        public BooksSearchSearchCriteria GetSearchCriteria()
        {
            BooksSearchSearchCriteria searchCriteria = new BooksSearchSearchCriteria();

            searchCriteria.idAutora = IdAutora;
            searchCriteria.idGatunku = IdGatunku;
            searchCriteria.opis = Opis;
            searchCriteria.rokWydania = RokWydania;
            searchCriteria.tytul = Tytul;
            searchCriteria.wydawnictwo = Wydawnictwo;

            return searchCriteria;
        }

        public void LoadComboAutorzy(IEnumerable<Item> data)
        {
            drpAutorzy.DataSource = data;
            drpAutorzy.DataBind();
        }

        public void LoadComboGatunki(IEnumerable<Item> data)
        {
            drpGatunki.DataSource = data;
            drpGatunki.DataBind();
        }

        public void ShowSearchResults(IEnumerable<BooksSearchSearchResult> searchResults)
        {
            grdResults.DataSource = searchResults;
            grdResults.DataBind();
        }

        #endregion
    }
}