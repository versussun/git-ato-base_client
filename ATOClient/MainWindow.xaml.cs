using System;
using System.Data;
using System.Data.Objects;
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
using ATOClient.model;
using ATOClient.repositories;




namespace ATOClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool IsOpenAllTables = true;
        public int TabControlSelectedIndex;
        
        public MainWindow()
        {
            InitializeComponent();
            AddAlphabet();
            AddATO();
            AddSertificateUBD();
        }

        public void AddAlphabet()
        {
            TreeViewItem items = new TreeViewItem();
            items.Header = "таблица Алфавитка";
            items.Tag = new PeoplesCollectionDataGrid();
            Alphabet.Items.Add(items);
        }

        public void AddATO()
        {
            TreeViewItem items = new TreeViewItem();
            items.Header = "Таблица период в АТО";
            items.Tag = new PeriodCollectionDataGrid();
            UBD.Items.Add(items);
        }
        public void AddSertificateUBD()
        {
            TreeViewItem items = new TreeViewItem();
            items.Header = "Таблица удостоверение УБД";
            items.Tag = new UBDSertifCollectionDataGrid();
            UBD.Items.Add(items);
        }



        private void bAllTablesCollaps_Click(object sender, RoutedEventArgs e)
        {
            if (!IsOpenAllTables)
            {
                ColumnAllTables.Width = new GridLength(200);
            }
            else
            {
                ColumnAllTables.Width = new GridLength(25);
            }
            IsOpenAllTables = !IsOpenAllTables;

        }

        private void TreeViewTables_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TreeView tvi = sender as TreeView;
            for (var i = 0; i < TabControl.Items.Count; i++)
            {
                if ((TabControl.Items[i] as TabItem).Content == (tvi.SelectedItem as TreeViewItem).Tag)
                {
                    TabControl.SelectedItem = TabControl.Items[i];
                    return;
                }
            }
            if ((tvi.SelectedItem as TreeViewItem)!= null&& (tvi.SelectedItem as TreeViewItem).Tag != null)
            {
                TabItem item = new TabItem();

                StackPanel sp = new StackPanel();
                sp.Orientation = Orientation.Horizontal;
                Button bclose= new Button() { Content="X"};
                bclose.Click += Bclose_Click;
                
                sp.Children.Add(new TextBlock() { Text = ((tvi.SelectedItem as TreeViewItem).Header.ToString()) });
                sp.Children.Add(bclose);

                item.Header = sp;
                bclose.Tag = item;

                item.Content = (tvi.SelectedItem as TreeViewItem).Tag;
                TabControl.Items.Add(item);
                TabControl.SelectedItem = item;
                TabControlSelectedIndex = TabControl.SelectedIndex;
            }
        }

        private void Bclose_Click(object sender, RoutedEventArgs e)
        {
            if (!Validator.IsValid(TabControl))
            {
                MessageBox.Show("Данные не могут быть внесены!!!!");
                return; 
            }
            TabControl.Items.Remove((sender as Button).Tag);
        }
    }
}

