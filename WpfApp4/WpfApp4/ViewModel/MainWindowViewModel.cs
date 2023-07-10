using System.Collections.ObjectModel;
using WpfApp4.Model;
using WpfApp4.MVVM;

namespace WpfApp4.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Item> Items { get; set; }

        public MainWindowViewModel()
        {
            Items = new ObservableCollection<Item>();
            Item item = new Item();
            item.Name = "imence";
            item.SerialNumber = "ewq123ewq";
            item.Quantity = 2;
            Items.Add(item);
        }

		private Item selectedItem;
        public Item SelectedItem
		{
			get { return selectedItem; }
			set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
		}       
    }
}
