using System.Windows;
using MyContacts.Modules;
using System.Collections.Specialized;
using System;

namespace MyContacts
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollectionModifed<Contact> contacts;

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
            try
            {
                contacts = jsonIO.LoadContacts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            contacts.CollectionChanged += Collection_Changed;
  
            if (contacts.Count <= 0)
            {
                AddContactRange(CreateRandomContacts.GetContacts(new Random().Next(1, 100)));
            }
            DataGridInfo.ItemsSource = contacts;
        }

        private void Collection_Changed(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                jsonIO.WriteToJsonFile(contacts);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }
    }
}