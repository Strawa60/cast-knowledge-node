namespace CastKnowledge.Domain.Entities.ContractorModel
{
    public class Contact
    {
        public string postcode { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string telephone { get; set; }
        public string fax { get; set; }
        public string province { get; set; }
        public string webAdress { get; set; }
        public System.Net.Mail.MailAddress email { get; set; }


        public Contact()
        {

        }

        public Contact(string _postcode, string _city, string _street, string _telephone, string _fax, string _province, string _webAddress, System.Net.Mail.MailAddress _email)
        {
            postcode = _postcode;
            city = _city;
            street = _street;
            telephone = _telephone;
            fax = _fax;
            province = _province;
            webAdress = _webAddress;
            System.Net.Mail.MailAddress email = _email;
        }

    }
}
