using ContactList.Services;
using ContactList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactList
{
    public class AppViewModel : ObservableObject
    {
        private object _currentView;
        public object CurrentView

        {
            get { return _currentView; }
            set { OnPropertyChanged(ref _currentView, value); }
        }

        private ListViewModel _listVM;
        public ListViewModel ListVM
        {
            get { return _listVM; }
            set { OnPropertyChanged(ref _listVM, value); }
        }
        private ContactsViewModel _contactsVM;
        public ContactsViewModel ContactsVM
        {
            get { return _contactsVM; }
            set { OnPropertyChanged(ref _contactsVM, value); }
        }
        private NewContactViewModel _newContactVM;
        public NewContactViewModel NewContactVM
        {
            get { return _newContactVM; }
            set { OnPropertyChanged(ref _newContactVM, value); }
        }
        public AppViewModel()
        {
            var dataService = new JsonContactDataService();
            ListVM = new ListViewModel(dataService);
            NewContactVM = new NewContactViewModel(dataService);
            ContactsVM = new ContactsViewModel(dataService);
            CurrentView = ListVM;
        }
    }
}