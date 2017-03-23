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
            subMenuGrid.Visibility = Visibility.Collapsed;
            for (int x = 0; x < containerGrid.Children.Count; x++)
            {
                containerGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            servicesGrid.Visibility = Visibility.Visible;
        }

        private void inventoryBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void reportsBtn_Click(object sender, RoutedEventArgs e)
        {
            subMenuGrid.Visibility = Visibility.Collapsed;
            for (int x = 0; x < containerGrid.Children.Count; x++)
            {
                containerGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            reportsGrid.Visibility = Visibility.Visible;
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
                manageCustomeDataGrid.Columns[manageCustomeDataGrid.Columns.IndexOf(columnEditCustBtn)].Visibility = Visibility.Hidden;
                manageCustomeDataGrid.Columns[manageCustomeDataGrid.Columns.IndexOf(columnDeleteCustBtn)].Visibility = Visibility.Hidden;
            }
            if (!visual.IsDescendantOf(manageEmployeeDataGrid))
            {
                if (manageEmployeeDataGrid.SelectedItems.Count > 0)
                {
                    manageEmployeeDataGrid.Columns[manageEmployeeDataGrid.Columns.IndexOf(columnEditBtnEmp)].Visibility = Visibility.Hidden;
                    manageEmployeeDataGrid.Columns[manageEmployeeDataGrid.Columns.IndexOf(columnDelBtnEmp)].Visibility = Visibility.Hidden;
                }
            }
            if (!visual.IsDescendantOf(manageSupplierDataGrid))
            {
                if (manageSupplierDataGrid.SelectedItems.Count > 0)
                {
                    manageSupplierDataGrid.Columns[manageSupplierDataGrid.Columns.IndexOf(columnEditSuppBtn)].Visibility = Visibility.Hidden;
                    manageSupplierDataGrid.Columns[manageSupplierDataGrid.Columns.IndexOf(columnDeleteSuppBtn)].Visibility = Visibility.Hidden;
                }
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
            MessageBoxResult result = MessageBox.Show("Do you want to cancel this transaction?", "Confirmation", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                for (int x = 1; x < transactionQuotationsGrid.Children.Count; x++)
                {
                    transactionQuotationsGrid.Children[x].Visibility = Visibility.Collapsed;
                }
                quotationsGridHome.Visibility = Visibility.Visible;
            }
            else if (result == MessageBoxResult.No)
            {

            }
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
            reqTypeSettings = Properties.Settings.Default.serviceType.ToString();
            reqTypeArr = reqTypeSettings.Split(',');
            if (typesOfService.Items.IsEmpty)
            {
                foreach (String reTypeString in reqTypeArr)
                {
                    typesOfService.Items.Add(reTypeString);
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

        private void setManageCustomerGridControls()
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = dbname;
            if (dbCon.IsConnect())
            {
                string query = query = "SELECT c.custID, c.custCompanyName, c.custAddInfo, cc.officePhoneNo, cc.emailAddress, CONCAT(l.locationAddress,' ',cp.cityName,' ',p.locProvince) AS custLocation " +
                    "FROM customer_t c JOIN customer_contacts_t cc ON c.custID = cc.custID " +
                    "JOIN location_details_t l ON c.locationID = l.locationID " +
                    "JOIN provinces_t p ON l.locationProvinceID = p.locProvinceId " +
                    "JOIN city_by_province_t cp ON l.locationCityID = cp.cityID " +
                    "WHERE isDeleted = 0;";
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
                setManageCustomerGridControls();
            }
            
        }

        private void btnDeleteCust_Click(object sender, RoutedEventArgs e)
        {
            if (manageCustomeDataGrid.SelectedItems.Count > 0)
            {
                String id = (manageCustomeDataGrid.Columns[0].GetCellContent(manageCustomeDataGrid.SelectedItem) as TextBlock).Text;
                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = dbname;
                MessageBoxResult result = MessageBox.Show("Do you want to delete this customer?", "Confirmation", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    if (dbCon.IsConnect())
                    {
                        string query = "UPDATE `customer_t` SET `isDeleted`= 1 WHERE custID = '"+id+"';";
                        if (dbCon.insertQuery(query, dbCon.Connection))
                        {
                            MessageBox.Show("Successfully deleted.");
                            setManageCustomerGridControls();
                        }
                    }

                }
                else if (result == MessageBoxResult.No)
                {
                }
                else if (result == MessageBoxResult.Cancel)
                {
                }
                setManageCustomerGridControls();
            }
        }
        private void manageCustomerAddBtn_Click(object sender, RoutedEventArgs e)
        {
            addCustomer addCustomer = new addCustomer();
            addCustomer.ShowDialog();
            setManageCustomerGridControls();
        }

        private void manageCustomeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Visual visual = e.OriginalSource as Visual;
            if (visual.IsDescendantOf(manageCustomeDataGrid))
            {
                if (manageCustomeDataGrid.SelectedItems.Count > 0)
                {
                    manageCustomeDataGrid.Columns[manageCustomeDataGrid.Columns.IndexOf(columnEditCustBtn)].Visibility = Visibility.Visible;
                    manageCustomeDataGrid.Columns[manageCustomeDataGrid.Columns.IndexOf(columnDeleteCustBtn)].Visibility = Visibility.Visible;
                }
            }
        }


        private void manageCustomerGrid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            setManageCustomerGridControls();
        }

        private void manageEmployeeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Visual visual = e.OriginalSource as Visual;
            if (visual.IsDescendantOf(manageEmployeeDataGrid))
            {
                if (manageEmployeeDataGrid.SelectedItems.Count > 0)
                {
                    manageEmployeeDataGrid.Columns[manageEmployeeDataGrid.Columns.IndexOf(columnEditBtnEmp)].Visibility = Visibility.Visible;
                    manageEmployeeDataGrid.Columns[manageEmployeeDataGrid.Columns.IndexOf(columnDelBtnEmp)].Visibility = Visibility.Visible;
                }
            }
        }

        private void manageEmployeeDataGrid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            setManageEmployeeGridControls();
        }

        private void setManageEmployeeGridControls()
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = dbname;
            if (dbCon.IsConnect())
            {
                string query = query = "SELECT e.empID, CONCAT(e.empFName,' ',e.empMi,'. ',e.empLname) AS empName,ept.positionName, e.empContacts, e.empEmail, CONCAT(l.locationAddress,' ',cp.cityName,' ',p.locProvince) as empAddress " +
                    "FROM employee_t e " +
                    "JOIN location_details_t l ON e.locationID = l.locationID " +
                    "JOIN emp_position_t ept ON e.positionID = ept.positionId " +
                    "JOIN provinces_t p ON l.locationProvinceID = p.locProvinceId " +
                    "JOIN city_by_province_t cp ON l.locationCityID = cp.cityID " +
                    "WHERE isDeleted = 0;";
                MySqlDataAdapter dataAdapter = dbCon.selectQuery(query, dbCon.Connection);
                DataSet fromDb = new DataSet();
                dataAdapter.Fill(fromDb, "t");
                manageEmployeeDataGrid.ItemsSource = fromDb.Tables["t"].DefaultView;
                dbCon.Close();
            }
        }

        private void manageEmployeeAddBtn_Click(object sender, RoutedEventArgs e)
        {
            addEmployee addEmployee = new addEmployee();
            addEmployee.ShowDialog();
            setManageEmployeeGridControls();
        }

        private void btnEditEmp_Click(object sender, RoutedEventArgs e)
        {
            if (manageEmployeeDataGrid.SelectedItems.Count > 0)
            {
                String id = (manageEmployeeDataGrid.Columns[0].GetCellContent(manageEmployeeDataGrid.SelectedItem) as TextBlock).Text;
                editEmployee editEmployee = new editEmployee(id);
                editEmployee.ShowDialog();
                setManageEmployeeGridControls();
            }
        }

        private void btnDeleteEmp_Click(object sender, RoutedEventArgs e)
        {
            if (manageEmployeeDataGrid.SelectedItems.Count > 0)
            {
                String id = (manageEmployeeDataGrid.Columns[0].GetCellContent(manageEmployeeDataGrid.SelectedItem) as TextBlock).Text;
                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = dbname;
                MessageBoxResult result = MessageBox.Show("Do you want to delete this customer?", "Confirmation", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    if (dbCon.IsConnect())
                    {
                        string query = "UPDATE `employee_t` SET `isDeleted`= 1 WHERE empID = '" + id + "';";
                        if (dbCon.insertQuery(query, dbCon.Connection))
                        {
                            MessageBox.Show("Successfully deleted.");
                            setManageEmployeeGridControls();
                        }
                    }

                }
                else if (result == MessageBoxResult.No)
                {
                }
                else if (result == MessageBoxResult.Cancel)
                {
                }
                setManageCustomerGridControls();
            }
        }

        private void employeeManageMenuBtn_Click(object sender, RoutedEventArgs e)
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
            manageEmployeeGrid.Visibility = Visibility.Visible;
        }

        private void supplierManageMenuBtn_Click(object sender, RoutedEventArgs e)
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
            manageSupplierGrid.Visibility = Visibility.Visible;
        }

        private void manageSupplierGrid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            setManageSupplierGridControls();
        }

        private void setManageSupplierGridControls()
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = dbname;
            if (dbCon.IsConnect())
            {
                string query = query = "SELECT c.suppID, c.suppCompanyName, c.suppAddInfo, cc.sOfficeNo, cc.sEmailAddress, CONCAT(l.locationAddress,' ',cp.cityName,' ',p.locProvince) AS suppLocation " +
                    "FROM supplier_t c JOIN supplier_contacts_t cc ON c.suppID = cc.suppID " +
                    "JOIN location_details_t l ON c.locationID = l.locationID " +
                    "JOIN provinces_t p ON l.locationProvinceID = p.locProvinceId " +
                    "JOIN city_by_province_t cp ON l.locationCityID = cp.cityID " +
                    "WHERE isDeleted = 0;";
                MySqlDataAdapter dataAdapter = dbCon.selectQuery(query, dbCon.Connection);
                DataSet fromDb = new DataSet();
                dataAdapter.Fill(fromDb, "t");
                manageSupplierDataGrid.ItemsSource = fromDb.Tables["t"].DefaultView;
                dbCon.Close();
            }
        }

        private void btnEditSupp_Click(object sender, RoutedEventArgs e)
        {
            if (manageSupplierDataGrid.SelectedItems.Count > 0)
            {
                String id = (manageSupplierDataGrid.Columns[0].GetCellContent(manageSupplierDataGrid.SelectedItem) as TextBlock).Text;
                editSupplier editSupplier = new editSupplier(id);
                editSupplier.ShowDialog();
                setManageSupplierGridControls();
            }
            
        }

        private void btnDeleteSupp_Click(object sender, RoutedEventArgs e)
        {
            if (manageSupplierDataGrid.SelectedItems.Count > 0)
            {
                String id = (manageSupplierDataGrid.Columns[0].GetCellContent(manageSupplierDataGrid.SelectedItem) as TextBlock).Text;
                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = dbname;
                MessageBoxResult result = MessageBox.Show("Do you want to delete this supplier?", "Confirmation", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    if (dbCon.IsConnect())
                    {
                        string query = "UPDATE `supplier_t` SET `isDeleted`= 1 WHERE suppID = '" + id + "';";
                        if (dbCon.insertQuery(query, dbCon.Connection))
                        {
                            MessageBox.Show("Successfully deleted.");
                            setManageSupplierGridControls();
                        }
                    }

                }
                else if (result == MessageBoxResult.No)
                {
                }
                else if (result == MessageBoxResult.Cancel)
                {
                }
                setManageCustomerGridControls();
            }
        }

        private void defaultTemplateCheckB_Checked(object sender, RoutedEventArgs e)
        {
            body1.IsEnabled = false;
            body2.IsEnabled = false;
            openingRemarksLbl.IsEnabled = false;
            closingRemarksLbl.IsEnabled = false;
        }

        private void defaultTemplateCheckB_Unchecked(object sender, RoutedEventArgs e)
        {
            body1.IsEnabled = true;
            body2.IsEnabled = true;
            openingRemarksLbl.IsEnabled = true;
            closingRemarksLbl.IsEnabled = true;
        }

        private void paymentCustomRb_Checked(object sender, RoutedEventArgs e)
        {
            downPercentTb.IsEnabled = true;
            paymentDpLbl.IsEnabled = true;
        }

        private void paymentCustomRb_Unchecked(object sender, RoutedEventArgs e)
        {
            downPercentTb.IsEnabled = false;
            paymentDpLbl.IsEnabled = false;
        }

        private void transRequestNext_Click(object sender, RoutedEventArgs e)
        {
            for (int x = 1; x < transactionQuotationsGrid.Children.Count; x++)
            {
                transactionQuotationsGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            makeSalesQuoteGrid.Visibility = Visibility.Visible;
        }

        private void transQuotationFormBack_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to save this progress?", "Confirmation", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                for (int x = 1; x < transactionQuotationsGrid.Children.Count; x++)
                {
                    transactionQuotationsGrid.Children[x].Visibility = Visibility.Collapsed;
                }
                addRequestionGrid.Visibility = Visibility.Visible;
            }
            else if (result == MessageBoxResult.No)
            {

            }
            
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to logout?", "Confirmation", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else if (result == MessageBoxResult.No)
            {

            }
        }

        private void transQuotationSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            for (int x = 1; x < transactionQuotationsGrid.Children.Count; x++)
            {
                transactionQuotationsGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            viewQuotationGrid.Visibility = Visibility.Visible;
        }

        private void transViewSaveOnlyBtn_Click(object sender, RoutedEventArgs e)
        {
            for (int x = 1; x < transactionQuotationsGrid.Children.Count; x++)
            {
                transactionQuotationsGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            quotationsGridHome.Visibility = Visibility.Visible;
        }

        private void transViewSaveSend_Click(object sender, RoutedEventArgs e)
        {
            for (int x = 1; x < transactionQuotationsGrid.Children.Count; x++)
            {
                transactionQuotationsGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            quotationsGridHome.Visibility = Visibility.Visible;
        }

        private void transViewBackBtn_Click(object sender, RoutedEventArgs e)
        {
            for (int x = 1; x < transactionQuotationsGrid.Children.Count; x++)
            {
                transactionQuotationsGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            makeSalesQuoteGrid.Visibility = Visibility.Visible;
        }

        private void appSettingsManageMenuBtn_Click(object sender, RoutedEventArgs e)
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
            manageApplicationGrid.Visibility = Visibility.Visible;
        }

        private void manageApplicationGrid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

            setManageApplicationSettingsControls();
        }
        private void setManageApplicationSettingsControls()
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = dbname;
            if (dbCon.IsConnect())
            {
                string query = "SELECT * FROM ITEM_CATEGORY_T;";
                MySqlDataAdapter dataAdapter = dbCon.selectQuery(query, dbCon.Connection);
                DataSet fromDb = new DataSet();
                dataAdapter.Fill(fromDb, "t");
                invProductsCategoryLb.ItemsSource = fromDb.Tables["t"].DefaultView;
                invProductsCategoryLb.DisplayMemberPath = "categoryName";
                invProductsCategoryLb.SelectedValuePath = "categoryId";
            }
            if (dbCon.IsConnect())
            {
                string query = "SELECT * FROM EMP_POSITION_T;";
                MySqlDataAdapter dataAdapter = dbCon.selectQuery(query, dbCon.Connection);
                DataSet fromDb = new DataSet();
                dataAdapter.Fill(fromDb, "t1");
                employeePositionLb.ItemsSource = fromDb.Tables["t1"].DefaultView;
                employeePositionLb.DisplayMemberPath = "positionName";
                employeePositionLb.SelectedValuePath = "positionId";
                dbCon.Close();

            }

        }

        private void addEmpPosBtn_Click(object sender, RoutedEventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = dbname;
            if (dbCon.IsConnect())
            {
                string query = "INSERT INTO `odc_db`.`emp_position_t` (`positionName`) VALUES('" + empPosNewTb.Text + "')";
                if (dbCon.insertQuery(query, dbCon.Connection))
                {
                    MessageBox.Show("Added");
                    
                    dbCon.Close();
                }
            }
            setManageApplicationSettingsControls();
        }

        private void deleteEmpPosBtn_Click(object sender, RoutedEventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = dbname;
            if (dbCon.IsConnect())
            {
                string query = "DELETE FROM `odc_db`.`emp_position_t` WHERE `positionID`='" + employeePositionLb.SelectedValue + "';";
                if (dbCon.insertQuery(query, dbCon.Connection))
                {
                    dbCon.Close();
                    MessageBox.Show("Delete the position");
                    
                }


            }
            setManageApplicationSettingsControls();

        }
        
        private void deleteCategoryBtn_Click(object sender, RoutedEventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = dbname;
            if (dbCon.IsConnect())
            {
                string query = "DELETE FROM `odc_db`.`item_category_t` WHERE `categoryID`='" + invProductsCategoryLb.SelectedValue + "';";
                if (dbCon.insertQuery(query, dbCon.Connection))
                {
                    dbCon.Close();

                    setManageApplicationSettingsControls();
                    MessageBox.Show("Delete the category");
                }


            }
            
        }

        private void addCategoryBtn_Click(object sender, RoutedEventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = dbname;
            if (dbCon.IsConnect())
            {
                string query = "INSERT INTO `odc_db`.`item_category_t` (`categoryName`) VALUES('"+ invCategoryTb.Text+ "')";
                if (dbCon.insertQuery(query, dbCon.Connection))
                {
                    MessageBox.Show("Added");
                    dbCon.Close();
                }
                

            }
        }

        private void manageSupplierAddbtn_Click(object sender, RoutedEventArgs e)
        {
            addSupplier addSupplier = new addSupplier();
            addSupplier.ShowDialog();
            setManageSupplierGridControls();
        }

        private void manageSupplierDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Visual visual = e.OriginalSource as Visual;
            if (visual.IsDescendantOf(manageSupplierDataGrid))
            {
                if (manageSupplierDataGrid.SelectedItems.Count > 0)
                {
                    manageSupplierDataGrid.Columns[manageSupplierDataGrid.Columns.IndexOf(columnEditSuppBtn)].Visibility = Visibility.Visible;
                    manageSupplierDataGrid.Columns[manageSupplierDataGrid.Columns.IndexOf(columnDeleteSuppBtn)].Visibility = Visibility.Visible;
                }
            }
        }

        private void validtycustomRd_Checked(object sender, RoutedEventArgs e)
        {
            ValidityCustom.IsEnabled = true;
            validtycustomlbl.IsEnabled = true;
        }

        private void validtycustomRd_Unchecked(object sender, RoutedEventArgs e)
        {
            ValidityCustom.IsEnabled = false;
            validtycustomlbl.IsEnabled = false;
        }

        private void warrantycustomRd_Checked(object sender, RoutedEventArgs e)
        {
            warrantyDaysCustom.IsEnabled = true;
            warrantyDaysCustomLbl.IsEnabled = true;
        }

        private void warrantycustomRd_Unchecked(object sender, RoutedEventArgs e)
        {
            warrantyDaysCustom.IsEnabled = false;
            warrantyDaysCustomLbl.IsEnabled = false;
        }

        private void deliveryCustomRd_Checked(object sender, RoutedEventArgs e)
        {
            deliveryDaysCustomLbl.IsEnabled = true;
            deliveryDaysTb.IsEnabled = true;
        }

        private void deliveryCustomRd_Unchecked(object sender, RoutedEventArgs e)
        {
            deliveryDaysCustomLbl.IsEnabled = false;
            deliveryDaysTb.IsEnabled = false;
        }

        private void orderFormBack_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to cancel this transaction?", "Confirmation", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                for (int x = 1; x < transactionOrdersGrid.Children.Count; x++)
                {
                    transactionOrdersGrid.Children[x].Visibility = Visibility.Collapsed;
                }
                transOrdersGridHome.Visibility = Visibility.Visible;
            }
            else if (result == MessageBoxResult.No)
            {

            }
        }

        private void transOrdersAddBtn_Click(object sender, RoutedEventArgs e)
        {
            for (int x = 1; x < transactionOrdersGrid.Children.Count; x++)
            {
                transactionOrdersGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            orderFormGrid.Visibility = Visibility.Visible;
        }

        private void transOrderSaveOnly_Click(object sender, RoutedEventArgs e)
        {
            for (int x = 1; x < transactionOrdersGrid.Children.Count; x++)
            {
                transactionOrdersGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            transOrdersGridHome.Visibility = Visibility.Visible;
        }

        private void transOrderSaveSend_Click(object sender, RoutedEventArgs e)
        {
            for (int x = 1; x < transactionOrdersGrid.Children.Count; x++)
            {
                transactionOrdersGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            transOrdersGridHome.Visibility = Visibility.Visible;
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
