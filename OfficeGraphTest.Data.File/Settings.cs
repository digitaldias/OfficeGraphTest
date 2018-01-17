using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeGraphTest.Domain.Contracts;
using System;
using System.IO;

namespace OfficeGraphTest.Data.File
{
    /// <summary>
    /// Assumes an OfficeGraphTest.settings.json file exists under current user's "My Documents" folder
    /// </summary>
    public class Settings : ISettings
    {
        private const string SETTINGS_FILENAME = "OfficeGraphTest.settings.json";

        private JObject _jObject; 


        public string this[string key]
        {
            get
            {
                if (_jObject == null)
                    LoadJObjectFromMyDocuments();

                if (_jObject.ContainsKey(key))
                    return _jObject[key].Value<string>();

                return string.Empty;
            }
        }


        private void LoadJObjectFromMyDocuments()
        {
            var completeFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), SETTINGS_FILENAME);
            if (!System.IO.File.Exists(completeFilePath))
                throw new InvalidProgramException($"Unable to locate '{completeFilePath}'. Make sure that it is saved under 'My Documents'");

            var fileContents = System.IO.File.ReadAllText(completeFilePath);
            if(string.IsNullOrEmpty(fileContents))
                throw new InvalidProgramException($"'{completeFilePath}' appears to be empty");

            _jObject = JsonConvert.DeserializeObject<JObject>(fileContents);
        }
    }
}
