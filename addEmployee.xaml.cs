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
        public String FName { get; set; }
        public String MName { get; set; }
        public String LName { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String Number { get; set; }
        public String Email { get; set; }
        public object locProvinceId { get; set; }
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
                provinceCb.ItemsSource = fromDb.Tables["t"].DefaultView;
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
        byte[] picdata;
        byte[] sigdata;
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
                    picdata = br.ReadBytes((int)fs.Length);
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
            this.Close();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = dbname;
            MessageBoxResult result = MessageBox.Show("Do you want to save this new customer?", "Confirmation", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                if (dbCon.IsConnect())
                {
                    string query = "INSERT INTO location_details_t (locationAddress,locationCity,locationProvinceID) VALUES ('" + addressTb.Text + "','" + cityTb.Text + "', '" + provinceCb.SelectedValue + "')";

                    if (dbCon.insertQuery(query, dbCon.Connection))
                    {
                        query = "select last_insert_id() from location_details_t";
                        MySqlDataAdapter dataAdapter = dbCon.selectQuery(query, dbCon.Connection);
                        DataSet fromDb = new DataSet();
                        dataAdapter.Fill(fromDb, "t");
                        string locID = "";
                        foreach (DataRow myRow in fromDb.Tables[0].Rows)
                        {
                            locID = myRow[0].ToString();
                        }
                        string pass = RandomString(9);
                        string query1 = "INSERT INTO employee_t (empFname,empLname,empMI,empEmail,empContacts,position,password,locationID) VALUES ('" + firstNameTb.Text + "','" + lastNameTb.Text + "','" + middleInitialTb.Text + "','" + emailAddressTb.Text + "','" + mobileNumberTb.Text + "','" + postionCb.SelectedValue+ "','" + pass + "','" + locID + "')";
                        if (dbCon.insertQuery(query1, dbCon.Connection))
                        {
                            
                            query = "select last_insert_id() from employee_t";
                            dataAdapter = dbCon.selectQuery(query, dbCon.Connection);
                            fromDb = new DataSet();
                            dataAdapter.Fill(fromDb, "t");
                            string empId = "";
                            foreach (DataRow myRow in fromDb.Tables[0].Rows)
                            {
                                empId = myRow[0].ToString();
                            }
                            try
                            {
                                string connstring = string.Format("Server=localhost; database={0}; UID=root; password=password", dbname);
                                MySqlConnection conn = new MySqlConnection(connstring);
                                conn.Open();
                                MySqlCommand cmd = new MySqlCommand("insert into emp_pic_t(empPic,empSignature,empId)" +
                                    " values(@picture,@signature,'"+empId+"')", conn);
                                cmd.Parameters.Add("@picture", MySqlDbType.LongBlob);
                                cmd.Parameters["@picture"].Value = picdata;
                                cmd.Parameters.Add("@signature", MySqlDbType.MediumBlob);
                                cmd.Parameters["@signature"].Value = SignatureToBitmapBytes();
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                MessageBox.Show("Saved");
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                }
            }
            else if (result == MessageBoxResult.No)
            {
                this.Close();
            }
            else if (result == MessageBoxResult.Cancel)
            {
            }
        }

        

        Random random = new Random();
        private string RandomString(int Size)
        {
            string input = "abcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < Size; i++)
            {
                ch = input[random.Next(0, input.Length)];
                builder.Append(ch);
            }
            return builder.ToString();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            this.MyInkCanvas.Strokes.Clear();
        }
        private byte[] SignatureToBitmapBytes()
        {
            ////get the dimensions of the ink control
            //int margin = (int)this.MyInkCanvas.Margin.Left;
            //int width = (int)this.MyInkCanvas.ActualWidth - margin;
            //int height = (int)this.MyInkCanvas.ActualHeight - margin;
            ////render ink to bitmap
            //RenderTargetBitmap rtb =
            //new RenderTargetBitmap(width, height, 96d, 96d, PixelFormats.Pbgra32);
            //rtb.Render(MyInkCanvas);
            ////save the ink to a memory stream

            //    RenderTargetBitmap renderBitmap = new RenderTargetBitmap(
            //(int)MyInkCanvas.Width, (int)MyInkCanvas.Height,
            //96d, 96d, PixelFormats.Pbgra32);
            //    // needed otherwise the image output is black
            //    MyInkCanvas.Measure(new Size((int)MyInkCanvas.Width, (int)MyInkCanvas.Height));
            //    MyInkCanvas.Arrange(new Rect(new Size((int)MyInkCanvas.Width, (int)MyInkCanvas.Height)));

            //    renderBitmap.Render(MyInkCanvas);


            //    PngBitmapEncoder encoder = new PngBitmapEncoder();
            //    encoder.Frames.Add(BitmapFrame.Create(renderBitmap));


            Rect bounds = VisualTreeHelper.GetDescendantBounds(MyInkCanvas);
            double dpi = 96d;

            RenderTargetBitmap rtb = new RenderTargetBitmap((int)bounds.Width, (int)bounds.Height, dpi, dpi, System.Windows.Media.PixelFormats.Default);
            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                VisualBrush vb = new VisualBrush(MyInkCanvas);
                dc.DrawRectangle(vb, null, new Rect(new Point(), bounds.Size));
            }
            rtb.Render(dv);

            string fileName = @"C:\sad\out" + firstNameTb.Text + "" + lastNameTb.Text + ".png";
            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(rtb));
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                pngEncoder.Save(ms);
                System.IO.File.WriteAllBytes(fileName, ms.ToArray());
            }
            //using (FileStream file = File.Create (fileName))
            //{
            //    encoder.Save(file);
            //}
            byte[] bitmapBytes = getSig(fileName);
            return bitmapBytes;
        }
        private byte[] getSig(string fileName)
        {
            byte[] bitmapBytes = null;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            empImage.Source = new BitmapImage(new Uri(fileName));
            bitmapBytes = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            return bitmapBytes;
        }

        private void firstNameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateTextBoxes();
        }

        private void middleInitialTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateTextBoxes();
        }

        private void lastNameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateTextBoxes();
        }

        private void addressTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateTextBoxes();
        }

        private void cityTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateTextBoxes();
        }

        private void provinceCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            validateTextBoxes();
        }

        private void mobileNumberTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateTextBoxes();
        }

        private void emailAddressTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateTextBoxes();
        }

        private void postionCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            validateTextBoxes();
        }
        private void validateTextBoxes()
        {
            if (firstNameTb.Text.Equals("") || lastNameTb.Text.Equals("") || middleInitialTb.Text.Equals("") || provinceCb.SelectedIndex == -1 || cityTb.Text.Equals("") || emailAddressTb.Text.Equals("") || mobileNumberTb.Text.Equals("") || postionCb.SelectedIndex == -1)
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
