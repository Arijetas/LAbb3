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

namespace LAbb3.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void EditView_Click(object sender, RoutedEventArgs e)
        {
            if (EditViewFld.Visibility != Visibility.Visible)
            {
                EditViewFld.Visibility = Visibility.Visible;
                PlayViewFld.Visibility = Visibility.Collapsed;
                CreateViewFld.Visibility = Visibility.Collapsed;
            }

        }

        private void PlayView_Click(object sender, RoutedEventArgs e)
        {
            if (PlayViewFld.Visibility != Visibility.Visible)
            {
                PlayViewFld.Visibility = Visibility.Visible;
                EditViewFld.Visibility = Visibility.Collapsed;
                CreateViewFld.Visibility = Visibility.Collapsed;
            }
        }

        private void CreateView_Click(object sender, RoutedEventArgs e)
        {
            if (CreateViewFld.Visibility != Visibility.Visible)
            {
                CreateViewFld.Visibility = Visibility.Visible;
                EditViewFld.Visibility = Visibility.Collapsed;
                PlayViewFld.Visibility = Visibility.Collapsed;
            }
        }
    }
}
