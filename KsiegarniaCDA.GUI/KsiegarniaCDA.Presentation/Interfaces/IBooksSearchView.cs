using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KsiegarniaCDA.DTO;

namespace KsiegarniaCDA.Presentation.Interfaces
{
    public interface IBooksSearchView
    {
        BooksSearchSearchCriteria GetSearchCriteria();

        void LoadComboAutorzy(IEnumerable<Item> data);

        void LoadComboGatunki(IEnumerable<Item> data);

        void ShowSearchResults(IEnumerable<BooksSearchSearchResult> searchResults);
    }


}
