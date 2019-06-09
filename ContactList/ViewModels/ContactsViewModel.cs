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
        // This is the Contact which is selected by the user
        private Contact _selectedContact;
        public Contact SelectedContact
        {
            get { return _selectedContact; }
            set { OnPropertyChanged(ref _selectedContact, value); }
        }

        private List<Contact> _contacts;
        public ObservableCollection<Contact> Contacts { get; set; }
        public ICommand DeleteContactCommand { get; private set; }

        private IContactDataService _dataService;

        public ContactsViewModel(Services.IContactDataService dataService)
        {
            _dataService = dataService;
            _contacts = dataService.GetContacts().ToList();
            Console.WriteLine("In ContactsVM");
            DeleteContactCommand = new RelayCommand(Delete);
        }

        private void Delete()
        {
            SelectedContact = _selectedContact;
            Console.WriteLine("In delete");
            Contacts = new ObservableCollection<Contact>(_contacts);
            Console.WriteLine("Bout to delete " + SelectedContact.Name);
            Contacts.Remove(SelectedContact);
        }
        private bool CanDelete(){ return SelectedContact == null ? false : true; }

        public void LoadContacts(IEnumerable<Contact> contacts)
        {
            Contacts = new ObservableCollection<Contact>(contacts);
            OnPropertyChanged("Contacts");
        }
    }
}
