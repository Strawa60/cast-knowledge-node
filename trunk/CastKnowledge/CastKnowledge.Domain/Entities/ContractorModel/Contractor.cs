using System.Linq;
using CastKnowledge.Domain.Abstract;
using System.Collections.Generic;


namespace CastKnowledge.Domain.Entities.ContractorModel
{
    public class Contractor : IResultType
    {
        public string name { get; set; }
        public string ceo { get; set; }
        public string searchTerm { get; set; }
        public string companytype { get; set; }
        public Contact ContractorContact;
        public List<Resource> resources = new List<Resource>();
        public List<Material> materials= new List<Material>();


        public Contractor()
        {

        }

        public Contractor(string _name, string _ceo, string _searchTerm, string  _companyType, 
            string _postcode, string _city, string _street, string _telephone, string _fax, 
            string _province, string _webAddress, System.Net.Mail.MailAddress _email, 
            List<Resource> _resources, List<Material> _materials)
        {
            resources = _resources;
            materials = _materials;

            name = _name;
            ceo = _ceo;
            searchTerm = _searchTerm;
            companytype = _companyType;
            ContractorContact = new Contact(_postcode, _city, _street,  _telephone,  _fax, _province, _webAddress, _email);

            

        }

    }
}
