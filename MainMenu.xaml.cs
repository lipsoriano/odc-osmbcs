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

        public new String Name { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String Number { get; set; }
        public String Email { get; set; }
        public object locProvinceId { get; set; }
        public object CityName { get; set; }
        public String EmailAddress { get; set; }
        public String PhoneNumber { get; set; }
        public String MobileNumber { get; set; }

        public MainMenu()
        {
            InitializeComponent();
            custCompanyNameTb.DataContext = this;
            custAddressTb.DataContext = this;
            custCityTb.DataContext = this;
            custProvinceCb.DataContext = this;
            contactDetailsEmailTb.DataContext = this;
            contactDetailsMobileTb.DataContext = this;
            contactDetailsPhoneTb.DataContext = this;
        }
        private static String dbname = "odc_db";

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int x = 0; x < containerGrid.Children.Count; x++)
            {
                containerGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            dashboardGrid.Visibility = Visibility.Visible;
            contactTypeCb.SelectedIndex = 0;
            contactDetailsMobileTb.IsEnabled = false;
            contactDetailsPhoneTb.IsEnabled = false;
            contactDetailsEmailTb.IsEnabled = false;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Visual visual = e.OriginalSource as Visual;
            if (!visual.IsDescendantOf(saleSubMenuGrid) && !visual.IsDescendantOf(manageSubMenugrid))
                saleSubMenuGrid.Visibility = Visibility.Collapsed;
            manageSubMenugrid.Visibility = Visibility.Collapsed;
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
            if (!visual.IsDescendantOf(manageCustomeDataGrid))
            {
                if (manageCustomeDataGrid.SelectedItems.Count > 0)
                {
                    manageCustomeDataGrid.Columns[manageContractorDataGrid.Columns.IndexOf(columnEditBtnCont)].Visibility = Visibility.Hidden;
                    manageCustomeDataGrid.Columns[manageContractorDataGrid.Columns.IndexOf(columnDelBtnCont)].Visibility = Visibility.Hidden;
                }
            }
            if (!visual.IsDescendantOf(custContactDetailsDg))
            {
                if (custContactDetailsDg.SelectedItems.Count > 0)
                {
                    custContactDetailsDg.Columns[custContactDetailsDg.Columns.IndexOf(columnEditBtnCustCont)].Visibility = Visibility.Hidden;
                    custContactDetailsDg.Columns[custContactDetailsDg.Columns.IndexOf(columnDelBtnCustCont)].Visibility = Visibility.Hidden;
                }
            }
        }

        /*-----------------MENU BAR BUTTONS-------------------*/

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

        private void salesBtn_Click(object sender, RoutedEventArgs e)
        {
            saleSubMenuGrid.Visibility = Visibility.Visible;
        }

        private void serviceBtn_Click(object sender, RoutedEventArgs e)
        {
            saleSubMenuGrid.Visibility = Visibility.Collapsed;
            manageSubMenugrid.Visibility = Visibility.Collapsed;
            for (int x = 0; x < containerGrid.Children.Count; x++)
            {
                containerGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            servicesGrid.Visibility = Visibility.Visible;
        }

        private void reportsBtn_Click(object sender, RoutedEventArgs e)
        {
            saleSubMenuGrid.Visibility = Visibility.Collapsed;
            manageSubMenugrid.Visibility = Visibility.Collapsed;
            for (int x = 0; x < containerGrid.Children.Count; x++)
            {
                containerGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            reportsGrid.Visibility = Visibility.Visible;
        }

        private void dashBoardBtn_Click(object sender, RoutedEventArgs e)
        {
            saleSubMenuGrid.Visibility = Visibility.Collapsed;
            manageSubMenugrid.Visibility = Visibility.Collapsed;
            for (int x = 0; x < containerGrid.Children.Count; x++)
            {
                containerGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            dashboardGrid.Visibility = Visibility.Visible;
        }

        private void manageBtn_Click(object sender, RoutedEventArgs e)
        {
            saleSubMenuGrid.Visibility = Visibility.Collapsed;
            manageSubMenugrid.Visibility = Visibility.Visible;
        }

        /*-----------------END OF MENU BAR BUTTONS-------------------*/

        /*-----------------SUB MENU BAR BUTTONS-------------------*/
        private void quotesSalesMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            saleSubMenuGrid.Visibility = Visibility.Collapsed;
            manageSubMenugrid.Visibility = Visibility.Collapsed;
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
            saleSubMenuGrid.Visibility = Visibility.Collapsed;
            manageSubMenugrid.Visibility = Visibility.Collapsed;
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
            saleSubMenuGrid.Visibility = Visibility.Collapsed;
            manageSubMenugrid.Visibility = Visibility.Collapsed;
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
            saleSubMenuGrid.Visibility = Visibility.Collapsed;
            manageSubMenugrid.Visibility = Visibility.Collapsed;
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

        /*-----------------END OF SUB MENU BAR BUTTONS-------------------*/


        /*-----------------TRANSTACTION-------------------*/
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

        private void setAddTransControlValues()
        {

            //String[] reqTypeArr = { };
            //String reqTypeSettings = Properties.Settings.Default.requestType.ToString();
            //reqTypeArr = reqTypeSettings.Split(',');
            //if (reqType.Items.IsEmpty)
            //{
            //    foreach (String reTypeString in reqTypeArr)
            //    {
            //        reqType.Items.Add(reTypeString);
            //    }
            //}
            //reqTypeSettings = Properties.Settings.Default.serviceType.ToString();
            //reqTypeArr = reqTypeSettings.Split(',');
            //if (typesOfService.Items.IsEmpty)
            //{
            //    foreach (String reTypeString in reqTypeArr)
            //    {
            //        typesOfService.Items.Add(reTypeString);
            //    }
            //}
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
                RepresentativeWindow addRep = new RepresentativeWindow();
                addRep.custName = custCb.Text;
                addRep.custId = custCb.SelectedValue.ToString();
                addRep.ShowDialog();
            }
            else
            {
                System.Windows.MessageBox.Show("Select a customer first.");
            }

        }

        //private void defaultTemplateCheckB_Checked(object sender, RoutedEventArgs e)
        //{
        //    body1.IsEnabled = false;
        //    body2.IsEnabled = false;
        //    openingRemarksLbl.IsEnabled = false;
        //    closingRemarksLbl.IsEnabled = false;
        //}

        //private void defaultTemplateCheckB_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    body1.IsEnabled = true;
        //    body2.IsEnabled = true;
        //    openingRemarksLbl.IsEnabled = true;
        //    closingRemarksLbl.IsEnabled = true;
        //}

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

        /*-----------------END OF TRANSTACTION-------------------*/


        /*-----------------MANAGE CUSTOMER-------------------*/

        private void customerManageMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            saleSubMenuGrid.Visibility = Visibility.Collapsed;
            manageSubMenugrid.Visibility = Visibility.Collapsed;
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
                string query = query = "SELECT c.custID, c.custCompanyName, c.custAddInfo, CONCAT(c.custAddress,' ',c.custCity,' ',p.locProvince) AS custLocation " +
                    "FROM customer_t c  " +
                    "JOIN provinces_t p ON c.custProvinceID = p.locProvinceId " +
                    "WHERE isDeleted = 0;";
                MySqlDataAdapter dataAdapter = dbCon.selectQuery(query, dbCon.Connection);
                DataSet fromDb = new DataSet();
                dataAdapter.Fill(fromDb, "t");
                manageCustomeDataGrid.ItemsSource = fromDb.Tables["t"].DefaultView;
                dbCon.Close();
            }
            if (dbCon.IsConnect())
            {
                string query = "SELECT * FROM provinces_t";
                MySqlDataAdapter dataAdapter = dbCon.selectQuery(query, dbCon.Connection);
                DataSet fromDb = new DataSet();
                dataAdapter.Fill(fromDb, "t");
                custProvinceCb.ItemsSource = fromDb.Tables["t"].DefaultView;
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
            manageCustomerHomeGrid.Visibility = Visibility.Hidden;
            customerDetailsGrid.Visibility = Visibility.Visible;
            
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

        private void cancelCustBtn_Click(object sender, RoutedEventArgs e)
        {
            manageCustomerHomeGrid.Visibility = Visibility.Visible;
            customerDetailsGrid.Visibility = Visibility.Hidden;
            setManageCustomerGridControls();
        }

        private void saveCustBtn_Click(object sender, RoutedEventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = dbname;
            MessageBoxResult result = MessageBox.Show("Do you want to save this new customer?", "Confirmation", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                string custid = "";
                if (dbCon.IsConnect())
                {
                    string query = "INSERT INTO customer_t (custCompanyName,custAddInfo,custAddress,custCity,custProvinceID) VALUES ('" + custCompanyNameTb.Text + "','" + custAddInfoTb.Text + "','" + custAddressTb.Text + "','" + custCityTb.Text + "','"+custProvinceCb.SelectedValue+"')";

                    if (dbCon.insertQuery(query, dbCon.Connection))
                    {
                        query = "select last_insert_id() from customer_t";
                        MySqlDataAdapter dataAdapter = dbCon.selectQuery(query, dbCon.Connection);
                        DataSet fromDb = new DataSet();
                        dataAdapter.Fill(fromDb, "t");
                        foreach (DataRow myRow in fromDb.Tables[0].Rows)
                        {
                            custid = myRow[0].ToString();
                        }
                        foreach (List<string[]> repDetail in repDetails)
                        {
                            foreach (string[] detail in repDetail)
                            {
                                query = "INSERT INTO customer_rep_t (custRepLname,custrepfname,custrepmi, custId) VALUES ('" + detail[2] + "','" + detail[0] + "','" + detail[1] + "','"+ custid + "')";
                                if (dbCon.insertQuery(query, dbCon.Connection))
                                {
                                    query = "select last_insert_id() from customer_rep_t"; 
                                    if (dbCon.insertQuery(query, dbCon.Connection))
                                    {
                                        dataAdapter = dbCon.selectQuery(query, dbCon.Connection);
                                        fromDb = new DataSet();
                                        dataAdapter.Fill(fromDb, "t");
                                        string repid = "";
                                        foreach (DataRow myRow in fromDb.Tables[0].Rows)
                                        {
                                            repid = myRow[0].ToString();
                                        }
                                        foreach (List<string[]> repcontact in repcontactDetails)
                                        {
                                            foreach (string[] contact in repcontact)
                                            {
                                                query = "INSERT INTO contacts_t (contactType,contactDetails) VALUES ('" + contact[0] + "','" + contact[1] + "')";
                                                dbCon.insertQuery(query, dbCon.Connection);
                                                query = "select last_insert_id() from contacts_t";
                                                if (dbCon.insertQuery(query, dbCon.Connection))
                                                {
                                                    dataAdapter = dbCon.selectQuery(query, dbCon.Connection);
                                                    fromDb = new DataSet();
                                                    dataAdapter.Fill(fromDb, "t");
                                                    string contId = "";
                                                    foreach (DataRow myRow in fromDb.Tables[0].Rows)
                                                    {
                                                        contId = myRow[0].ToString();
                                                    }
                                                    query = "INSERT INTO customer_rep_t_contact_t (custRepId,contactId) VALUES ('" + repid + "','" + contId + "')";
                                                    dbCon.insertQuery(query, dbCon.Connection);
                                                }
                                            }

                                        }

                                    }
                                    
                                }
                            }

                        }
                        foreach (string[] contact in contactDetails)
                        {
                            query = "INSERT INTO contacts_t (contactType,contactDetails) VALUES ('" + contact[0] + "','" + contact[1] + "')";
                            if (dbCon.insertQuery(query, dbCon.Connection))
                            {
                                query = "select last_insert_id() from contacts_t";
                                if (dbCon.insertQuery(query, dbCon.Connection))
                                {
                                    dataAdapter = dbCon.selectQuery(query, dbCon.Connection);
                                    fromDb = new DataSet();
                                    dataAdapter.Fill(fromDb, "t");
                                    string contId = "";
                                    foreach (DataRow myRow in fromDb.Tables[0].Rows)
                                    {
                                        contId = myRow[0].ToString();
                                    }
                                    query = "INSERT INTO customer_t_contact_t (custId,contactId) VALUES ('" + custid + "','" + contId + "')";
                                    dbCon.insertQuery(query, dbCon.Connection);
                                }
                                
                            }
                        }

                        MessageBox.Show("Saved");
                        manageCustomerHomeGrid.Visibility = Visibility.Visible;
                        customerDetailsGrid.Visibility = Visibility.Hidden;
                        setManageCustomerGridControls();
                    }
                }
            }
            else if (result == MessageBoxResult.No)
            {
                manageCustomerHomeGrid.Visibility = Visibility.Visible;
                customerDetailsGrid.Visibility = Visibility.Hidden;
                setManageCustomerGridControls();
            }
            else if (result == MessageBoxResult.Cancel)
            {
            }

        }

        public List<List<string[]>> repDetails = new List<List<string[]>>();
        public List<List<string[]>> repcontactDetails = new List<List<string[]>>();
        private void newRepresentativeBtn_Click(object sender, RoutedEventArgs e)
        {
            RepresentativeWindow repWindow = new RepresentativeWindow();
            repWindow.ShowDialog();
            repDetails.Add(repWindow.repDetails);
            repcontactDetails.Add(repWindow.contactDetails);
            newCustomerGrid();
            validateCustomerDetailsTextBoxes();
        }
        

        private void newCustomerGrid()
        {
            foreach (List<string[]> repDetail in repDetails)
            {
                foreach (string[] detail in repDetail)
                {
                    var data = new Representative { firstName = detail[0], middleName = detail[1], lastName = detail[2] };
                    customerRepresentativeDg.Items.Add(data);
                }
                
            }
        }

        private void customerRepresentativeDg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Visual visual = e.OriginalSource as Visual;
            if (visual.IsDescendantOf(customerRepresentativeDg))
            {
                if (customerRepresentativeDg.SelectedItems.Count > 0)
                {
                    customerRepresentativeDg.Columns[customerRepresentativeDg.Columns.IndexOf(columnEditBtnCustContRep)].Visibility = Visibility.Visible;
                    customerRepresentativeDg.Columns[customerRepresentativeDg.Columns.IndexOf(columnDelBtnCustContRep)].Visibility = Visibility.Visible;
                }
            }
        }
        public List<string[]> contactDetails = new List<string[]>();
        private void addNewCustContactBtn_Click(object sender, RoutedEventArgs e)
        {

            if (!(System.Windows.Controls.Validation.GetHasError(contactDetailsPhoneTb) == true)&& !(System.Windows.Controls.Validation.GetHasError(contactDetailsEmailTb) == true)&& !(System.Windows.Controls.Validation.GetHasError(contactDetailsMobileTb) == true))
            {
                if (contactTypeCb.SelectedIndex != 0)
                {
                    
                    var data = new Contacts { contactType = contactTypeCb.SelectedValue.ToString(), contactTypeID = "" + contactTypeCb.SelectedIndex, contactDetails = contactDetail };
                    custContactDetailsDg.Items.Add(data);
                    string[] details = { contactTypeCb.SelectedIndex.ToString(), contactDetail };
                    contactDetails.Add(details);
                    contactDetailsEmailTb.Text = "";
                    contactDetailsMobileTb.Text = "";
                    contactDetailsPhoneTb.Text = "";
                    validateCustomerDetailsTextBoxes();
                    Validation.ClearInvalid((contactDetailsPhoneTb).GetBindingExpression(TextBox.TextProperty));
                    Validation.ClearInvalid((contactDetailsEmailTb).GetBindingExpression(TextBox.TextProperty));
                    Validation.ClearInvalid((contactDetailsMobileTb).GetBindingExpression(TextBox.TextProperty));
                }
                else
                {
                    MessageBox.Show("Select The Type");
                }
            }
            else
                MessageBox.Show("Please resolve the error first.");
            
            
        }

        private string contactDetail = "";
        private void contactTypeCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (contactTypeCb.SelectedIndex == 1)
            {
                contactDetailsEmailTb.Visibility = Visibility.Visible;
                contactDetailsMobileTb.Visibility = Visibility.Collapsed;
                contactDetailsPhoneTb.Visibility = Visibility.Collapsed;
                contactDetailsMobileTb.IsEnabled = false;
                contactDetailsPhoneTb.IsEnabled = false;
                contactDetailsEmailTb.IsEnabled = true;
            }
            else if (contactTypeCb.SelectedIndex == 2)
            {
                contactDetailsEmailTb.Visibility = Visibility.Collapsed;
                contactDetailsMobileTb.Visibility = Visibility.Collapsed;
                contactDetailsPhoneTb.Visibility = Visibility.Visible;
                contactDetailsMobileTb.IsEnabled = false;
                contactDetailsPhoneTb.IsEnabled = true;
                contactDetailsEmailTb.IsEnabled = false;
            }
            else if (contactTypeCb.SelectedIndex == 3)
            {
                contactDetailsEmailTb.Visibility = Visibility.Collapsed;
                contactDetailsMobileTb.Visibility = Visibility.Visible;
                contactDetailsPhoneTb.Visibility = Visibility.Collapsed;
                
                contactDetailsMobileTb.IsEnabled = true;
                contactDetailsPhoneTb.IsEnabled = false;
                contactDetailsEmailTb.IsEnabled = false;
            }
        }
        private void contactDetailsEmailTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Windows.Controls.Validation.GetHasError(contactDetailsEmailTb) == true)
            {
                saveCustBtn.IsEnabled = false;
                saveCustContactBtn.IsEnabled = false;
            }
            else
            {
                contactDetail = contactDetailsEmailTb.Text;
                saveCustContactBtn.IsEnabled = true;
                validateCustomerDetailsTextBoxes();
            }
        }

        private void contactDetailsPhoneTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Windows.Controls.Validation.GetHasError(contactDetailsPhoneTb) == true)
            {
                saveCustBtn.IsEnabled = false;
                saveCustContactBtn.IsEnabled = false;
            }
            else
            {
                contactDetail = contactDetailsPhoneTb.Text;
                saveCustContactBtn.IsEnabled = true;
                validateCustomerDetailsTextBoxes();
            }
        }

        private void contactDetailsMobileTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Windows.Controls.Validation.GetHasError(contactDetailsMobileTb) == true)
            {
                saveCustBtn.IsEnabled = false;
                saveCustContactBtn.IsEnabled = false;
            }
            else
            {
                contactDetail = contactDetailsMobileTb.Text;
                validateCustomerDetailsTextBoxes();
                saveCustContactBtn.IsEnabled = true;
            }
        }

        private void custCompanyNameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Windows.Controls.Validation.GetHasError(custCompanyNameTb) == true)
                saveCustBtn.IsEnabled = false;
            else validateCustomerDetailsTextBoxes();
        }

        private void locationAddressTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Windows.Controls.Validation.GetHasError(custAddressTb) == true)
                saveCustBtn.IsEnabled = false;
            else validateCustomerDetailsTextBoxes();
        }

        private void locationCityTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Windows.Controls.Validation.GetHasError(custCityTb) == true)
                saveCustBtn.IsEnabled = false;
            else validateCustomerDetailsTextBoxes();
        }

        private void validateCustomerDetailsTextBoxes()
        {
            if (custCompanyNameTb.Text.Equals("") || custAddressTb.Text.Equals("") || custCityTb.Text.Equals("") || custProvinceCb.SelectedIndex == -1||contactDetails.Count==0 ||repDetails.Count==0)
            {
                saveCustBtn.IsEnabled = false;
            }
            else
            {
                saveCustBtn.IsEnabled = true;
            }
        }

        private void custContactDetailsDg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Visual visual = e.OriginalSource as Visual;
            if (visual.IsDescendantOf(custContactDetailsDg))
            {
                if (custContactDetailsDg.SelectedItems.Count > 0)
                {
                    custContactDetailsDg.Columns[custContactDetailsDg.Columns.IndexOf(columnEditBtnCustCont)].Visibility = Visibility.Visible;
                    custContactDetailsDg.Columns[custContactDetailsDg.Columns.IndexOf(columnDelBtnCustCont)].Visibility = Visibility.Visible;
                }
            }
        }

        private void btnEditCustCont_Click(object sender, RoutedEventArgs e)
        {
            if (custContactDetailsDg.SelectedItem!=null)
            {
                String id = (custContactDetailsDg.Columns[0].GetCellContent(custContactDetailsDg.SelectedItem) as TextBlock).Text;
                contactTypeCb.SelectedIndex = int.Parse(id);
                
                if (id.Equals("1"))
                {
                    contactDetailsEmailTb.Text = (custContactDetailsDg.Columns[2].GetCellContent(custContactDetailsDg.SelectedItem) as TextBlock).Text;

                }
                else if (id.Equals("2"))
                {
                    contactDetailsMobileTb.Text = (custContactDetailsDg.Columns[2].GetCellContent(custContactDetailsDg.SelectedItem) as TextBlock).Text;
                }
                else if (id.Equals("3"))
                {
                    contactDetailsPhoneTb.Text = (custContactDetailsDg.Columns[2].GetCellContent(custContactDetailsDg.SelectedItem) as TextBlock).Text;
                }
                saveCustContactBtn.Visibility = Visibility.Visible;
                cancelCustContactBtn.Visibility = Visibility.Visible;
            }

            
        }
        int newCust = 0;
        private void btnDeleteCustCont_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete this customer contact information?", "Confirmation", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                if (newCust == 0)
                {
                    int selectIndex = custContactDetailsDg.SelectedIndex;
                    custContactDetailsDg.Items.RemoveAt(selectIndex);
                    contactDetails.RemoveAt(selectIndex);
                }
            }
            else if (result == MessageBoxResult.No)
            {
            }
            else if (result == MessageBoxResult.Cancel)
            {
            }
            
            
        }

        private void saveCustContactBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!(System.Windows.Controls.Validation.GetHasError(contactDetailsPhoneTb) == true) && !(System.Windows.Controls.Validation.GetHasError(contactDetailsEmailTb) == true) && !(System.Windows.Controls.Validation.GetHasError(contactDetailsMobileTb) == true))
            {
                if (contactTypeCb.SelectedIndex != 0)
                {
                    saveCustContactBtn.Visibility = Visibility.Hidden;
                    int selectIndex = custContactDetailsDg.SelectedIndex;
                    custContactDetailsDg.Items.RemoveAt(selectIndex);
                    string[] contactTemp = contactDetails[selectIndex];
                    contactDetails.RemoveAt(selectIndex);
                    contactTemp[1] = contactDetail;
                    var data = new Contacts { contactType = contactTypeCb.SelectedValue.ToString(), contactTypeID = contactTemp[0], contactDetails = contactTemp[1] };
                    custContactDetailsDg.Items.Add(data);
                }
                else
                {
                    MessageBox.Show("Select The Type");
                }
            }
            else
                MessageBox.Show("Please resolve the error first.");
            
        }

        private void cancelCustContactBtn_Click(object sender, RoutedEventArgs e)
        {
            contactDetailsEmailTb.Text = "";
            contactDetailsMobileTb.Text = "";
            contactDetailsPhoneTb.Text = "";
            cancelCustContactBtn.Visibility = Visibility.Hidden;
            saveCustContactBtn.Visibility = Visibility.Hidden;
        }

        private void editBtnCustContRep_Click(object sender, RoutedEventArgs e)
        {
            RepresentativeWindow repWindow = new RepresentativeWindow();
            int selectIndex = custContactDetailsDg.SelectedIndex;
            repWindow.Edit = 1;
            repWindow.repDetails = repDetails[selectIndex];
            repWindow.contactDetails = repcontactDetails[selectIndex];
            repDetails.RemoveAt(selectIndex);
            repcontactDetails.RemoveAt(selectIndex);
            repWindow.ShowDialog();
            repDetails.Add(repWindow.repDetails);
            repcontactDetails.Add(repWindow.contactDetails);
            newCustomerGrid();
            validateCustomerDetailsTextBoxes();
        }

        private void delBtnCustContRep_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete this representative?", "Confirmation", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                int selectIndex = custContactDetailsDg.SelectedIndex;
                repDetails.RemoveAt(selectIndex);
                repcontactDetails.RemoveAt(selectIndex);
            }
            else if (result == MessageBoxResult.No)
            {
            }
            else if (result == MessageBoxResult.Cancel)
            {
            }
            
        }

        /*-----------------END OF MANAGE CUSTOMER-------------------*/
        /*
        /*
        /*
        /*
        /*
        /*-----------------MANAGE EMPLOYEE-------------------------*/
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
                string query = query = "SELECT e.empID, CONCAT(e.empFName,' ',e.empMi,'. ',e.empLname) AS empName, ept.positionName, CONCAT(e.empAddress,' ',e.empcity,' ',p.locProvince) as empAddress " +
                    "FROM employee_t e " +
                    "JOIN position_t ept ON e.positionid = ept.positionId " +
                    "JOIN provinces_t p ON e.empProvinceID = p.locProvinceId " +
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
            saleSubMenuGrid.Visibility = Visibility.Collapsed;
            manageSubMenugrid.Visibility = Visibility.Collapsed;
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

        /*-----------------END OF MANAGE EMPLOYEE-------------------*/
        /*
        /*
        /*
        /*
        /*
        /*-----------------MANAGE SUPPLIER-------------------------*/


        private void supplierManageMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            saleSubMenuGrid.Visibility = Visibility.Collapsed;
            manageSubMenugrid.Visibility = Visibility.Collapsed;
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
                string query = query = "SELECT c.suppID, c.suppCompanyName, c.suppAddInfo, CONCAT(c.suppAddress,' ',c.suppCity,' ',p.locProvince) AS suppLocation " +
                    "FROM supplier_t c " +
                    "JOIN provinces_t p ON c.suppProvinceId = p.locProvinceId " +
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
                setManageSupplierGridControls();
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

        /*-----------------END OF MANAGE SUPPLIER-------------------*/
        /*
        /*
        /*
        /*
        /*
        /*-----------------MANAGE UTILITIES-------------------------*/

        private void utilitiesManageMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            saleSubMenuGrid.Visibility = Visibility.Collapsed;
            manageSubMenugrid.Visibility = Visibility.Collapsed;
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



        private void settingsEmployeeGridBtn_Click(object sender, RoutedEventArgs e)
        {
            manageEmployeeSettings manageEmployeeSettings = new manageEmployeeSettings();
            manageEmployeeSettings.ShowDialog();
        }

        private void settingsServicesGridBtn_Click(object sender, RoutedEventArgs e)
        {
            manageServicesSettings manageServicesSettings = new manageServicesSettings();
            manageServicesSettings.ShowDialog();
        }

        private void settingsInvetoryBtn_Click(object sender, RoutedEventArgs e)
        {
            manageProductSettings manageProductSettings = new manageProductSettings();
            manageProductSettings.ShowDialog();
        }





        private void appSettingsManageMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            saleSubMenuGrid.Visibility = Visibility.Collapsed;
            manageSubMenugrid.Visibility = Visibility.Collapsed;
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


        /*-----------------END OF MANAGE UTILITIES-------------------*/
        /*
        /*
        /*
        /*
        /*
        /*-----------------MANAGE CONTRACTOR-------------------------*/



        private void contractorManageMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            saleSubMenuGrid.Visibility = Visibility.Collapsed;
            manageSubMenugrid.Visibility = Visibility.Collapsed;
            for (int x = 0; x < containerGrid.Children.Count; x++)
            {
                containerGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            manageGrid.Visibility = Visibility.Visible;
            for (int x = 0; x < manageGrid.Children.Count; x++)
            {
                manageGrid.Children[x].Visibility = Visibility.Collapsed;
            }
            manageContractorGrid.Visibility = Visibility.Visible;
        }

        private void btnEditCont_Click(object sender, RoutedEventArgs e)
        {
            if (manageContractorDataGrid.SelectedItems.Count > 0)
            {
                String id = (manageContractorDataGrid.Columns[0].GetCellContent(manageContractorDataGrid.SelectedItem) as TextBlock).Text;
                editContractor editContractor = new editContractor(id);
                editContractor.ShowDialog();
                setManageContractorGridControls();
            }
        }

        private void btnDeleteCont_Click(object sender, RoutedEventArgs e)
        {
            if (manageContractorDataGrid.SelectedItems.Count > 0)
            {
                String id = (manageContractorDataGrid.Columns[0].GetCellContent(manageContractorDataGrid.SelectedItem) as TextBlock).Text;
                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = dbname;
                MessageBoxResult result = MessageBox.Show("Do you want to delete this Contractor?", "Confirmation", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    if (dbCon.IsConnect())
                    {
                        string query = "UPDATE `contractor_t` SET `isDeleted`= 1 WHERE contID = '" + id + "';";
                        if (dbCon.insertQuery(query, dbCon.Connection))
                        {
                            MessageBox.Show("Successfully deleted.");
                            setManageContractorGridControls();
                        }
                    }

                }
                else if (result == MessageBoxResult.No)
                {
                }
                else if (result == MessageBoxResult.Cancel)
                {
                }
            }
        }

        private void manageContractorGrid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            setManageContractorGridControls();
        }

        private void setManageContractorGridControls()
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = dbname;
            if (dbCon.IsConnect())
            {
                string query = query = "SELECT c.contractorID, CONCAT(c.contFName,' ',c.contMi,'. ',c.contLname) AS contName,j.jobName, CONCAT(c.contAddress,' ',c.contcity,' ',p.locProvince) as contAddress " +
                    "FROM contractor_t c " +
                    "JOIN job_title_t j ON j.jobID = c.jobID " +
                    "JOIN provinces_t p ON c.contProvinceID = p.locProvinceId " +
                    "WHERE isDeleted = 0;";
                MySqlDataAdapter dataAdapter = dbCon.selectQuery(query, dbCon.Connection);
                DataSet fromDb = new DataSet();
                dataAdapter.Fill(fromDb, "t");
                manageContractorDataGrid.ItemsSource = fromDb.Tables["t"].DefaultView;
                dbCon.Close();
            }
        }

        private void manageContractorAddBtn_Click(object sender, RoutedEventArgs e)
        {
            addContractor addContractor = new addContractor();
            addContractor.ShowDialog();
            setManageContractorGridControls();
        }

        private void manageContractorDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Visual visual = e.OriginalSource as Visual;
            if (visual.IsDescendantOf(manageContractorDataGrid))
            {
                if (manageContractorDataGrid.SelectedItems.Count > 0)
                {
                    manageContractorDataGrid.Columns[manageContractorDataGrid.Columns.IndexOf(columnEditBtnCont)].Visibility = Visibility.Visible;
                    manageContractorDataGrid.Columns[manageContractorDataGrid.Columns.IndexOf(columnDelBtnCont)].Visibility = Visibility.Visible;
                }
            }
        }

        

        private void servicesDg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        











        /*-----------------END OF MANAGE CONTRACTOR-------------------*/
        /*
        /*
        /*
        /*
        /*
        /*----------------------UNIVERSAL-----------------------------*/



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

    internal class Contacts : INotifyPropertyChanged
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
        private string _contactTypeID;
        public string contactTypeID
        {
            get { return _contactTypeID; }
            set { SetField(ref _contactTypeID, value, ""); }
        }
        private string _contactType;
        public string contactType
        {
            get { return _contactType; }
            set { SetField(ref _contactType, value, "Contact Type"); }
        }
        private string _contactDetails;
        public string contactDetails
        {
            get { return _contactDetails; }
            set { SetField(ref _contactDetails, value, ""); }
        }
    }

    internal class Representative : INotifyPropertyChanged
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
        private string _firstName;
        public string firstName
        {
            get { return _firstName; }
            set { SetField(ref _firstName, value, ""); }
        }
        private string _middleName;
        public string middleName
        {
            get { return _middleName; }
            set { SetField(ref _middleName, value, "Contact Type"); }
        }
        private string _lastName;
        public string lastName
        {
            get { return _lastName; }
            set { SetField(ref _lastName, value, ""); }
        }
    }

}
