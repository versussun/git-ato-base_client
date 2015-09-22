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
using ATOClient.repositories;
using System.ComponentModel;

namespace ATOClient
{
    /// <summary>
    /// Логика взаимодействия для PeplesCollectionDataGrid.xaml
    /// </summary>
    public partial class PeoplesCollectionDataGrid : UserControl
    {
        public static DependencyProperty ItemSourceProperty = DependencyProperty.Register("ItemSource", typeof(CollectionView), typeof(PeoplesCollectionDataGrid),
                null);
        public CollectionViewSource ItemSource
        {
            get { return (CollectionViewSource)GetValue(ItemSourceProperty); }
            set { SetValueDp(ItemSourceProperty, value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void SetValueDp(DependencyProperty property, object value, [System.Runtime.CompilerServices.CallerMemberName] String p = null)
        {
            if (value != null)
            {
                SetValue(property, value);
            }
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }


        public PeoplesCollectionDataGrid()
        {
            InitializeComponent();
        }

        private void dg_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (!Validator.IsValid(sender as DependencyObject))
                {
                    MessageBox.Show("Значени не соотвествует");
                    e.Handled = true;
                }

            }
        }

        private void dg_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!Validator.IsValid(sender as DependencyObject))
            {
                MessageBox.Show("Значени не соотвествует");
                e.Handled = true;
            }
        }

    }
}
