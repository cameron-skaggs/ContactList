using ContactList.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Services
{
    public interface IContactDataService
    {
        void Save();
        void Add(Contact contact);
        void Delete(Contact contact);
        ObservableCollection<Contact> Contacts { get; }


    }
}
