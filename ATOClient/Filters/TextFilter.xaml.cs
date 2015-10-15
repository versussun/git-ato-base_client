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
using ATOClient.model;

namespace ATOClient
{
    /// <summary>
    /// Логика взаимодействия для TextFilter.xaml
    /// </summary>
    public partial class TextFilter : UserControl
    {
        public bool IsEnable = false;
        public string Header = "";
        public TextFilter()
        {
            InitializeComponent();
        }

        public void Fill(BindingExpression be, DataGrid dg)
        {
            CollectionViewSource col = (CollectionViewSource)FindResource("collection");
            Type t = be.ResolvedSource.GetType();
            List<string> str = new List<string>();
            foreach (var obj in dg.Items)
            {
                if (obj.GetType().ToString().Contains("People"))
                    str.Add(t.GetProperty(be.ResolvedSourcePropertyName).GetValue(obj).ToString());
            }
            var colect = from strin in str group strin by strin into newGroup select newGroup;

            List<ItemFilter> items = new List<ItemFilter>();

            foreach (IGrouping<string, string> obj in colect)
            {
                items.Add(new ItemFilter() { Name = obj.Key, IsCheked = true });
            }
            col.Source = items;
            Header = be.ResolvedSourcePropertyName;

        }

        public void Filtering(object sender, FilterEventArgs e)
        {
            if (IsEnable)
            {
                Type t = e.Item.GetType();
                if (t.GetProperty(Header).GetValue(e.Item).ToString().Contains("a") )
                {
                    e.Accepted = true;
                    return;
                }
                e.Accepted = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }


        private void FilterTable_MouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }
    }

    public class ItemFilter
    {
        public string Name { get; set; }
        public bool IsCheked{ get; set; }
    }

}
