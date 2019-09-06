using MySql.Data.MySqlClient;
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
using System.Data;

namespace SQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Game;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
        SqlCommand cmd;
        SqlDataAdapter adpat;
        int ID = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != "" && txtGame.Text != "" && txtType.Text != "" && txtReview.Text != "")
            {
                cmd = new SqlCommand("insert into Game(name,game,type,review) values(@Name,@Game,@Type,@Review) ", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Game", txtGame.Text);
                cmd.Parameters.AddWithValue("@Type", txtType.Text);
                cmd.Parameters.AddWithValue("@Review", txtReview.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Record Inserted");
                // DisplayData();

            }
            else
            {
                MessageBox.Show("Error");
            }
            //    using (MySqlConnection conn = new MySqlConnection(connectionString))
            //{
            //    conn.Open();
            //    MySqlCommand mySqlCmd = new MySqlCommand("Game",conn);
            //    mySqlCmd.CommandType = CommandType.StoredProcedure;
            //    mySqlCmd.Parameters.AddWithValue("Name", txtName.Text.Trim());
            //    mySqlCmd.Parameters.AddWithValue("Game", txtGame.Text.Trim());
            //    mySqlCmd.Parameters.AddWithValue("Type", txtType.Text.Trim());
            //    mySqlCmd.Parameters.AddWithValue("Review", txtReview.Text.Trim());
            //    mySqlCmd.ExecuteNonQuery();
            //    MessageBox.Show("Inserted");
            //   GridFill();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                string view = "SELECT * FROM Game";
                SqlCommand cmd = new SqlCommand(view, conn); 
                cmd.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Game");
                dataAdp.Fill(dt);
                datagrid1.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);
                conn.Close();
                
                }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }
 }
    }


        //private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}
    

