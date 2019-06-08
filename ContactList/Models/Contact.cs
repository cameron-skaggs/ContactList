using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Models
{
    public class Contact : ObservableObject
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { OnPropertyChanged(ref _name, value); }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { OnPropertyChanged(ref _phoneNumber, value);  }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set { OnPropertyChanged(ref _email, value); }
        }
    }
}
