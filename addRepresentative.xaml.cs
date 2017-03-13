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
using System.Windows.Shapes;

namespace prototype2
{
    /// <summary>
    /// Interaction logic for addRepresentative.xaml
    /// </summary>
    public partial class addRepresentative : Window
    {
        
        public addRepresentative()
        {
            InitializeComponent();
        }
        public string custName { get; set; }
        public string custId { get; set; }
        private void setControlsValue()
        {
            companyNameLbl.Content = custName;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            setControlsValue();
        }
        private static String dbname = "odc_db";
        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = dbname;
            if (dbCon.IsConnect())
            {
                string query = "INSERT INTO customer_rep_t (custRepLname,custRepFname,custRepMi,custID,companyRepMobileNo,companyRepEmail) VALUES ('" + lastNameTb.Text + "','" + firstNameTb.Text + "', '" + middleInitialTb.Text + "','" + custId + "','" + mobileNumTb.Text + "','" + emailAddressTb.Text + "')";

                if (dbCon.insertQuery(query, dbCon.Connection))
                {
                    MessageBox.Show("Customer's Representative Details is successfully inserted");
                }
            }
        }
    }
}
