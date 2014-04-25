using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CastKnowledge.Domain.Entities.Components;
using CastKnowledge.Domain.Entities.Shared;


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

        public List<Material> materials;
        public List<CastTechnology> technologies;
        public List<KeyWords> descriptors;


        public Foundry(){}

        public Foundry(string _name, string _city, string _postcode, string _street, string _province,
            string _telephone, string _fax, string _webAddres, string _email,
            string _ceo, string _companyType, List<Material> _materials, List<CastTechnology> _technologies)
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

            materials = new List<Material>();
            technologies = new List<CastTechnology>();

            CopyMaterialList(materials, _materials);
            CopyTechnologyList(technologies, _technologies);
            
        }
        public Foundry(string _name, string _city, string _postcode, string _street, string _province,
    string _telephone, string _fax, string _webAddres, string _email,
    string _ceo, string _companyType, List<Material> _materials, List<CastTechnology> _technologies, List<KeyWords> _descriptors)
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

            materials = new List<Material>();
            technologies = new List<CastTechnology>();
            descriptors = new List<KeyWords>();

            CopyMaterialList(materials, _materials);
            CopyTechnologyList(technologies, _technologies);
            CopyList(descriptors, _descriptors);

        }

        private void CopyMaterialList(List<Material> materialList, List<Material> copyList)
        {
            foreach (var q in copyList)
            {
                materialList.Add(new Material { materialName = q.materialName, materialSymbol = q.materialSymbol });
            }
        }

        private void CopyTechnologyList(List<CastTechnology> technologiesList, List<CastTechnology> copyList)
        {
            foreach (var q in copyList)
            {
                technologiesList.Add(new CastTechnology { technologyName = q.technologyName });
            }
        }

        private void CopyList(List<KeyWords> descriptorsList, List<KeyWords> copyList)
        {
            foreach (var q in copyList)
            {
                descriptorsList.Add(new KeyWords { deskryptor = q.deskryptor });
            }
        }
    }
}
