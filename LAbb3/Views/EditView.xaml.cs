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
    /// Interaction logic for EditView.xaml
    /// </summary>
    public partial class EditView : UserControl
    {
        public EditView()
        {
            InitializeComponent();

        }

        //ItemsSource="{Binding CreateView.xaml._selectedQuiz.questions}"/> i xaml för att få listor i combobox?

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
        }
    }

}
