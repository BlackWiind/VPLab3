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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace VPLab3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //string connectionString;
        public MainWindow()
        {
            InitializeComponent();
            //connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;  
            //TestView();
        }
        
        private void TestView(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = null;
            string cmd = "SELECT * FROM Факультет";
            try
            {
                connection = new SqlConnection(@"server=localhost\SQLSERVER;database=labbase;User Id=lab;Password=12345678");                
                connection.Open();
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();

                SqlDataAdapter dataAdapt = new SqlDataAdapter(createCommand);
                DataTable dt = new DataTable("Факультет");
                dataAdapt.Fill(dt);
                Faculty.ItemsSource = dt.DefaultView;                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
        

       

    }
}
