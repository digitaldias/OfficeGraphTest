﻿using OfficeGraphTest.Domain.Contracts;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace OfficeGraphTest.Data.Fakes
{
    //TODO: Dammit, need internet connection to download sample data!! 
    public class FakeOfficeGraphReader : IOfficeGraphReader
    {
        public async Task<byte[]> GetImageBytesAsync(string bearerToken)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().FirstOrDefault(n => n.EndsWith("frog.jpg"));

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                var buffer = new byte[stream.Length];
                await stream.ReadAsync(buffer, 0, (int)stream.Length);
                return buffer;
            }
        }


        public Task<string> GetMyContactsAsync(string bearerToken)
        {
            const string contactsString = "{ \"@odata.context\": \"https://graph.microsoft.com/v1.0/$metadata#users('6f940512-08bc-4687-b067-2463f1185337')/contacts\", \"@odata.nextLink\": \"https://graph.microsoft.com/v1.0/me/contacts?$skip=10\", \"value\": [ { \"@odata.etag\": \"W/\"EQAAABYAAABdD8QXX8jfRpWW7oGFUMrYAACocirL\"\", \"id\": \"AAMkAGIwOTljMTMwLTQ2OWMtNDg2Mi04OTY5LWRlZThhNmNmNTk3ZgBGAAAAAAAtZBQgCmGbQqKysnFgAArhBwC7weOxYXjPSbAoBsBbVMHAAAAArIKpAABdD8QXX8jfRpWW7oGFUMrYAACoJRxVAAA=\", \"createdDateTime\": \"2017-11-24T06:54:39Z\", \"lastModifiedDateTime\": \"2017-11-24T07:08:18Z\", \"changeKey\": \"EQAAABYAAABdD8QXX8jfRpWW7oGFUMrYAACocirL\", \"categories\": [], \"parentFolderId\": \"AAMkAGIwOTljMTMwLTQ2OWMtNDg2Mi04OTY5LWRlZThhNmNmNTk3ZgAuAAAAAAAtZBQgCmGbQqKysnFgAArhAQC7weOxYXjPSbAoBsBbVMHAAAAArIKpAAA=\", \"birthday\": null, \"fileAs\": \"\", \"displayName\": \"Alfonso Rodriguez Rubio\", \"givenName\": \"Alfonso\", \"initials\": null, \"middleName\": \"\", \"nickName\": \"\", \"surname\": \"Rodriguez Rubio\", \"title\": \"\", \"yomiGivenName\": \"\", \"yomiSurname\": \"\", \"yomiCompanyName\": null, \"generation\": \"\", \"imAddresses\": [ \"alfonsor@microsoft.com\" ], \"jobTitle\": \"AUDIENCE EVANGELISM MANAGER\", \"companyName\": \"SPAIN\", \"department\": \"CSE-EMEA-Spain\", \"officeLocation\": \"MADRID-LA FINCA/2008C\", \"profession\": null, \"businessHomePage\": null, \"assistantName\": \"\", \"manager\": \"\", \"homePhones\": [], \"mobilePhone\": \"+34 629575945\", \"businessPhones\": [ \"+34 (91) 3919818 X9818\" ], \"spouseName\": \"\", \"personalNotes\": \"\", \"children\": [], \"emailAddresses\": [ { \"name\": \"Alfonso Rodriguez Rubio\", \"address\": \"alfonsor@microsoft.com\" } ], \"homeAddress\": {}, \"businessAddress\": {}, \"otherAddress\": {} }, { \"@odata.etag\": \"W/\"EQAAABYAAABdD8QXX8jfRpWW7oGFUMrYAACcCogk\"\", \"id\": \"AAMkAGIwOTljMTMwLTQ2OWMtNDg2Mi04OTY5LWRlZThhNmNmNTk3ZgBGAAAAAAAtZBQgCmGbQqKysnFgAArhBwC7weOxYXjPSbAoBsBbVMHAAAAArIKpAABdD8QXX8jfRpWW7oGFUMrYAACKZGuZAAA=\", \"createdDateTime\": \"2017-09-20T03:38:09Z\", \"lastModifiedDateTime\": \"2017-10-24T02:59:54Z\", \"changeKey\": \"EQAAABYAAABdD8QXX8jfRpWW7oGFUMrYAACcCogk\", \"categories\": [], \"parentFolderId\": \"AAMkAGIwOTljMTMwLTQ2OWMtNDg2Mi04OTY5LWRlZThhNmNmNTk3ZgAuAAAAAAAtZBQgCmGbQqKysnFgAArhAQC7weOxYXjPSbAoBsBbVMHAAAAArIKpAAA=\", \"birthday\": null, \"fileAs\": \"\", \"displayName\": \"João Almeida\", \"givenName\": \"João\", \"initials\": null, \"middleName\": \"\", \"nickName\": \"\", \"surname\": \"Almeida\", \"title\": \"\", \"yomiGivenName\": \"\", \"yomiSurname\": \"\", \"yomiCompanyName\": null, \"generation\": \"\", \"imAddresses\": [], \"jobTitle\": \"SR TECH EVANGELIST\", \"companyName\": \"PORTUGAL\", \"department\": \"WCB TED Portugal\", \"officeLocation\": \"LISBON-VIRTUAL/Mobile\", \"profession\": null, \"businessHomePage\": null, \"assistantName\": \"\", \"manager\": \"\", \"homePhones\": [], \"mobilePhone\": \"+351 961 339 492\", \"businessPhones\": [ \"+351 (21) 0491492 X1492\" ], \"spouseName\": \"\", \"personalNotes\": \"\", \"children\": [], \"emailAddresses\": [ { \"name\": \"João Almeida\", \"address\": \"joalmeid@microsoft.com\" } ], \"homeAddress\": {}, \"businessAddress\": {}, \"otherAddress\": {} }, { \"@odata.etag\": \"W/\"EQAAABYAAABdD8QXX8jfRpWW7oGFUMrYAACSz5H /\"\", \"id\": \"AAMkAGIwOTljMTMwLTQ2OWMtNDg2Mi04OTY5LWRlZThhNmNmNTk3ZgBGAAAAAAAtZBQgCmGbQqKysnFgAArhBwC7weOxYXjPSbAoBsBbVMHAAAAArIKpAABdD8QXX8jfRpWW7oGFUMrYAAATXa1JAAA=\", \"createdDateTime\": \"2017-05-30T19:25:29Z\", \"lastModifiedDateTime\": \"2017-10-03T09:47:25Z\", \"changeKey\": \"EQAAABYAAABdD8QXX8jfRpWW7oGFUMrYAACSz5H/\", \"categories\": [], \"parentFolderId\": \"AAMkAGIwOTljMTMwLTQ2OWMtNDg2Mi04OTY5LWRlZThhNmNmNTk3ZgAuAAAAAAAtZBQgCmGbQqKysnFgAArhAQC7weOxYXjPSbAoBsBbVMHAAAAArIKpAAA=\", \"birthday\": \"1969-12-13T23:00:00Z\", \"fileAs\": \"Dias, Pedro\", \"displayName\": \"Pedro Dias\", \"givenName\": \"Pedro\", \"initials\": \"P.D.\", \"middleName\": \"\", \"nickName\": \"digitaldias\", \"surname\": \"Dias\", \"title\": \"\", \"yomiGivenName\": null, \"yomiSurname\": null, \"yomiCompanyName\": null, \"generation\": \"\", \"imAddresses\": [ \"\" ], \"jobTitle\": \"Sr.Technical Evangelist\", \"companyName\": \"Microsoft Norge AS\", \"department\": \"DX\", \"officeLocation\": \"Oslo\", \"profession\": \"\", \"businessHomePage\": \"http://digitaldias.com\", \"assistantName\": null, \"manager\": \"John Henrik Andersen\", \"homePhones\": [], \"mobilePhone\": \"+47 91698263\", \"businessPhones\": [], \"spouseName\": \"Bergfrid Skaara Dias\", \"personalNotes\": \"\", \"children\": [], \"emailAddresses\": [ { \"name\": \"Pedro Dias (pedias@microsoft.com)\", \"address\": \"pedias@microsoft.com\" } ], \"homeAddress\": { \"street\": \"Fjellbovegen 78\", \"city\": \"Frogner\", \"state\": \"Akershus\", \"countryOrRegion\": \"Norway\", \"postalCode\": \"2016\" }, \"businessAddress\": {}, \"otherAddress\": {} }, { \"@odata.etag\": \"W/\"EQAAABYAAABdD8QXX8jfRpWW7oGFUMrYAABBSERF\"\", \"id\": \"AAMkAGIwOTljMTMwLTQ2OWMtNDg2Mi04OTY5LWRlZThhNmNmNTk3ZgBGAAAAAAAtZBQgCmGbQqKysnFgAArhBwC7weOxYXjPSbAoBsBbVMHAAAAArIKpAABdD8QXX8jfRpWW7oGFUMrYAAATXa1IAAA=\", \"createdDateTime\": \"2017-05-30T19:03:42Z\", \"lastModifiedDateTime\": \"2017-05-30T19:13:47Z\", \"changeKey\": \"EQAAABYAAABdD8QXX8jfRpWW7oGFUMrYAABBSERF\", \"categories\": [ \"@Home\" ], \"parentFolderId\": \"AAMkAGIwOTljMTMwLTQ2OWMtNDg2Mi04OTY5LWRlZThhNmNmNTk3ZgAuAAAAAAAtZBQgCmGbQqKysnFgAArhAQC7weOxYXjPSbAoBsBbVMHAAAAArIKpAAA=\", \"birthday\": null, \"fileAs\": \"Bergrid Skaara Dias\", \"displayName\": \"Fru Bergrid Skaara Dias\", \"givenName\": \"Bergrid\", \"initials\": \"B.S.D.\", \"middleName\": \"Skaara\", \"nickName\": null, \"surname\": \"Dias\", \"title\": \"Fru\", \"yomiGivenName\": null, \"yomiSurname\": null, \"yomiCompanyName\": null, \"generation\": \"\", \"imAddresses\": [ \"\" ], \"jobTitle\": \"Technical Writer\", \"companyName\": \"Conax AS\", \"department\": \"\", \"officeLocation\": null, \"profession\": null, \"businessHomePage\": \"https://digitaldiina.com/\", \"assistantName\": null, \"manager\": null, \"homePhones\": [], \"mobilePhone\": \"+47 92415263\", \"businessPhones\": [], \"spouseName\": null, \"personalNotes\": \"\", \"children\": [], \"emailAddresses\": [ { \"name\": \"Bergfrid Marie Skaara (bergfrid@digitaldias.com)\", \"address\": \"bergfrid@digitaldias.com\" } ], \"homeAddress\": { \"street\": \"Fjellbovegen 78\", \"city\": \"Frogner\", \"state\": \"Akershus\", \"countryOrRegion\": \"Norway\", \"postalCode\": \"2016\" }, \"businessAddress\": {}, \"otherAddress\": {} }, { \"@odata.etag\": \"W/\"EQAAABYAAABdD8QXX8jfRpWW7oGFUMrYAABMFQD3\"\", \"id\": \"AAMkAGIwOTljMTMwLTQ2OWMtNDg2Mi04OTY5LWRlZThhNmNmNTk3ZgBGAAAAAAAtZBQgCmGbQqKysnFgAArhBwC7weOxYXjPSbAoBsBbVMHAAAAArIKpAAADW7IWaYlHSaBcHH4zMU7eAABMtGb4AAA=\", \"createdDateTime\": \"2014-04-01T11:53:10Z\", \"lastModifiedDateTime\": \"2017-06-15T18:05:36Z\", \"changeKey\": \"EQAAABYAAABdD8QXX8jfRpWW7oGFUMrYAABMFQD3\", \"categories\": [], \"parentFolderId\": \"AAMkAGIwOTljMTMwLTQ2OWMtNDg2Mi04OTY5LWRlZThhNmNmNTk3ZgAuAAAAAAAtZBQgCmGbQqKysnFgAArhAQC7weOxYXjPSbAoBsBbVMHAAAAArIKpAAA=\", \"birthday\": null, \"fileAs\": \"Falch, Christian\", \"displayName\": \"|\", \"givenName\": \"|\", \"initials\": \"\", \"middleName\": \"\", \"nickName\": null, \"surname\": \"\", \"title\": \"\", \"yomiGivenName\": null, \"yomiSurname\": null, \"yomiCompanyName\": null, \"generation\": \"\", \"imAddresses\": [], \"jobTitle\": null, \"companyName\": null, \"department\": null, \"officeLocation\": null, \"profession\": null, \"businessHomePage\": null, \"assistantName\": null, \"manager\": null, \"homePhones\": [], \"mobilePhone\": null, \"businessPhones\": [], \"spouseName\": null, \"personalNotes\": \"\", \"children\": [], \"emailAddresses\": [ { \"name\": \"christian@mytriplogr.com\", \"address\": \"christian@mytriplogr.com\" } ], \"homeAddress\": {}, \"businessAddress\": {}, \"otherAddress\": {} }, { \"@odata.etag\": \"W/\"EQAAABYAAABdD8QXX8jfRpWW7oGFUMrYAAAcoh / 1\"\", \"id\": \"AAMkAGIwOTljMTMwLTQ2OWMtNDg2Mi04OTY5LWRlZThhNmNmNTk3ZgBGAAAAAAAtZBQgCmGbQqKysnFgAArhBwC7weOxYXjPSbAoBsBbVMHAAAAArIKpAAAydokZcbUSRLmFrIoCceSBAAAvtlpKAAA=\", \"createdDateTime\": \"2016-09-26T06:03:16Z\", \"lastModifiedDateTime\": \"2017-04-05T22:00:16Z\", \"changeKey\": \"EQAAABYAAABdD8QXX8jfRpWW7oGFUMrYAAAcoh/1\", \"categories\": [], \"parentFolderId\": \"AAMkAGIwOTljMTMwLTQ2OWMtNDg2Mi04OTY5LWRlZThhNmNmNTk3ZgAuAAAAAAAtZBQgCmGbQqKysnFgAArhAQC7weOxYXjPSbAoBsBbVMHAAAAArIKpAAA=\", \"birthday\": null, \"fileAs\": \"Bukowska, Milena\", \"displayName\": \"Milena Bukowska\", \"givenName\": \"Milena\", \"initials\": null, \"middleName\": null, \"nickName\": null, \"surname\": \"Bukowska\", \"title\": null, \"yomiGivenName\": null, \"yomiSurname\": null, \"yomiCompanyName\": null, \"generation\": null, \"imAddresses\": [], \"jobTitle\": null, \"companyName\": \"Kevin's Servive\", \"department\": null, \"officeLocation\": null, \"profession\": null, \"businessHomePage\": null, \"assistantName\": null, \"manager\": null, \"homePhones\": [], \"mobilePhone\": \"+47 463 80 915\", \"businessPhones\": [], \"spouseName\": null, \"personalNotes\": \"\", \"children\": [], \"emailAddresses\": [ { \"name\": \"milenabukowska@gmail.com\", \"address\": \"milenabukowska@gmail.com\" } ], \"homeAddress\": {}, \"businessAddress\": {}, \"otherAddress\": {} }, { \"@odata.etag\": \"W/\"EQAAABYAAAAydokZcbUSRLmFrIoCceSBAAAtWrjU\"\", \"id\": \"AAMkAGIwOTljMTMwLTQ2OWMtNDg2Mi04OTY5LWRlZThhNmNmNTk3ZgBGAAAAAAAtZBQgCmGbQqKysnFgAArhBwC7weOxYXjPSbAoBsBbVMHAAAAArIKpAAAydokZcbUSRLmFrIoCceSBAAAtQf9tAAA=\", \"createdDateTime\": \"2016-09-22T16:45:17Z\", \"lastModifiedDateTime\": \"2016-09-22T16:45:18Z\", \"changeKey\": \"EQAAABYAAAAydokZcbUSRLmFrIoCceSBAAAtWrjU\", \"categories\": [], \"parentFolderId\": \"AAMkAGIwOTljMTMwLTQ2OWMtNDg2Mi04OTY5LWRlZThhNmNmNTk3ZgAuAAAAAAAtZBQgCmGbQqKysnFgAArhAQC7weOxYXjPSbAoBsBbVMHAAAAArIKpAAA=\", \"birthday\": null, \"fileAs\": \"Carmen\", \"displayName\": \"Carmen\", \"givenName\": \"Carmen\", \"initials\": null, \"middleName\": null, \"nickName\": null, \"surname\": null, \"title\": null, \"yomiGivenName\": null, \"yomiSurname\": null, \"yomiCompanyName\": null, \"generation\": null, \"imAddresses\": [], \"jobTitle\": null, \"companyName\": null, \"department\": null, \"officeLocation\": null, \"profession\": null, \"businessHomePage\": null, \"assistantName\": null, \"manager\": null, \"homePhones\": [ \"+47 473 83 113\" ], \"mobilePhone\": null, \"businessPhones\": [], \"spouseName\": null, \"personalNotes\": \"\", \"children\": [], \"emailAddresses\": [], \"homeAddress\": {}, \"businessAddress\": {}, \"otherAddress\": {} }, { \"@odata.etag\": \"W/\"EQAAABYAAAAydokZcbUSRLmFrIoCceSBAAAlxAje\"\", \"id\": \"AAMkAGIwOTljMTMwLTQ2OWMtNDg2Mi04OTY5LWRlZThhNmNmNTk3ZgBGAAAAAAAtZBQgCmGbQqKysnFgAArhBwC7weOxYXjPSbAoBsBbVMHAAAAArIKpAAAydokZcbUSRLmFrIoCceSBAAAlrpMoAAA=\", \"createdDateTime\": \"2016-09-14T13:59:56Z\", \"lastModifiedDateTime\": \"2016-09-14T13:59:56Z\", \"changeKey\": \"EQAAABYAAAAydokZcbUSRLmFrIoCceSBAAAlxAje\", \"categories\": [], \"parentFolderId\": \"AAMkAGIwOTljMTMwLTQ2OWMtNDg2Mi04OTY5LWRlZThhNmNmNTk3ZgAuAAAAAAAtZBQgCmGbQqKysnFgAArhAQC7weOxYXjPSbAoBsBbVMHAAAAArIKpAAA=\", \"birthday\": null, \"fileAs\": \"Barnehage\", \"displayName\": \"Barnehage\", \"givenName\": \"Barnehage\", \"initials\": null, \"middleName\": null, \"nickName\": null, \"surname\": null, \"title\": null, \"yomiGivenName\": null, \"yomiSurname\": null, \"yomiCompanyName\": null, \"generation\": null, \"imAddresses\": [], \"jobTitle\": null, \"companyName\": \"Vardefjellet Bhg\", \"department\": null, \"officeLocation\": null, \"profession\": null, \"businessHomePage\": null, \"assistantName\": null, \"manager\": null, \"homePhones\": [], \"mobilePhone\": null, \"businessPhones\": [], \"spouseName\": null, \"personalNotes\": \"\", \"children\": [], \"emailAddresses\": [], \"homeAddress\": {}, \"businessAddress\": {}, \"otherAddress\": {} }, { \"@odata.etag\": \"W/\"EQAAABYAAAADW7IWaYlHSaBcHH4zMU7eAAIGiT / v\"\", \"id\": \"AAMkAGIwOTljMTMwLTQ2OWMtNDg2Mi04OTY5LWRlZThhNmNmNTk3ZgBGAAAAAAAtZBQgCmGbQqKysnFgAArhBwC7weOxYXjPSbAoBsBbVMHAAAAArIKpAAADW7IWaYlHSaBcHH4zMU7eAAIGHW74AAA=\", \"createdDateTime\": \"2016-01-31T01:04:08Z\", \"lastModifiedDateTime\": \"2016-01-31T01:04:08Z\", \"changeKey\": \"EQAAABYAAAADW7IWaYlHSaBcHH4zMU7eAAIGiT/v\", \"categories\": [], \"parentFolderId\": \"AAMkAGIwOTljMTMwLTQ2OWMtNDg2Mi04OTY5LWRlZThhNmNmNTk3ZgAuAAAAAAAtZBQgCmGbQqKysnFgAArhAQC7weOxYXjPSbAoBsBbVMHAAAAArIKpAAA=\", \"birthday\": null, \"fileAs\": \"Terje\", \"displayName\": \"Terje\", \"givenName\": \"Terje\", \"initials\": null, \"middleName\": null, \"nickName\": null, \"surname\": null, \"title\": null, \"yomiGivenName\": null, \"yomiSurname\": null, \"yomiCompanyName\": null, \"generation\": null, \"imAddresses\": [], \"jobTitle\": null, \"companyName\": null, \"department\": null, \"officeLocation\": null, \"profession\": null, \"businessHomePage\": null, \"assistantName\": null, \"manager\": null, \"homePhones\": [], \"mobilePhone\": \"+4792204297\", \"businessPhones\": [], \"spouseName\": null, \"personalNotes\": \"\", \"children\": [], \"emailAddresses\": [], \"homeAddress\": {}, \"businessAddress\": {}, \"otherAddress\": {} }, { \"@odata.etag\": \"W/\"EQAAABYAAAADW7IWaYlHSaBcHH4zMU7eAAIGiT / p\"\", \"id\": \"AAMkAGIwOTljMTMwLTQ2OWMtNDg2Mi04OTY5LWRlZThhNmNmNTk3ZgBGAAAAAAAtZBQgCmGbQqKysnFgAArhBwC7weOxYXjPSbAoBsBbVMHAAAAArIKpAAADW7IWaYlHSaBcHH4zMU7eAAIGHW73AAA=\", \"createdDateTime\": \"2016-01-29T19:15:13Z\", \"lastModifiedDateTime\": \"2016-01-29T19:15:13Z\", \"changeKey\": \"EQAAABYAAAADW7IWaYlHSaBcHH4zMU7eAAIGiT/p\", \"categories\": [], \"parentFolderId\": \"AAMkAGIwOTljMTMwLTQ2OWMtNDg2Mi04OTY5LWRlZThhNmNmNTk3ZgAuAAAAAAAtZBQgCmGbQqKysnFgAArhAQC7weOxYXjPSbAoBsBbVMHAAAAArIKpAAA=\", \"birthday\": null, \"fileAs\": \"taxi Seattle, Pedeo\", \"displayName\": \"Pedeo taxi Seattle\", \"givenName\": \"Pedeo\", \"initials\": null, \"middleName\": null, \"nickName\": null, \"surname\": \"taxi Seattle\", \"title\": null, \"yomiGivenName\": null, \"yomiSurname\": null, \"yomiCompanyName\": null, \"generation\": null, \"imAddresses\": [], \"jobTitle\": null, \"companyName\": null, \"department\": null, \"officeLocation\": null, \"profession\": null, \"businessHomePage\": null, \"assistantName\": null, \"manager\": null, \"homePhones\": [], \"mobilePhone\": \"(206) 734-0576\", \"businessPhones\": [], \"spouseName\": null, \"personalNotes\": \"\", \"children\": [], \"emailAddresses\": [], \"homeAddress\": {}, \"businessAddress\": {}, \"otherAddress\": {} } ] }";

            return Task.FromResult(contactsString);
        }


        public Task<string> GetMyInformationAsync(string bearerToken)
        {
            const string meString = "{ \"@odata.context\": \"https://graph.microsoft.com/v1.0/$metadata#users/$entity\", \"id\": \"6f940512-08bc-4687-b067-2463f1185337\", \"businessPhones\": [ \"+47 (2) 2062823 X2823\" ], \"displayName\": \"Pedro Dias\", \"givenName\": \"Pedro\", \"jobTitle\": \"PRIN TECH EVANGELIST\", \"mail\": \"pedias@microsoft.com\", \"mobilePhone\": \"0047 91698263\", \"officeLocation\": \"OSLO-LYSAKER45/7.27C\", \"preferredLanguage\": null, \"surname\": \"Dias\", \"userPrincipalName\": \"pedias@microsoft.com\" }";

            return Task.FromResult(meString);
        }
    }
}
