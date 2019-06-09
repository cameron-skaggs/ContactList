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
        private IContactDataService _dataService;
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
            _dataService = dataService;

            NewContactVM = new NewContactViewModel(dataService);
            ContactsVM = new ContactsViewModel(dataService);
            ListVM = new ListViewModel(dataService, ContactsVM);
            CurrentView = ListVM;
        }

        #region Commands
        public ICommand DeleteContactCommand => new RelayCommand(Delete);
        private void Delete()
        {
            _dataService.Delete(ContactsVM.SelectedContact);
        }
        private bool CanDelete() { return ContactsVM.SelectedContact == null ? false : true; }
        #endregion
    }
}