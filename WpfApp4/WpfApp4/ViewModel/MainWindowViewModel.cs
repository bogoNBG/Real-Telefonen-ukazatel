using System.Collections.ObjectModel;
using WpfApp4.Model;
using WpfApp4.MVVM;

namespace WpfApp4.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Item> Items { get; set; }

        public RelayCommand AddContactCommand => new(execution => AddContact(), canExecute => CanAddContact());
        public RelayCommand RemoveContactCommand => new(execution => RemoveContact(), canExecute => CanRemoveContact());

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

        public MainWindowViewModel()
        {
            Items = new ObservableCollection<Item>();
        }
       
        private Item? selectedItem;
        public Item? SelectedItem
		{
			get { return selectedItem; }
			set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
		}   
        
        private void AddContact()
        {
            Items.Add(new Item
            {
                Name = this.Name,
                Number = this.Number,
                Email = this.Email
            }
            );

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
            return true;
        }

        private void RemoveContact()
        {
            Items.Remove(SelectedItem);
        }
        private bool CanRemoveContact()
        {
            if (SelectedItem != null){
                return true;
            }
            return false;
        }

    }
}
