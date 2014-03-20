using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CastKnowledge.Domain.Entities.Components;

namespace CastKnowledge.Domain.Entities.FoundryModel
{
    public class Foundry
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

        public List<Resource> resources;



        public Foundry(){}

        public Foundry(string _name, string _city, string _postcode, string _street, string _province,
            string _telephone, string _fax, string _webAddres, string _email,
            string _ceo, string _companyType, List<Resource> _resources)
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
            resources= new List<Resource>();

            CopyList(resources, _resources);
        }

        private List<Resource> CopyList(List<Resource> resourceList, List<Resource> copyList)
        {
            foreach (var q in copyList)
            {
                resourceList.Add(new Resource { resourceName= q.resourceName});
            }
            return resourceList;
        }
    }
}
