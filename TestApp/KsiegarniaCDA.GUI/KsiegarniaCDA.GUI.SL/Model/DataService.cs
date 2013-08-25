using System;
using KsiegarniaCDA.GUI.SL.KsiegarniaCDAServiceReference;

namespace KsiegarniaCDA.GUI.SL.Model
{
    public class DataService : IDataService
    {
        private readonly ServiceClient _sericeClient;


        public DataService()
        {
            _sericeClient = new ServiceClient();

        }

    }
}