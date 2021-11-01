using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LAbb3.Views
{
    /// <summary>
    /// Interaction logic for CreateView.xaml
    /// </summary>
    public partial class CreateView : UserControl
    {

        public CreateView()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (TitleTextBox.Text is null or "")
            {
                return;
            }

           // string path @"C:\LAbb3\Text.txt";
           // using (var writer = new StreamWriter(path))
            {
                
            }
        }
    }
}
