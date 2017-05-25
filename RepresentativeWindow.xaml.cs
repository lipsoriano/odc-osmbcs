using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for representativeWindow.xaml
    /// </summary>
    public partial class RepresentativeWindow : Window
    {
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public RepresentativeWindow()
        {
            InitializeComponent();
            firstNameTb.DataContext = this;
            middleInitialTb.DataContext = this;
            lastNameTb.DataContext = this;
        }
        public string custName { get; set; }
        public string custId { get; set; }
        public string repType { get; set; }
        private void setControlsValue()
        {
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            setControlsValue();
        }
        private static String dbname = "odc_db";
        
        public List<string> idOf = new List<string>();
        private void addNewContactCustBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!contactDetailTb.Text.Equals(""))
            {
                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = dbname;
                string query = "INSERT INTO contact_details_t (contactType,contactData) VALUES ('" + contactTypeCb.SelectedValue + "','" + contactDetailTb.Text + "')";
                if (dbCon.insertQuery(query, dbCon.Connection))
                {
                    query = "select last_insert_id() from contact_details_t";
                    MySqlDataAdapter dataAdapter = dbCon.selectQuery(query, dbCon.Connection);
                    DataSet fromDb = new DataSet();
                    dataAdapter.Fill(fromDb, "t");
                    foreach (DataRow myRow in fromDb.Tables[0].Rows)
                    {
                        idOf.Add(myRow[0].ToString());
                    }
                    contactTypeCb.SelectedIndex = 0;
                    contactDetailTb.Text = "";
                    MessageBox.Show("Added!");
                }
            }
        }

        private void contactTypeCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(contactTypeCb.SelectedIndex == 0))
            {
                validateTextBoxes();
            }
            else
            {

            }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = dbname;
            if (dbCon.IsConnect() && repType.Equals("CUST"))
            {
                string repid = "";
                string query = "INSERT INTO customer_rep_t (custRepLname,custRepFname,custRepMi,custID)VALUES ('" + lastNameTb.Text + "','" + firstNameTb.Text + "', '" + middleInitialTb.Text + "','" + custId + "')";
                query = "select last_insert_id() from customer_rep_t";
                MySqlDataAdapter dataAdapter = dbCon.selectQuery(query, dbCon.Connection);
                DataSet fromDb = new DataSet();
                dataAdapter.Fill(fromDb, "t");
                foreach (DataRow myRow in fromDb.Tables[0].Rows)
                {
                    repid = myRow[0].ToString();
                }
                if (dbCon.insertQuery(query, dbCon.Connection))
                {
                    foreach(String id in idOf)
                    {
                        query = "UPDATE `contact_details_t` SET `idOf`= '"+ repid + "' WHERE contactID = '" + id + "';";
                        if (dbCon.insertQuery(query, dbCon.Connection))
                        {
                        }
                    }
                    MessageBox.Show("Customer's Representative Details is successfully inserted");
                }
            }
            else if (dbCon.IsConnect() && repType.Equals("SUPP"))
            {
                string query = "INSERT INTO supplier_rep_t (suppRepLname,suppRepFname,suppRepMi,custID,suppRepContID) VALUES ('" + lastNameTb.Text + "','" + firstNameTb.Text + "', '" + middleInitialTb.Text + "','" + custId + "')";

                if (dbCon.insertQuery(query, dbCon.Connection))
                {
                    MessageBox.Show("Customer's Representative Details is successfully inserted");
                }
            }
        }

        private void firstNameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Windows.Controls.Validation.GetHasError(firstNameTb) == true)
                saveBtn.IsEnabled = false;
            else validateTextBoxes();
        }

        

        private void middleInitialTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Windows.Controls.Validation.GetHasError(middleInitialTb) == true)
                saveBtn.IsEnabled = false;
            else validateTextBoxes();
        }

        private void lastNameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Windows.Controls.Validation.GetHasError(lastNameTb) == true)
                saveBtn.IsEnabled = false;
            else validateTextBoxes();
        }

        private void validateTextBoxes()
        {
            if (idOf.Count==0)
            {
                saveBtn.IsEnabled = false;
            }
            else
            {
                saveBtn.IsEnabled = true;
            }
        }
    }
}
