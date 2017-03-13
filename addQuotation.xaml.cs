using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace prototype2
{
    /// <summary>
    /// Interaction logic for addQuotation.xaml
    /// </summary>
    public partial class addQuotation : Window
    {
        public addQuotation()
        {
            InitializeComponent();
        }
        private static String dbname = "odc_db";
        private void setControlsValues()
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = dbname;
            if (dbCon.IsConnect())
            {
                string query = "SELECT * FROM CUSTOMER_T;";
                MySqlDataAdapter dataAdapter = dbCon.selectQuery(query, dbCon.Connection);
                DataSet fromDb = new DataSet();
                dataAdapter.Fill(fromDb, "t");
                custCb.ItemsSource = fromDb.Tables["t"].DefaultView;
                dbCon.Close();

            }
        }

        private void custCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = dbname;
            if (dbCon.IsConnect())
            {
                string query = query = "SELECT CONCAT(custRepLName,' ,',custRepFname) AS custRepFullName, custRepID FROM CUSTOMER_REP_T WHERE custID = '" + custCb.SelectedValue + "';";
                MySqlDataAdapter dataAdapter = dbCon.selectQuery(query, dbCon.Connection);
                DataSet fromDb = new DataSet();
                dataAdapter.Fill(fromDb, "t");
                custRepCb.ItemsSource = fromDb.Tables["t"].DefaultView;
                dbCon.Close();

            }
        }

        private void addCustBtn_Click(object sender, RoutedEventArgs e)
        {
            addCustomer addCust = new addCustomer();
            addCust.ShowDialog();
            setControlsValues();
        }

        private void salesQuoteWindow_Loaded(object sender, RoutedEventArgs e)
        {
            setControlsValues();
        }

        private void addCustRepBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!(custCb.SelectedIndex < 0))
            {
                addRepresentative addRep = new addRepresentative();
                addRep.custName = custCb.Text;
                addRep.custId = custCb.SelectedValue.ToString();
                addRep.ShowDialog();
            }
            else
            {
                System.Windows.MessageBox.Show("Select a customer first.");
            }

        }
        private ObservableCollection<Item> items = new ObservableCollection<Item>();
        private void addRowBtn_Click(object sender, RoutedEventArgs e)
        {
            var item = new Item();
            items.Add(item);
            itemDg.ItemsSource = items;
        }

        private void percentTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private string vatExcluded;
        private string isLandedPrice;
        private string paymentCurrency;
        private void landedCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            isLandedPrice = "true";
        }
        private void landedCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            isLandedPrice = "false";
        }
        private void vatCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            vatExcluded = "true";
        }
        private void vatCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            vatExcluded = "false";
        }
        private void deliveryCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            deliveryDays.Visibility = Visibility.Visible;
        }

        private void warrantyCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            warrantyTb.Visibility = Visibility.Visible;
        }

        private void deliveryDays_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (deliveryDays.SelectedIndex == 30)
            {
                deliveryDate.Visibility = Visibility.Visible;
            }
        }

        private void warrantyCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            warrantyTb.Visibility = Visibility.Collapsed;
        }

        private void deliveryCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            deliveryDays.Visibility = Visibility.Collapsed;
            deliveryDays.SelectedIndex = 0;
        }
    }


    internal class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        private string _lineNo;
        public string lineNo
        {
            get { return _lineNo; }
            set { SetField(ref _lineNo, value, "Line No"); }
        }
        private string _itemCode;
        public string itemCode
        {
            get { return _itemCode; }
            set { SetField(ref _itemCode, value, "Item Code"); }
        }
        private string _desc;
        public string desc
        {
            get { return _desc; }
            set { SetField(ref _desc, value, "Description"); }
        }
        private string _unit;
        public string unit
        {
            get { return _unit; }
            set { SetField(ref _unit, value, "Unit"); }
        }
        private int _qty;
        public int qty
        {
            get { return _qty; }
            set { SetField(ref _qty, value, "Quantity"); }
        }
        private decimal _unitprice;
        public decimal unitPrice
        {
            get { return _unitprice; }
            set { SetField(ref _unitprice, value, "Unit Price"); }
        }
        private decimal _totalAmount;
        public decimal totalAmount
        {
            get { return _totalAmount; }
            set { SetField(ref _totalAmount, value, "Total Amount"); }
        }
    }
}
