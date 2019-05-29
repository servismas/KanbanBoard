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

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for AuthoreRegisterWind.xaml
    /// </summary>
    public partial class AuthoreRegisterWind : Window
    {
        public AuthoreRegisterWind()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            teamBlock.Visibility = Visibility.Visible;
            teamBox.Visibility = Visibility.Visible;
            btn1.Content = "Continue";
            btn2.Content = "Cancel";
        }
    }
}
