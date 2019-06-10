using ContactList.Services;
using ContactList.ViewModels;
using ContactList.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactList
{
    //This ViewModel should act as a "central hub" for all my other view models
    public class AppViewModel : ObservableObject
    {
        private IContactDataService _dataService;

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
            _dataService = dataService;

            NewContactVM = new NewContactViewModel(dataService);
            ContactsVM = new ContactsViewModel(dataService);
            ListVM = new ListViewModel(dataService, ContactsVM);

        }

        #region Commands
        public ICommand DeleteContactCommand => new RelayCommand(Delete);
        private void Delete()
        {
            _dataService.Delete(ContactsVM.SelectedContact);
        }
        private bool CanDelete() { return ContactsVM.SelectedContact == null ? false : true; }

        public ICommand OpenNewContactWindowCommand => new RelayCommand(showNewContact);
        
        private void showNewContact()
        {
            NewContact newContact = new NewContact();
            newContact.DataContext = new NewContactViewModel(_dataService);
            newContact.Show();
        }

        #endregion
    }

}