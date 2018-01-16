using OfficeGraphTest.Domain.Contracts;
using System.Configuration;

namespace OfficeGraphTest
{
    public class Settings : ISettings
    {
        public string this[string key]
        {
            get
            {
                return ConfigurationManager.AppSettings.Get(key);
            }
        }
    }
}
