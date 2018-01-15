﻿namespace OfficeGraphTest.Domain.Entities
{
    public class GraphUser
    {
        public string odatacontext { get; set; }

        public string id { get; set; }

        public string[] businessPhones { get; set; }

        public string displayName { get; set; }

        public string givenName { get; set; }

        public string jobTitle { get; set; }

        public string mail { get; set; }

        public object mobilePhone { get; set; }

        public string officeLocation { get; set; }

        public string preferredLanguage { get; set; }

        public string surname { get; set; }

        public string userPrincipalName { get; set; }
    }

}
