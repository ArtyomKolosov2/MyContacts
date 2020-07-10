using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;
using MyContacts.Modules;
using System.ComponentModel;
using System.Collections.Specialized;

namespace MyContacts
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Contact> contacts;

        private JsonIOservice jsonIO = new JsonIOservice();
        public MainWindow()
        {
            InitializeComponent();
        }

        public void AddContactRange(Contact [] newContacts)
        {
            foreach (var newContact in newContacts)
            {
                if (newContact != null)
                {
                    contacts.Add(newContact);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            contacts = jsonIO.LoadContacts();
            contacts.CollectionChanged += Wait_Change;
            if (contacts.Count <= 0)
            {
                AddContactRange(CreateRandomContacts.GetContacts(45));
            }
            DataGridInfo.ItemsSource = contacts;
        }

        private void Wait_Change(object sender, NotifyCollectionChangedEventArgs e)
        {
            jsonIO.WriteToJsonFile(contacts);
        }
    }
}