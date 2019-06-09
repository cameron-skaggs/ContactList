using ContactList.Models;
using ContactList.Services;
using ContactList.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactList.ViewModels
{
    public class NewContactViewModel : ObservableObject
    {
        
        public static string NewName { get; set; }
        public static string NewPhoneNumber { get; set; }
        public static string NewEmail { get; set; }

        public ICommand OpenNewContactWindowCommand { get; private set; }
        public ICommand SaveContactCommand { get; private set; }
        private IContactDataService _dataService;


        public NewContactViewModel(IContactDataService dataService)
        {
            _dataService = dataService;
            OpenNewContactWindowCommand = new RelayCommand(showNewContact);
            SaveContactCommand = new RelayCommand(Save);
        }

        private void showNewContact()
        {
            NewContact newContact = new NewContact();
            newContact.DataContext = this;
            newContact.Show();
        }

        private void Save()
        {
            Contact NewContact = new Contact
            {
                Name = NewName,
                PhoneNumber = NewPhoneNumber,
                Email = NewEmail
            };
            _dataService.Add(NewContact);
            
        }
    }
}
