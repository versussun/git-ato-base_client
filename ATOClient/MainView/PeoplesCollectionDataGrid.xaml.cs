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
        public BaseRepository<Peoples> peopleRep;
        CollectionViewSource cvsPeoples;

        public bool Selected = false;

        public PeoplesCollectionDataGrid()
        {
            InitializeComponent();
            
            cvsPeoples = (CollectionViewSource)FindResource("peoples");
            peopleRep = new BaseRepository<Peoples>();
            cvsPeoples.Source = peopleRep.items;
            tbPosElem.Text = (dg.SelectedIndex + 1).ToString() + " из " + (dg.Items.Count).ToString();
        }

        private void dg_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (!Validator.IsValid(dg))
            {
                DataGridRow dr = (Validator.GetErrorElement(dg) as DataGridRow);
                if (dr != null)
                {
                    dg.SelectedItem = dr.Item;
                    UIElement eu = dr as UIElement;
                    eu.MoveFocus(new TraversalRequest(FocusNavigationDirection.Left));
                    dg.BeginEdit();
                }
                else
                {
                    MessageBox.Show(sender.GetType().ToString());
                }
            }
            tbPosElem.Text = (dg.SelectedIndex+1).ToString() + " из " + (dg.Items.Count).ToString();
        }

        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            Button but = e.Source as Button;
            if (but != null)
            {
                switch (but.Content as String)
                {
                    case "Home":
                        dg.SelectedIndex = 0;
                        break;
                    case "Prev":
                        dg.SelectedIndex--;
                        if (dg.SelectedIndex < 0) dg.SelectedIndex = 0;
                        break;
                    case "Next":
                        dg.SelectedIndex++;
                        if (dg.SelectedIndex > dg.Items.Count) dg.SelectedIndex = dg.Items.Count;
                        break;
                    case "End":
                        dg.SelectedIndex = dg.Items.Count-1;
                        break;
                }
                
            }
            dg.Focus();
            
        }

        private void Cell_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            TextBlock tb = e.OriginalSource as TextBlock;
            BindingExpression be = tb.GetBindingExpression(TextBlock.TextProperty);
            TextFilter tf = new TextFilter();
            tf.Fill(be, dg);

            (sender as DataGridCell).ContextMenu.Items.Clear();
            (sender as DataGridCell).ContextMenu.Items.Add(tf);

        }
        private void Cell_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            TextFilter tf=(sender as DataGridCell).ContextMenu.Items.GetItemAt(0) as TextFilter;
            tf.IsEnable = true;
            cvsPeoples.Filter += tf.Filtering;
            
        }
    }
}
