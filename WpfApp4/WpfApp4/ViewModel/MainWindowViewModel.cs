using System;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using WpfApp4.Model;
using WpfApp4.MVVM;

namespace WpfApp4.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Contact> Contacts { get; set; }
        public ObservableCollection<string> Options { get; set; }

        public RelayCommand AddContactCommand => new(execution => AddContact(), canExecute => CanAddContact());
        public RelayCommand RemoveContactCommand => new(execution => RemoveContact(), canExecute => CanRemoveContact());
        public RelayCommand AddOptionCommand => new(execution => AddOption(), canExecute => CanAddOption());
        public RelayCommand RemoveOptionCommand => new(execution => RemoveOption(), canExecute => CanRemoveOption());

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

        private string option;

        public string Option
        {
            get { return option; }
            set 
            {
                option = value;
                OnPropertyChanged();
            }
        }


        public MainWindowViewModel()
        {
            Contacts = new ObservableCollection<Contact>();
            Options = new ObservableCollection<string>();
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

        private string selectedOption;
        public string SelectedOption
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
            Options.Add(Option);
            Option = "";
        }
        private bool CanAddOption()
        {
            if(!string.IsNullOrWhiteSpace(Option))
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
    }
}
