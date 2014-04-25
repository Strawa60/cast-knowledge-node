using System.Linq;
using CastKnowledge.Domain.Abstract;
using System.Collections.Generic;
using CastKnowledge.Domain.Entities.Components;
using CastKnowledge.Domain.Entities.Shared;

namespace CastKnowledge.Domain.Entities.ContractorModel
{
    public class Contractor 
    {
        public string name { get; set; }

        public string city { get; set; }
        public string postcode { get; set; }
        public string street { get; set; }
        public string province { get; set; }

        public string telephone { get; set; }
        public string fax { get; set; }
        public string webAddress { get; set; }
        public string email { get; set; }

        public string ceo { get; set; }
        public string companyType { get; set; }

        public string resources { get; set; }
        public List<KeyWords> descriptors;



        public Contractor(){}

        public Contractor(string _name, string _city, string _postcode, string _street, string _province,
            string _telephone, string _fax, string _webAddres, string _email,
            string _ceo, string _companyType, string _resources)
        {
            name = _name;
            city = _city;
            postcode = _postcode;
            street = _street;
            province = _province;
            telephone = _telephone;
            fax = _fax;
            webAddress = _webAddres;
            email = _email;
            ceo = _ceo;
            companyType = _companyType;
            resources = _resources;

        }

        public Contractor(string _name, string _city, string _postcode, string _street, string _province,
    string _telephone, string _fax, string _webAddres, string _email,
    string _ceo, string _companyType, string _resources, List<KeyWords> _descriptors)
        {
            name = _name;
            city = _city;
            postcode = _postcode;
            street = _street;
            province = _province;
            telephone = _telephone;
            fax = _fax;
            webAddress = _webAddres;
            email = _email;
            ceo = _ceo;
            companyType = _companyType;
            resources = _resources;

            descriptors = new List<KeyWords>();

            CopyList(descriptors, _descriptors);
        }


        private void CopyList(List<KeyWords> descriptorsList, List<KeyWords> copyList)
        {
            foreach (var q in copyList)
            {
                descriptorsList.Add(new KeyWords{ deskryptor= q.deskryptor });
            }
        }
    }
}
