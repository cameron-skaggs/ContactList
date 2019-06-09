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

        public ListViewModel(Services.IContactDataService service, ContactsViewModel vm)
        {
            ContactsVM = vm;
            _service = service;
        }

    }

}
