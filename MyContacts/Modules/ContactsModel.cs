using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Modules
{
    public static class CreateRandomContacts
    {
        private static Random random = new Random();
        private static string[] names = new string[]
        {
            "Artyom",
            "Vanya",
            "Egor",
            "Amber",
            "Ilya",
            "Elizabeth",
            "Sam",
            "Vasya",
            "Alice",
            "Cara",
            "Olivia",
            "John",
            "Anna",
            "Sasha",
            null,
            "Emily",
            "Lisa",
            "Petya",
            "Cameron",
            "Zhenya",
            "James",
            "David",
            "Remy",
            "Taylor",
            "Davis",
            "Jennifer",
            "Tarvis",
            "Artour",
            "Gregory",
            null
        };

        private static string[] surNames = new string[]
        {
            "Allyson",
            "Katlinsky",
            "Kolosov",
            "Trump",
            "Einstein",
            "Newton",
            "Svenson",
            "Lennon",
            "Kuzmich",
            null,
            "Ivanchenko",
            "Dale",
            "Dorian",
            "Wilson",
            "McDonald",
            "Cage",
            "Stone",
            "Butler",
            "Butcher",
            "Smith",
            "Jones",
            "House",
            null
        };

        public static Contact[] GetContacts(int amount)
        {
            Contact[] newContacts = new Contact[amount];
            for (int i = 0; i < amount; i++)
            {
                newContacts[i] = new Contact
                {
                    Name = names[random.Next(names.Length)],
                    SurName = surNames[random.Next(surNames.Length)],
                    PhoneNumber = $"+{random.Next(1111111, 9999999).ToString()}"
                };
            }
            return newContacts;
        }
    }
    public class Contact
    {
        private string name = null;
        private string surName = null;
        private string phoneNumber = null;

        
        public string Name
        {
            get
            {
                return name ?? "No Data";
            }
            set
            {
                name = value;
            }
        }

        public string SurName
        {
            get
            {
                return surName ?? "No Data";
            }
            set
            {
                surName = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber ?? "No Data";
            }
            set
            {
                phoneNumber = value;
            }
        }
    }
}
