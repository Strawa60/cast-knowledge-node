﻿using System.Linq;
using CastKnowledge.Domain.Abstract;
using System.Collections.Generic;
using CastKnowledge.Domain.Entities.Components;

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

        public List<Resource> resources;



        public Contractor(){}

        //public Contractor(string _name, string _ceo, string _searchTerm, string  _companyType, 
        //    string _postcode, string _city, string _street, string _telephone, string _fax, 
        //    string _province, string _webAddress, System.Net.Mail.MailAddress _email, 
        //    List<Resource> _resources, List<Material> _materials)
        //{
        //    resources = _resources;
        //    materials = _materials;

        //    name = _name;
        //    ceo = _ceo;
        //    searchTerm = _searchTerm;
        //    companytype = _companyType;
        //    //ContractorContact = new Contact(_postcode, _city, _street,  _telephone,  _fax, _province, _webAddress, _email);

            

        //}

        public Contractor(string _name, string _city, string _postcode, string _street, string _province,
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