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
using System.ComponentModel;

namespace ATOClient
{
    /// <summary>
    /// Логика взаимодействия для PeriodCollectionDataGrid.xaml
    /// </summary>
    public partial class PeriodCollectionDataGrid : UserControl
    {
        public static DependencyProperty ItemSourceProperty =
            DependencyProperty.Register("ItemSource", typeof(CollectionView),
                typeof(PeriodCollectionDataGrid), null);
        public CollectionViewSource ItemSource
        {
            get { return (CollectionViewSource)GetValue(ItemSourceProperty); }
            set { SetValueDp(ItemSourceProperty, value); }
        }

        public static DependencyProperty PeopleDictionaryProperty =
            DependencyProperty.Register("PeopleDictionary", typeof(CollectionView),
                typeof(PeriodCollectionDataGrid), null);
        public CollectionViewSource PeopleDictionary
        {
            get { return (CollectionViewSource)GetValue(PeopleDictionaryProperty); }
            set { SetValueDp(PeopleDictionaryProperty, value); }
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

        public PeriodCollectionDataGrid()
        {
            InitializeComponent();
        }
        private void scheduleItemsDataGrid_SelectedCellsChanged(object sender,
        System.Windows.Controls.SelectedCellsChangedEventArgs e)
        {
            if (e.AddedCells.Count == 0) return;
            var currentCell = e.AddedCells[0];
            string header = (string)currentCell.Column.Header;

            if (currentCell.Column ==
            dg.Columns[1] || currentCell.Column ==
            dg.Columns[2] || currentCell.Column ==
            dg.Columns[4])
            {
                dg.BeginEdit();
            }
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
                else
                {
                    if (e.Key == Key.Enter)
                    {
                        e.Handled = true;
                        SendKeys.Send(Key.Tab);

                    }
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
