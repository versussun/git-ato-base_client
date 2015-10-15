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
using ATOClient.model;
using ATOClient.repositories;

namespace ATOClient
{
    /// <summary>
    /// Логика взаимодействия для PeriodCollectionDataGrid.xaml
    /// </summary>
    public partial class PeriodCollectionDataGrid : UserControl
    {
        public BaseRepository<Peoples> peopleRep;
        public BaseRepository<period_in_ATO> periodRep;

        public PeriodCollectionDataGrid()
        {
            InitializeComponent();
            CollectionViewSource cvsPeoples = (CollectionViewSource)FindResource("peoples");
            peopleRep = new BaseRepository<Peoples>();
            cvsPeoples.Source = peopleRep.items;

            CollectionViewSource cvsPeriod = (CollectionViewSource)FindResource("periods");
            periodRep = new BaseRepository<period_in_ATO>();
            cvsPeriod.Source = periodRep.items;
            
            
            
            
        }

        private void scheduleItemsDataGrid_SelectedCellsChanged(object sender,
        System.Windows.Controls.SelectedCellsChangedEventArgs e)
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

            if (e.AddedCells.Count < 1) return;
            var currentCell = e.AddedCells[0];
            string header = (string)currentCell.Column.Header;

            if (currentCell.Column ==
            dg.Columns[1] || currentCell.Column ==
            dg.Columns[2] || currentCell.Column ==
            dg.Columns[3] || currentCell.Column ==
            dg.Columns[4] || currentCell.Column ==
            dg.Columns[4]) 
            {
                dg.BeginEdit();
            }
        }

        
    }
}
