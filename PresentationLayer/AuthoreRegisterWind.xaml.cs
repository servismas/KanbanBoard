using PresentationLayer.ViewModels;
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
using WcfBussinesLogicLayerLibrary.ModelsDTO;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for AuthoreRegisterWind.xaml
    /// </summary>
    public partial class AuthoreRegisterWind : Window
    {
        public UserDTO curUser = null;
        public AuthoreRegisterWind()
        {
            InitializeComponent();
            LoginRegistrationViewModel loginClass = new LoginRegistrationViewModel();
            DataContext = loginClass;
            curUser = loginClass.CurrentUser;
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            LogBtn.Visibility = Visibility.Collapsed;
            RegBtn.Visibility = Visibility.Collapsed;
            FirstNameBlock.Visibility = Visibility.Visible;
            FirstNameBox.Visibility = Visibility.Visible;
            SecondNameBlock.Visibility = Visibility.Visible;
            SecondNameBox.Visibility = Visibility.Visible;
            PhotoBox.Visibility = Visibility.Visible;
            TeamBlock.Visibility = Visibility.Visible;
            TeamBox.Visibility = Visibility.Visible;

            ContBtn.Visibility = Visibility.Visible;
            CanslBtn.Visibility = Visibility.Visible;
        }
        

       
    }
}
