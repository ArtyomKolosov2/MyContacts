using System.IO;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.ComponentModel;

namespace MyContacts.Modules
{
    public class JsonIOservice
    {
        private JsonSerializer serializer = new JsonSerializer();
        public string JsonPath { get; set; } = Directory.GetCurrentDirectory() + "/ContactsInfo.json";

        public void WriteToJsonFile(object contacts)
        {
            using (StreamWriter writer = File.CreateText(JsonPath))
            {
                serializer.Serialize(writer, contacts);
            }
        }

        public BindingList<Contact> LoadContacts()
        {
            var IsExist = File.Exists(JsonPath);
            BindingList<Contact> readContacts = new BindingList<Contact>();
            if (IsExist)
            {
                using (StreamReader reader = File.OpenText(JsonPath))
                {
                    JsonSerializer serializer = new JsonSerializer();

                    readContacts = (BindingList<Contact>)serializer.Deserialize(reader, readContacts.GetType());
                }
            }
            return readContacts;
        }
    }
}
