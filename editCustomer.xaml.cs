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
    /// Interaction logic for editCustomer.xaml
    /// </summary>
    public partial class editCustomer: Window
    {
        public String id;
        public String locId;
        public editCustomer()
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
                string query = "SELECT * FROM provinces_t";
                MySqlDataAdapter dataAdapter = dbCon.selectQuery(query, dbCon.Connection);
                DataSet fromDb = new DataSet();
                dataAdapter.Fill(fromDb, "t");
                custProvinceCust.ItemsSource = fromDb.Tables["t"].DefaultView;
                dbCon.Close();

            }
        }
        private void setControlValuesSynced(String id)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = dbname;
            if (dbCon.IsConnect())
            {
                string query ="SELECT c.custID, c.custCompanyName, c.custAddInfo,c.locationId, cc.officePhoneNo, cc.mobileNo,ld.locationAddress,ld.locationCity,lp.locProvinceID FROM customer_t c " +
                    "JOIN customer_contacts_t cc ON c.custID = cc.custID " +
                    "JOIN location_details_t ld ON c.locationID = ld.locationID " +
                    "JOIN provinces_t lp ON ld.locationProvinceID = lp.locProvinceID WHERE c.custID = '"+ id + "';";
                MySqlDataAdapter dataAdapter = dbCon.selectQuery(query, dbCon.Connection);
                DataSet fromDb = new DataSet(); 
                DataTable fromDbTable = new DataTable();
                dataAdapter.Fill(fromDb, "t");
                fromDbTable = fromDb.Tables["t"];
                foreach (DataRow dr in fromDbTable.Rows)
                {
                    locId = dr["locationId"].ToString();
                    custCompanyNameTb.Text = dr["custCompanyName"].ToString();
                    custAddInfoTb.Text = dr["custAddInfo"].ToString();
                    int locProvId = Int32.Parse(dr["locProvinceID"].ToString());
                    custProvinceCust.SelectedIndex = locProvId-1;
                    locationAddressTb.Text = dr["locationAddress"].ToString();
                    locationCityTb.Text = dr["locationCity"].ToString();
                    officeNumber.Text = dr["officePhoneNo"].ToString();
                    mobileNumTb.Text = dr["mobileNo"].ToString();
                }
                dbCon.Close();
            }
        }
        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = dbname;
            MessageBoxResult result = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (result==MessageBoxResult.Yes)
            {
                if (dbCon.IsConnect())
                {
                    string query = "UPDATE `customer_t` SET `custCompanyname`='" + custCompanyNameTb.Text + "',`custAddInfo`='" + custAddInfoTb.Text + "' WHERE `custID`='" + id + "';";

                    if (dbCon.insertQuery(query, dbCon.Connection))
                    {
                        query = "UPDATE `location_details_t` SET `locationAddress`='" + locationAddressTb.Text + "',`locationCity`='" + locationCityTb.Text + "',`locationProvinceID`='" + custProvinceCust.SelectedValue + "' WHERE `locationId`='" + locId + "';";
                        if (dbCon.insertQuery(query, dbCon.Connection))
                        {

                            query = "UPDATE `customer_contacts_t` SET `officePhoneNo`='" + officeNumber.Text + "',`mobileNo`='" + mobileNumTb.Text + "' WHERE `custID`='" + id + "';";
                            if (dbCon.insertQuery(query, dbCon.Connection))
                            {
                                MessageBox.Show(" is added on the database.");
                            }
                        }
                    }
                }
            }
            else if(result == MessageBoxResult.No)
            {
                this.Close();
            }
            else if (result == MessageBoxResult.Cancel)
            {
            }

        }
        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            setControlsValues();
            setControlValuesSynced(id);
        }

        
    }
}
