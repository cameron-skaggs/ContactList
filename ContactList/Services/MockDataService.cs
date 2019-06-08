using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactList.Models;

namespace ContactList.Services
{
    class MockDataService : IContactDataService
    {
        private IEnumerable<Contact> _contacts;

        public MockDataService()
        {
            _contacts = new List<Contact>()
            {
                new Contact
                {
                    Name = "Sergio Faura",
                    PhoneNumber = "123-456-7890",
                    Email = "sergio@srt.com"
                },
                new Contact
                {
                    Name = "Doug Baker",
                    PhoneNumber = "123-456-7890",
                    Email = "doug@srt.com"
                },
                new Contact
                {
                    Name = "Miguel Grullon",
                    PhoneNumber = "123-456-7890",
                    Email = "miguel@srt.com"
                },

            };
        }
        public IEnumerable<Contact> GetContacts()
        {
            return _contacts;
        }

        public void Save(IEnumerable<Contact> contacts)
        {
            _contacts = contacts;
        }
    }
}
