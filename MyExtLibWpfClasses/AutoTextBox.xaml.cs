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

namespace MyExtLibWpfClasses
{
    /// <summary>
    /// Логика взаимодействия для AutoTextBox.xaml
    /// </summary>
    public partial class AutoTextBox : UserControl
    {


        public static DependencyProperty MyCollectionProperty = DependencyProperty.Register("MyCollection", typeof(CollectionView), typeof(AutoTextBox),
                null);
        public static DependencyProperty DisplayMemberPathProperty = DependencyProperty.Register("DisplayMemberPath", typeof(string), typeof(AutoTextBox),
            null);
        public static DependencyProperty SelectedObjectProperty = DependencyProperty.Register("SelectedObject", typeof(object), typeof(AutoTextBox), null);

        public CollectionViewSource MyCollection
        {
            get { return (CollectionViewSource)GetValue(MyCollectionProperty); }
            set { SetValueDp(MyCollectionProperty, value); }
        }
        public string DisplayMemberPath
        {
            get { return (string)GetValue(DisplayMemberPathProperty); }
            set { SetValueDp(DisplayMemberPathProperty, value); }
        }
        public object SelectedObject
        {
            get { return (object)GetValue(SelectedObjectProperty); }
            set { SetValueDp(SelectedObjectProperty, value); }
        }





        private bool flagDeleted = false;

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




        public AutoTextBox()
        {
            InitializeComponent();
        }


        private void btnOpenList_Click(object sender, RoutedEventArgs e)
        {
            bool flag = PopUplink.IsOpen;
            PopUplink.IsOpen = !flag;
            Mouse.Capture(PopUplink, CaptureMode.SubTree);
            if (SelectedObject != null)
            {
                ATBLb.SelectedItem = SelectedObject;
            }
        }

        private void tbFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ATBLb == null) { return; }
            //отслеживание нажатия кнопки удаления
            if (flagDeleted)
            {
                flagDeleted = false;
                return;
            }
            //отменить прописку на событие
            tbFilter.TextChanged -= tbFilter_TextChanged;
            //запоминаем позицию курсора
            int caretindex = tbFilter.CaretIndex;
            //получили строку из фильтра
            string text = (sender as TextBox).Text;
            //обрезать строку до курсора
            string textfilter = text;
            //обрезать лишнее
            if (text.Length > caretindex && caretindex != 0)
            {
                textfilter = text.Remove(caretindex);
            }
            tbFilter.Text = textfilter;

            //обнуляем значения 
            string property = "";
            SelectedObject = null;

            foreach (var obj in ATBLb.Items)
            {
                Type t = obj.GetType();

                try
                {
                    property = (string)t.GetProperty(ATBLb.DisplayMemberPath).GetValue(obj);
                }
                catch (Exception ex)
                {

                }

                if (textfilter.Length < property.Length && property.Remove(textfilter.Length).ToLower().Contains(textfilter.ToLower())
                    && textfilter.Length != 0)
                {
                    tbFilter.Text = property;
                    ATBLb.SelectedItem = obj;
                    tbFilter.SelectionStart = caretindex;
                    tbFilter.SelectionLength = tbFilter.Text.Length - caretindex;
                    break;
                }

            }

            //вернуть подписку на событие
            tbFilter.TextChanged += tbFilter_TextChanged;

        }

        private void tbFilter_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                //запоминаем позицию курсора
                int caretindex = tbFilter.CaretIndex;

                tbFilter.TextChanged -= tbFilter_TextChanged;

                if (tbFilter.Text.Length > caretindex)
                {
                    tbFilter.Text = tbFilter.Text.Remove(caretindex);
                }
                tbFilter.CaretIndex = caretindex;

                tbFilter.TextChanged += tbFilter_TextChanged;
                flagDeleted = true;
            }
        }

        private void MyAutoTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (SelectedObject != null)
            {
                Type t = SelectedObject.GetType();

                tbFilter.Text = (string)t.GetProperty(ATBLb.DisplayMemberPath).GetValue(SelectedObject);
            }
        }

        private void ATBLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsLoaded) return;
            SelectedObject = ATBLb.SelectedItem;
            string property = "";
            Type t = ATBLb.SelectedItem.GetType();

            try
            {
                property = (string)t.GetProperty(ATBLb.DisplayMemberPath).GetValue(SelectedObject);
            }
            catch (Exception ex)
            {
                MessageBox.Show("asd");
            }
            tbFilter.Text = property;
            PopUplink.IsOpen = false;
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var uie = e.OriginalSource as UIElement;
                uie.MoveFocus(
                    new TraversalRequest(
                    FocusNavigationDirection.Next));
                PopUplink.IsOpen = false;
            }
        }

        private bool Validation()
        {

            string property = "";
            foreach (var obj in ATBLb.Items)
            {
                Type t = obj.GetType();

                try
                {
                    property = (string)t.GetProperty(ATBLb.DisplayMemberPath).GetValue(obj);
                }
                catch (Exception ex)
                {

                }
                if (property.ToLower().Contains(tbFilter.Text.ToLower()) && tbFilter.Text.Length != 0)
                {
                    tbFilter.Text = property;
                    ATBLb.SelectedItem = obj;

                    return true;
                }

            }
            MessageBox.Show("Совпадения не найдены...");
            PopUplink.IsOpen = true;
            return false;
        }

        private void MyAutoTextBox_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var obj = e.NewFocus as FrameworkElement;

            //исключительная ситуация
            if (obj.Parent == null) return;
            if ((obj.Parent as FrameworkElement).Parent == this)
            {

            }
            else
            {
                if (!Validation())
                {
                    e.Handled = true;
                }
            }
        }

        private void DaDataGridCell_PreviewMouseLeftButton(object sender, MouseButtonEventArgs e)
        {

            DataGridCell cell = sender as DataGridCell;
            if (cell != null && !cell.IsEditing && !cell.IsReadOnly)
            {
                if (!cell.IsFocused)
                {
                    cell.Focus();
                }
                DataGrid dataGrid = FindVisualParent<DataGrid>(cell);
                if (dataGrid != null)
                {
                    if (dataGrid.SelectionUnit != DataGridSelectionUnit.FullRow)
                    {
                        if (!cell.IsSelected)
                            cell.IsSelected = true;
                    }
                    else
                    {
                        DataGridRow row = FindVisualParent<DataGridRow>(cell);
                        if (row != null && !row.IsSelected)
                        {
                            row.IsSelected = true;
                        }
                    }
                }
            }
        }
        static T FindVisualParent<T>(UIElement element) where T : UIElement
        {
            UIElement parent = element;
            while (parent != null)
            {
                T correctlyTyped = parent as T;
                if (correctlyTyped != null)
                {
                    return correctlyTyped;
                }
                parent = VisualTreeHelper.GetParent(parent) as UIElement;
            }
            return null;
        }
    }
}

