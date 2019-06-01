using DataAccessLayer.cs.Models;
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

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public Card card;
        public int counter;
        List<Card> cards = new List<Card>();
        public MainWindow()
        {
            InitializeComponent();
            
            //cards.Add(GenerateNewCard());
            //cards.Add(GenerateNewCard());
            //cards.Add(GenerateNewCard());
            //cards.Add(GenerateNewCard());
            //cards.Add(GenerateNewCard());

            //lb.ItemsSource = cards;
           
        }
        private void AddNewTaskBtn_Click(object sender, RoutedEventArgs e)
        {

            Button button = new Button();
            button.Content = GenerateNewCard().Name;
            button.Click += CardBtn_Click;
            button.HorizontalContentAlignment = HorizontalAlignment.Left;
            
            ColumnCards(sender).Add(button);
        }
        public Card GenerateNewCard()
        {
            Card card = new Card { CreationDate = DateTime.Now, ExpireDate = DateTime.Now.AddDays(10), Description = "asdasd", Name = "Task" + counter++ };
            return card;
        }
        private void CardBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Description","Edit Task Window");
        }

        private void MoveTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ColumnCards(sender).Count > 3)
            {
                Button b = new Button();
                b = (ColumnCards(sender)[ColumnCards(sender).Count - 1]) as Button;

                if (NextColumnCards(sender) != null)
                {
                    ColumnCards(sender).Remove(b);
                    NextColumnCards(sender).Add(b);
                }
            }
        }


        public UIElementCollection ColumnCards(object sender)
        {
            return ((sender as Button).Parent as StackPanel).Children;
        }
        public UIElementCollection NextColumnCards(object sender)
        {
            try
            {
                return ((Columns(sender)[ColumnIndex(sender) + 1] as Border).Child as StackPanel).Children;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public UIElementCollection Columns(object sender)
        {
            return ((((sender as Button).Parent as StackPanel).Parent as Border).Parent as StackPanel).Children;
        }
        public int ColumnIndex(object sender)
        {
            return Columns(sender).IndexOf(((sender as Button).Parent as StackPanel).Parent as Border);
        }

    }
}
