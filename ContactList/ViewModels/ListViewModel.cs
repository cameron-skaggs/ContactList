using ContactList.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactList.ViewModels
{
    public class ListViewModel : ObservableObject
    {
        private IContactDataService _service;
        private ContactsViewModel _contactsVM;
        public ContactsViewModel ContactsVM
        {
            get { return _contactsVM; }
            set { OnPropertyChanged(ref _contactsVM, value); }
        }
        public ICommand LoadContactsCommand { get; private set; }

        public ListViewModel(Services.IContactDataService service)
        {
            ContactsVM = new ContactsViewModel(service);

            _service = service;
            LoadContactsCommand = new RelayCommand(LoadContacts);
        }

        private void LoadContacts()
        {
            Console.WriteLine("number of contacts in load contacts " + _service.GetContacts().Count());
            ContactsVM.LoadContacts(_service.GetContacts());
        }
    }

}
