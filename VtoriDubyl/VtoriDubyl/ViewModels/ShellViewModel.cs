using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VtoriDubyl.Commands;
using VtoriDubyl.Models;

namespace VtoriDubyl.ViewModels
{
    public class ShellViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _number;
        private string _email;
        private ICommand _addContactCommand;
        private ICommand _removeContactCommand;
        private Contact _selectedContact;
        private ObservableCollection<Contact> _contacts = new ObservableCollection<Contact>();

        public event PropertyChangedEventHandler PropertyChanged;

        public Contact SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                if (_selectedContact != value)
                {
                    _selectedContact = value;
                }
                this.OnPropertyChanged();
            }
        }
        public ShellViewModel()
        {
            Contacts.Add(new Contact("ime", "nomer", "email"));
        }

        public ObservableCollection<Contact> Contacts
        {
            get { return _contacts; }
            set
            {
                if (_contacts != value)
                {
                    _contacts = value;
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                }

                this.OnPropertyChanged();
            }
        }
        public string Number
        {
            get { return _number; }
            set
            {
                if (_number != value)
                {
                    _number = value;
                }

                this.OnPropertyChanged();
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                }

                this.OnPropertyChanged();
            }
        }
        public ICommand AddContactCommand
        {
            get
            {
                if (_addContactCommand == null)
                {
                    _addContactCommand = new RelayCommand(AddContact, CanAddContact);
                }

                return _addContactCommand;
            }
        }


        public void AddContact(object args)
        {
            Contact contact = new Contact(Name,Number,Email);
            Contacts.Add(contact);
            Name = string.Empty;
            Number = string.Empty;
            Email = string.Empty;
            MessageBox.Show($"{contact.Name} {contact.Number} {contact.Email}");
        }

        public bool CanAddContact(object args)
        {
            return !String.IsNullOrWhiteSpace(Name) && !String.IsNullOrWhiteSpace(Number) && !String.IsNullOrWhiteSpace(Email);
        }

        public ICommand RemoveContactCommand
        {
            get
            {
                if(_removeContactCommand == null)
                {
                    _removeContactCommand = new RelayCommand(RemoveContact, CanRemoveContact);
                }
                return _removeContactCommand;
            }
        }

        public void RemoveContact(object args)
        {
            Contacts.Remove(SelectedContact);
            MessageBox.Show("removed");
        }

        public bool CanRemoveContact(object args)
        {
            return !(SelectedContact==null);
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
