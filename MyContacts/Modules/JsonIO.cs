using System.IO;
using Newtonsoft.Json;

namespace MyContacts.Modules
{
    public class JsonIOservice
    {
        private JsonSerializer serializer = new JsonSerializer();
        public string JsonPath { get; set; } = Directory.GetCurrentDirectory() + "/ContactsInfo.json";
        public void WriteToJsonFile(ObservableCollectionModifed<Contact> contacts)
        {
            using (StreamWriter writer = File.CreateText(JsonPath))
            {
                serializer.Serialize(writer, contacts);
            }
        }

        public ObservableCollectionModifed<Contact> LoadContacts()
        {
            var IsExist = File.Exists(JsonPath);
            ObservableCollectionModifed<Contact> readContacts = new ObservableCollectionModifed<Contact>();
            if (IsExist)
            {
                using (StreamReader reader = File.OpenText(JsonPath))
                {
                    JsonSerializer serializer = new JsonSerializer();

                    readContacts = (ObservableCollectionModifed<Contact>)serializer.Deserialize(reader, readContacts.GetType());
                }
            }
            else
            {
                File.CreateText(JsonPath);
            }
            return readContacts;
        }
    }
}
