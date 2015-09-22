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
        public BaseRepository<Peoples> peopleRep;
        public BaseRepository<period_in_ATO> periodRep;
        public BaseRepository<UBD_sertificate> ubdSertRep;
        public MainWindow()
        {
            InitializeComponent();
            peopleRep = new BaseRepository<Peoples>();
            periodRep = new BaseRepository<period_in_ATO>();
            ubdSertRep = new BaseRepository<UBD_sertificate>();

            CollectionViewSource cvsPeoples = (CollectionViewSource)FindResource("peoples");
            CollectionViewSource cvsPeriod = (CollectionViewSource)FindResource("period");
            CollectionViewSource cvsSertificate = (CollectionViewSource)FindResource("ubd_sertificate");
            cvsPeriod.Source = periodRep.items;
            cvsPeoples.Source = peopleRep.items;
            cvsSertificate.Source = ubdSertRep.items;
        }


        private void dgTest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            peopleRep.SaveChages();
            periodRep.SaveChages();
            ubdSertRep.SaveChages();
        }

        
    }
}

