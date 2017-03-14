using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using System.Windows.Shapes;

namespace prototype2
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        private static String dbname = "odc_db";
        private void salesBtn_Click(object sender, RoutedEventArgs e)
        {
            subMenuGrid.Visibility = Visibility.Visible;
            for (int x = 0; x < subMenuGrid.Children.Count; x++)
            {
                subMenuGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            saleSubMenuGrid.Visibility = Visibility.Visible;
        }

        private void serviceBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void inventoryBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void reportsBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dashBoardBtn_Click(object sender, RoutedEventArgs e)
        {
            subMenuGrid.Visibility = Visibility.Collapsed;
            for (int x = 0; x < containerGrid.Children.Count; x++)
            {
                containerGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            dashboardGrid.Visibility = Visibility.Visible;
        }

        private void manageBtn_Click(object sender, RoutedEventArgs e)
        {
            subMenuGrid.Visibility = Visibility.Visible;
            for (int x = 0; x < subMenuGrid.Children.Count; x++)
            {
                subMenuGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            manageSubMenugrid.Visibility = Visibility.Visible;
        }

        

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Visual visual = e.OriginalSource as Visual;
            if (!visual.IsDescendantOf(subMenuGrid))
            subMenuGrid.Visibility = Visibility.Collapsed;
            if (!visual.IsDescendantOf(manageCustomeDataGrid))
            {
                manageCustomeDataGrid.SelectedIndex = -1;
                manageCustomeDataGrid.Columns[manageCustomeDataGrid.Columns.IndexOf(columnEditBtn)].Visibility = Visibility.Hidden;
            }
        }

        private void quotesSalesMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            subMenuGrid.Visibility = Visibility.Collapsed;
            for (int x = 0; x < containerGrid.Children.Count; x++)
            {
                containerGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            transactionGrid.Visibility = Visibility.Visible;
            for (int x = 1; x < transactionQuotationsGrid.Children.Count; x++)
            {
                transactionQuotationsGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            for (int x = 0; x<transactionGrid.Children.Count; x++)
            {
                transactionGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            transactionQuotationsGrid.Visibility = Visibility.Visible;
            quotationsGridHome.Visibility = Visibility.Visible;
            setTransControlValues();

        }

        

        private void ordersSalesMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            subMenuGrid.Visibility = Visibility.Collapsed;
            for (int x = 0; x < containerGrid.Children.Count; x++)
            {
                containerGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            transactionGrid.Visibility = Visibility.Visible;
            for (int x = 0; x < transactionGrid.Children.Count; x++)
            {
                transactionGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            transactionOrdersGrid.Visibility = Visibility.Visible;
        }

        private void invoiceSalesMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            subMenuGrid.Visibility = Visibility.Collapsed;
            for (int x = 0; x < containerGrid.Children.Count; x++)
            {
                containerGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            transactionGrid.Visibility = Visibility.Visible;
            for (int x = 0; x < transactionGrid.Children.Count; x++)
            {
                transactionGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            transactionInvoiceGrid.Visibility = Visibility.Visible;
        }

        private void recieptSalesMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            subMenuGrid.Visibility = Visibility.Collapsed;
            for (int x = 0; x < containerGrid.Children.Count; x++)
            {
                containerGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            transactionGrid.Visibility = Visibility.Visible;
            for (int x = 0; x < transactionGrid.Children.Count; x++)
            {
                transactionGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            transactionReceiptGrid.Visibility = Visibility.Visible;
        }

        private void transQuoteAddBtn_Click(object sender, RoutedEventArgs e)
        {
            for (int x = 1; x < transactionQuotationsGrid.Children.Count; x++)
            {
                transactionQuotationsGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            addRequestionGrid.Visibility = Visibility.Visible;
            setAddTransControlValues();
        }
        private void transRequestBack_Click(object sender, RoutedEventArgs e)
        {
            for (int x = 1; x < transactionQuotationsGrid.Children.Count; x++)
            {
                transactionQuotationsGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            quotationsGridHome.Visibility = Visibility.Visible;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int x = 0; x < containerGrid.Children.Count; x++)
            {
                containerGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            dashboardGrid.Visibility = Visibility.Visible;
            
        }

        private void setAddTransControlValues()
        {
            
            String[] reqTypeArr = { };
            String reqTypeSettings = Properties.Settings.Default.requestType.ToString();
            reqTypeArr = reqTypeSettings.Split(',');
            if (reqType.Items.IsEmpty)
            {
                foreach (String reTypeString in reqTypeArr)
                {
                    reqType.Items.Add(reTypeString);
                }
            }
        }

        private void setTransControlValues()
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
            setTransControlValues();
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
        

        //MANAGE GRID PART

        private void customerManageMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            subMenuGrid.Visibility = Visibility.Collapsed;
            for (int x = 0; x < containerGrid.Children.Count; x++)
            {
                containerGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            manageGrid.Visibility = Visibility.Visible;
            for (int x = 0; x < manageGrid.Children.Count; x++)
            {
                manageGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            manageCustomerGrid.Visibility = Visibility.Visible;
            
        }

        private void setManageGridControls()
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = dbname;
            if (dbCon.IsConnect())
            {
                string query = query = "SELECT c.custID, c.custCompanyName, c.custAddInfo, cc.officePhoneNo, cc.emailAddress, CONCAT(l.locationAddress,' ',p.locProvince) AS custLocation " +
                    "FROM customer_t c JOIN customer_contacts_t cc ON c.custID = cc.custID " +
                    "JOIN location_details_t l ON c.locationID = l.locationID " +
                    "JOIN provinces_t p ON l.locationProvinceID = p.locProvinceId;";
                MySqlDataAdapter dataAdapter = dbCon.selectQuery(query, dbCon.Connection);
                DataSet fromDb = new DataSet();
                dataAdapter.Fill(fromDb, "t");
                manageCustomeDataGrid.ItemsSource = fromDb.Tables["t"].DefaultView;
                dbCon.Close();
            }
        }

        private void btnEditCust_Click(object sender, RoutedEventArgs e)
        {
            if (manageCustomeDataGrid.SelectedItems.Count > 0)
            {
                String id = (manageCustomeDataGrid.Columns[0].GetCellContent(manageCustomeDataGrid.SelectedItem)as TextBlock).Text;
                editCustomer editcustomer = new editCustomer(id);
                editcustomer.ShowDialog();
                setManageGridControls();
            }
            
        }

        private void btnDeleteCust_Click(object sender, RoutedEventArgs e)
        {
            if (manageCustomeDataGrid.SelectedItems.Count > 0)
            {
                String id = (manageCustomeDataGrid.Columns[0].GetCellContent(manageCustomeDataGrid.SelectedItem) as TextBlock).Text;
                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = dbname;
                MessageBoxResult result = MessageBox.Show("Do you want to save this new customer?", "Confirmation", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    
                    if (dbCon.IsConnect())
                    {
                        string query = "DELETE FROM `customer_t` WHERE `custID`= '"+id+"';";
                        if (dbCon.insertQuery(query, dbCon.Connection))
                        {
                            MessageBox.Show("Successfully deleted.");
                        }
                    }

                }
                else if (result == MessageBoxResult.No)
                {
                }
                else if (result == MessageBoxResult.Cancel)
                {
                }
                setManageGridControls();
            }
        }
        private void manageCustomerAddBtn_Click(object sender, RoutedEventArgs e)
        {
            addCustomer addcustomer = new addCustomer();
            addcustomer.ShowDialog();
            setManageGridControls();
        }

        private void manageCustomeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Visual visual = e.OriginalSource as Visual;
            if (visual.IsDescendantOf(manageCustomeDataGrid))
            {
                if (manageCustomeDataGrid.SelectedItems.Count > 0)
                {
                    manageCustomeDataGrid.Columns[manageCustomeDataGrid.Columns.IndexOf(columnEditBtn)].Visibility = Visibility.Visible;
                }
            }
        }

        private void manageCustomerGrid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void manageCustomerGrid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            setManageGridControls();
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
