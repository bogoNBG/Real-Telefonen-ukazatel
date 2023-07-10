using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = this;
            entries = new ObservableCollection<string>();
            txtInput = String.Empty;
            InitializeComponent();
        }

        private ObservableCollection<string> entries;

        public ObservableCollection<string> Entries
        {
            get { return entries; }
            set { entries = value; }
        }

        private string txtInput;

        public string TxtInput
        {
            get { return txtInput; }
            set { txtInput = value; }
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(TxtInput))
            Entries.Add(TxtInput);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Entries.Remove((string)lvEntries.SelectedItem);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Entries.Clear();
        }
    }
}
