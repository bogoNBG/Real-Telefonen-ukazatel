using System;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using WpfApp4.Model;
using WpfApp4.MVVM;

namespace WpfApp4.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Contacts = new ObservableCollection<Contact>();
            ShownContacts = Contacts;
            Options = new ObservableCollection<Option>();
        }
        public ObservableCollection<Contact> Contacts { get; set; }
        public ObservableCollection<Option> Options { get; set; }

        public RelayCommand AddContactCommand => new(execution => AddContact(), canExecute => CanAddContact());
        public RelayCommand RemoveContactCommand => new(execution => RemoveContact(), canExecute => CanRemoveContact());
        public RelayCommand AddOptionCommand => new(execution => AddOption(), canExecute => CanAddOption());
        public RelayCommand RemoveOptionCommand => new(execution => RemoveOption(), canExecute => CanRemoveOption());
        public RelayCommand SearchCommand => new(execution => SearchContacts());

        private string name;
        public string Name
        {
            get { return name; }
            set 
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private string number;
        public string Number
        {
            get { return number; }
            set 
            { 
                number = value;
                OnPropertyChanged();
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set 
            { 
                email = value;
                OnPropertyChanged();
            }
        }

        private string optionName;
        public string OptionName
        {
            get { return optionName; }
            set 
            {
                optionName = value;
                OnPropertyChanged();
            }
        }

        private string searchedContact;
        public string SearchedContact
        {
            get { return searchedContact; }
            set 
            { 
                searchedContact = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Contact> shownContacts;
        public ObservableCollection<Contact> ShownContacts
        {
            get { return shownContacts; }
            set
            {
                shownContacts = value;
                OnPropertyChanged();
            }
        }


        private Contact? selectedContact;
        public Contact? SelectedContact
		{
			get { return selectedContact; }
			set
            {
                selectedContact = value;
                OnPropertyChanged();
            }
		}

        private Option selectedOption;
        public Option SelectedOption
        {
            get { return selectedOption; }
            set 
            {
                selectedOption = value;
                OnPropertyChanged();
            }
        }


        private void AddContact()
        {
            Contacts.Add(new Contact(this.Name,this.Number,this.Email));

            Name = "";
            Number = "";
            Email = "";
        }

        private bool CanAddContact()
        {
            if (!string.IsNullOrWhiteSpace(Name) & !string.IsNullOrWhiteSpace(Number) && !string.IsNullOrWhiteSpace(Email))
            {
                return true;
            }
            return false;
        }

        private void RemoveContact()
        {
            Contacts.Remove(SelectedContact);
        }
        private bool CanRemoveContact()
        {
            if (SelectedContact != null){
                return true;
            }
            return false;
        }

        private void AddOption()
        {
            Options.Add(new Option(this.OptionName));
            OptionName = "";
        }
        private bool CanAddOption()
        {
            if(!string.IsNullOrWhiteSpace(OptionName))
            {
                return true;
            }
            return false;
        }

        private void RemoveOption()
        {
            Options.Remove(SelectedOption);
        }
        private bool CanRemoveOption()
        {
            if(SelectedOption != null)
            {
                return true;
            }
            return false;
        }

        private void SearchContacts()
        {
            if (string.IsNullOrEmpty(SearchedContact))
            {
                ShownContacts = Contacts;
            }
            else
            {
                ShownContacts = new ObservableCollection<Contact>(
                    Contacts.Where(c => c.Name.Contains(SearchedContact))
                    
                ) ;
            }
        }

    }
}
