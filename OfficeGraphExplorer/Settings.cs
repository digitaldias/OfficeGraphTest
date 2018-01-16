using OfficeGraphTest.Domain.Contracts;
using System.Configuration;

namespace OfficeGraphExplorer
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
