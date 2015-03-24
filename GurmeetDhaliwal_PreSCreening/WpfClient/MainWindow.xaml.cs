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

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceReference1.CarServiceClient client = new ServiceReference1.CarServiceClient();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                client.addCar(txt_manufacture.Text, txt_make.Text, txtcolor.Text, Convert.ToDateTime(dtselect.Text),Convert.ToInt32(txt_seating.Text));
                MessageBox.Show("Car was added to the database");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter valid information");
            }

        }


        private void btnGetList_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                DataGrid1.ItemsSource = client.getAllCars();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }



    }

}
