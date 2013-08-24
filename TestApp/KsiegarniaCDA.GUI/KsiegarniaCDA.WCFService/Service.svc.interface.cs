using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using KsiegarniaCDA.DTO;

namespace KsiegarniaCDA.WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        #region Public Methods

        [OperationContract]
        IEnumerable<Item> AutorzyComboPobierz();

        [OperationContract]
        IEnumerable<Item> GatunkiComboPobierz();

        [OperationContract]
        IEnumerable<BooksSearchSearchResult> SearchBooks(BooksSearchSearchCriteria searchCriteria);

        #endregion

    }
}
