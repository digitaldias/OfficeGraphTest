using System;

namespace OfficeGraphTest.Domain.Entities
{

    public class ContactList
    {
        public string odatacontext { get; set; }
        public string odatanextLink { get; set; }
        public Value[] value { get; set; }
    }

    public class Value
    {
        public string odataetag { get; set; }
        public string id { get; set; }
        public DateTime createdDateTime { get; set; }
        public DateTime lastModifiedDateTime { get; set; }
        public string changeKey { get; set; }
        public string[] categories { get; set; }
        public string parentFolderId { get; set; }
        public DateTime? birthday { get; set; }
        public string fileAs { get; set; }
        public string displayName { get; set; }
        public string givenName { get; set; }
        public string initials { get; set; }
        public string middleName { get; set; }
        public string nickName { get; set; }
        public string surname { get; set; }
        public string title { get; set; }
        public string yomiGivenName { get; set; }
        public string yomiSurname { get; set; }
        public object yomiCompanyName { get; set; }
        public string generation { get; set; }
        public string[] imAddresses { get; set; }
        public string jobTitle { get; set; }
        public string companyName { get; set; }
        public string department { get; set; }
        public string officeLocation { get; set; }
        public string profession { get; set; }
        public string businessHomePage { get; set; }
        public string assistantName { get; set; }
        public string manager { get; set; }
        public string[] homePhones { get; set; }
        public string mobilePhone { get; set; }
        public string[] businessPhones { get; set; }
        public string spouseName { get; set; }
        public string personalNotes { get; set; }
        public object[] children { get; set; }
        public Emailaddress[] emailAddresses { get; set; }
        public Homeaddress homeAddress { get; set; }
        public Businessaddress businessAddress { get; set; }
        public Otheraddress otherAddress { get; set; }
    }

    public class Homeaddress
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string countryOrRegion { get; set; }
        public string postalCode { get; set; }
    }

    public class Businessaddress
    {
    }

    public class Otheraddress
    {
    }

    public class Emailaddress
    {
        public string name { get; set; }
        public string address { get; set; }
    }

}
