using ContactList.Models;
using ContactList.Services;
using ContactList.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ContactList.ViewModels
{
    public class NewContactViewModel : ObservableObject
    {
        
        public Contact NewContact { get; set; } = new Contact { };

        public ICommand OpenNewContactWindowCommand { get; private set; }
        public ICommand SaveContactCommand { get; private set; }
        private IContactDataService _dataService;

        public NewContactViewModel(IContactDataService dataService)
        {
            _dataService = dataService;
            SaveContactCommand = new RelayCommand<Window>(Save);
        }

        private void Save(Window window)
        {
            _dataService.Add(NewContact);
            window.Close();
        }
    }
}
