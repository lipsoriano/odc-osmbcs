using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    /// Interaction logic for addEmployee.xaml
    /// </summary>
    public partial class addEmployee : Window
    {
        public addEmployee()
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
            String[] posTypeArr = { };
            String posTypeSettings = Properties.Settings.Default.posType.ToString();
            posTypeArr = posTypeSettings.Split(',');
            if (postionCb.Items.IsEmpty)
            {
                foreach (String reTypeString in posTypeArr)
                {
                    postionCb.Items.Add(reTypeString);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            setControlsValues();
        }
        byte[] data;
        private void openFileBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    empImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                    data = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
