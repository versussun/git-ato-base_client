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
using ATOClient.Filters;

namespace ATOClient
{
    /// <summary>
    /// Логика взаимодействия для TextFilter.xaml
    /// </summary>
    public partial class TextFilter : UserControl, IFilter
    {
        public bool IsAplly = false;
        public string Header = "";
        public List<ItemFilter> FilterCollection;
        public CollectionViewSource col;

        public TextFilter()
        {
            InitializeComponent();
            FilterCollection = new List<ItemFilter>();
            col = (CollectionViewSource)FindResource("collection");
            FilterCollection.Add(new ItemFilter() {Name = "Выделить все...", IsCheked = true });
        }

        public void Fill(BindingExpression be, DataGrid dg)
        {
            
            Type t = be.ResolvedSource.GetType();
            List<string> str = new List<string>();
            foreach (var obj in dg.Items)
            {
                if (obj.GetType().ToString().Contains("People"))
                    str.Add(t.GetProperty(be.ResolvedSourcePropertyName).GetValue(obj).ToString());
            }
            var colect = from strin in str group strin by strin into newGroup select newGroup;

            FilterCollection = new List<ItemFilter>();

            foreach (IGrouping<string, string> obj in colect)
            {
                FilterCollection.Add(new ItemFilter() { Name = obj.Key, IsCheked = true });
            }
            FilterCollection.Sort((a,b)=>a.Name.CompareTo(b.Name));

            col.Source = FilterCollection;
            Header = be.ResolvedSourcePropertyName;

        }

        public void BodyFilter(object sender, FilterEventArgs e)
        {
            Type t = e.Item.GetType();
            foreach(ItemFilter obj in FilterCollection)
            {
                if (obj.IsCheked && t.GetProperty(Header).GetValue(e.Item).ToString().Equals(obj.Name) )
                {
                    e.Accepted = true;
                    return;
                }

            }
            e.Accepted = false;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button bt = e.OriginalSource as Button;
            if (bt != null)
            {
                switch (bt.Name)
                {
                    case "bOk":
                        IsAplly = true;
                        break;
                    case "bCancel":
                        IsAplly = false;
                        break;
                    default:
                        IsAplly = false;
                        break;
                }
                (this.Parent as ContextMenu).IsOpen = false;
            }
            
        }


        private void FilterTable_MouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        public bool GetIsApply()
        {
            return IsAplly;
        }

        public string GetHeaderName()
        {
            return Header;
        }

        public int GetCountFlters()
        {
            return FilterCollection.Count;
        }

        public void CopyFromOld(IFilter old)
        {
            foreach (var obj in FilterCollection)
            {
                foreach (var oldObj in old.GetFilterCollection())
                {
                    if (obj.Name.Equals(oldObj.Name))
                    {
                        obj.IsCheked = oldObj.IsCheked;
                    }
                }
            }
        }

        public List<ItemFilter> GetFilterCollection()
        {
            return FilterCollection;
        }
    }

    public class ItemFilter
    {
        public string Name { get; set; }
        public bool IsCheked{ get; set; }
    }

}
