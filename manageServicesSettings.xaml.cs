
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
    /// Interaction logic for manageServicesSettings.xaml
    /// </summary>
    public partial class manageServicesSettings : Window
    {
        private static String dbname = "odc_db";
        public String Name { get; set; }
        String id = "";
        public manageServicesSettings()
        {
            InitializeComponent();
            serviceName.DataContext = this;
        }

        private void addServiceTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            serviceTypeList.Visibility = Visibility.Collapsed;
            serviceTypeAdd.Visibility = Visibility.Visible;
        }

        private void cancelServiceTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            serviceTypeList.Visibility = Visibility.Visible;
            serviceTypeAdd.Visibility = Visibility.Collapsed;
            setWindowControls();
        }

        private void setWindowControls()
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = dbname;
            if (dbCon.IsConnect())
            {
                string query = "SELECT * FROM service_t;";
                MySqlDataAdapter dataAdapter = dbCon.selectQuery(query, dbCon.Connection);
                DataSet fromDb = new DataSet();
                dataAdapter.Fill(fromDb, "t");
                serviceTypeDg.ItemsSource = fromDb.Tables["t"].DefaultView;
                dbCon.Close();
            }
        }

        private void serviceName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Windows.Controls.Validation.GetHasError(serviceName) == true)
                saveServiceTypeBtn.IsEnabled = false;
            else validateTextBoxes();
        }

        private void servicePrice_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            validateTextBoxes();
        }

        private void validateTextBoxes()
        {
            if (serviceName.Text.Equals("") || servicePrice.Value==0)
            {
                saveServiceTypeBtn.IsEnabled = false;
            }
            else
            {
                saveServiceTypeBtn.IsEnabled = true;
            }
        }

        private void saveServiceTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = dbname;
            MessageBoxResult result = MessageBox.Show("Do you want to save this service type?", "Confirmation", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                if (id.Equals(""))
                {
                    string query = "INSERT INTO service_t (serviceName,serviceDesc,servicePrice) VALUES ('" + serviceName.Text + "','" + serviceDesc.Text + "', '" + servicePrice.Value + "')";
                    if (dbCon.insertQuery(query, dbCon.Connection))
                    {
                        MessageBox.Show("Added");
                        serviceTypeList.Visibility = Visibility.Visible;
                        serviceTypeAdd.Visibility = Visibility.Collapsed;
                        setWindowControls();
                    }
                }
                else
                {
                    string query = "UPDATE `service_T` SET serviceName = '" + serviceName.Text + "',serviceDesc = '" + serviceDesc.Text + "', servicePrice = '" + servicePrice.Value + "' WHERE serviceID = '" + id + "'";
                    if (dbCon.insertQuery(query, dbCon.Connection))
                    {
                        MessageBox.Show("Updated");
                        id = "";
                        serviceTypeList.Visibility = Visibility.Visible;
                        serviceTypeAdd.Visibility = Visibility.Collapsed;
                        setWindowControls();
                    }
                }
                
            }
            else if (result == MessageBoxResult.No)
            {
                for (int x = 1; x < serviceTypeGrid.Children.Count; x++)
                {
                    serviceTypeGrid.Children[x].Visibility = Visibility.Collapsed;
                }
                serviceTypeList.Visibility = Visibility.Visible;
                setWindowControls();
            }
            else if (result == MessageBoxResult.Cancel)
            {
            }
            
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = dbname;
            if (serviceTypeDg.SelectedItems.Count > 0)
            {
                id = (serviceTypeDg.Columns[0].GetCellContent(serviceTypeDg.SelectedItem) as TextBlock).Text;
                serviceTypeList.Visibility = Visibility.Collapsed;
                serviceTypeAdd.Visibility = Visibility.Visible;
                string query = "SELECT * FROM service_t where serviceID = '"+id+"';";
                MySqlDataAdapter dataAdapter = dbCon.selectQuery(query, dbCon.Connection);
                DataSet fromDb = new DataSet();
                dataAdapter.Fill(fromDb, "t");
                DataTable fromDbTable = new DataTable();
                fromDbTable = fromDb.Tables["t"];
                foreach (DataRow dr in fromDbTable.Rows)
                {
                    try
                    {
                        serviceName.Text = dr["serviceName"].ToString();
                        serviceDesc.Text = dr["serviceDesc"].ToString();
                        servicePrice.Text = dr["servicePrice"].ToString();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                dbCon.Close();
                serviceTypeList.Visibility = Visibility.Collapsed;
                serviceTypeAdd.Visibility = Visibility.Visible;
            }
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            setWindowControls();
        }

        private void serviceTypeDg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Visual visual = e.OriginalSource as Visual;
            if (visual.IsDescendantOf(serviceTypeDg))
            {
                if (serviceTypeDg.SelectedItems.Count > 0)
                {
                    serviceTypeDg.Columns[4].Visibility = Visibility.Visible;
                    serviceTypeDg.Columns[5].Visibility = Visibility.Visible;
                }
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Visual visual = e.OriginalSource as Visual;
            if (!visual.IsDescendantOf(serviceTypeDg))
            {
                if (serviceTypeDg.SelectedItems.Count > 0)
                {
                    serviceTypeDg.Columns[4].Visibility = Visibility.Hidden;
                    serviceTypeDg.Columns[5].Visibility = Visibility.Hidden;
                }
            }
        }

        
    }
}
