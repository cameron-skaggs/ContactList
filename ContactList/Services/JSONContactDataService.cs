using ContactList.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Services
{
    public class JsonContactDataService : IContactDataService
    {
        private const string _dataPath = "Resources/contactdata.json";

        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>(GetContacts());

        public static IEnumerable<Contact> GetContacts()
        {
            if (!File.Exists(_dataPath))
            {
                File.Create(_dataPath).Close();
            }
            var serializedContacts = File.ReadAllText(_dataPath);
            var contacts = JsonConvert.DeserializeObject<IEnumerable<Contact>>(serializedContacts);

            if (contacts == null)
                return new List<Contact>();

            return contacts;
        }
        public void Save()
        {
            var serializedContacts = JsonConvert.SerializeObject(Contacts);
            File.WriteAllText(_dataPath, serializedContacts);
        }
        public void Add(Contact contact)
        {
            Contacts.Add(contact);
            Save();
        }
        public void Delete(Contact contact)
        {
            Contacts.Remove(contact);
            Save();
        }
    }
}