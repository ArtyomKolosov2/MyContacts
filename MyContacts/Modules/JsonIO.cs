using System.IO;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace MyContacts.Modules
{
    public class JsonIOservice
    {
        private JsonSerializer serializer = new JsonSerializer();
        public string JsonPath { get; set; } = Directory.GetCurrentDirectory() + "/ContactsInfo.json";
        public void WriteToJsonFile(ObservableCollection<Contact> contacts)
        {
            using (StreamWriter writer = File.CreateText(JsonPath))
            {
                serializer.Serialize(writer, contacts);
            }
        }

        public ObservableCollection<Contact> LoadContacts()
        {
            var IsExist = File.Exists(JsonPath);
            ObservableCollection<Contact> readContacts = new ObservableCollection<Contact>();
            if (IsExist)
            {
                using (StreamReader reader = File.OpenText(JsonPath))
                {
                    JsonSerializer serializer = new JsonSerializer();

                    readContacts = (ObservableCollection<Contact>)serializer.Deserialize(reader, readContacts.GetType());
                }
            }
            return readContacts;
        }
    }
}
