using ContactList.Models;
using ContactList.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactList.ViewModels
{
    public class ContactsViewModel : ObservableObject
    {
        public ObservableCollection<Contact> Contacts { get;  }

        private Contact _selectedContact;
        public Contact SelectedContact

        {
            get { return _selectedContact; }
            set
            {
                if (value == null)
                    return;
                OnPropertyChanged(ref _selectedContact, value);
            }
        }
        private IContactDataService _dataService;

        public ContactsViewModel(Services.IContactDataService dataService)
        {
            _dataService = dataService;
            Contacts = dataService.Contacts; 
        }

    }
}
