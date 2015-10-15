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

namespace ATOClient
{
    /// <summary>
    /// Логика взаимодействия для DataGridController.xaml
    /// </summary>
    public partial class DataGridController : UserControl
    {
        static public readonly DependencyProperty SelectedIndexProperty =
            DependencyProperty.Register("SelectedIndex", typeof(int), typeof(DataGridController), new PropertyMetadata(false));
        static public readonly DependencyProperty CountCollectionProperty =
            DependencyProperty.Register("CountCollection", typeof(int), typeof(DataGridController), new PropertyMetadata(false));

        public int SelectedIndex
        {
            get { return (int)this.GetValue(SelectedIndexProperty); }
            set { this.SetValue(SelectedIndexProperty, value); }
        } 
        public int CountCollection
        {
            get { return (int)this.GetValue(CountCollectionProperty); }
            set { this.SetValue(CountCollectionProperty, value); }
        }

        public DataGridController()
        {
            InitializeComponent();
        }
        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            Button but = e.Source as Button;
            if (but != null)
            {
                switch (but.Content as String)
                {
                    case "Home":
                        SelectedIndex = 0;
                        break;
                    case "Prev":
                        SelectedIndex--;
                        if (SelectedIndex < 0) SelectedIndex = 0;
                        break;
                    case "Next":
                        SelectedIndex++;
                        if (SelectedIndex > CountCollection) SelectedIndex = CountCollection;
                        break;
                    case "End":
                        SelectedIndex = CountCollection - 1;
                        break;
                }

            }
            (sender as DataGrid).Focus();

        }
    }
}
