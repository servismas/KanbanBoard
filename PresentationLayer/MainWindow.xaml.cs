using DataAccessLayer.cs.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public static ObservableCollection <Card> cards;
        public MainWindow()
        {
            InitializeComponent();
            cards = new ObservableCollection<Card>();
            cards.CollectionChanged += Cards_CollectionChanged;
            sp2.DataContext = cards;
            //cards.Add(GenerateNewCard());
            //cards.Add(GenerateNewCard());
            //cards.Add(GenerateNewCard());
            //cards.Add(GenerateNewCard());
            //cards.Add(GenerateNewCard());

            //lb.ItemsSource = cards;

        }

        private void Cards_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddNewTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = new Button();
            //button.Content = GenerateNewCard().Name;
            CardEditWindow cardEditWindow = new CardEditWindow();
            cardEditWindow.ShowDialog();
            button.Click += CardBtn_Click;
            button.HorizontalContentAlignment = HorizontalAlignment.Left;
            
            ColumnCards(sender).Add(button);
        }
        public Card GenerateNewCard()
        {
            CardEditWindow cardEditWindow = new CardEditWindow();
            cardEditWindow.ShowDialog();
           // if(cardEditWindow.DialogResult == DialogResult.
            Card card = new Card { CreationDate = DateTime.Now, ExpireDate = DateTime.Now.AddDays(10), Description = "asdasd", Name = "Task" + counter++ };
            return card;
        }
        private void CardBtn_Click(object sender, RoutedEventArgs e)
        {
            CardEditWindow cardEditWindow = new CardEditWindow();
            cardEditWindow.ShowDialog();
            //MessageBox.Show("Description","Edit Task Window");
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


        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            //Button dragSource = sender as Button;
            Button button = sender as Button;
            if (/*button != null && */e.LeftButton == MouseButtonState.Pressed)
            {
            MessageBox.Show("Button_MouseMove");
                //dragSource.AllowDrop = true;
                //DataObject data = new DataObject(typeof(Button), dragSource);
                //DragDrop.DoDragDrop(dragSource, data, DragDropEffects.Copy | DragDropEffects.Move);
                DragDrop.DoDragDrop(button, button.Content, DragDropEffects.Copy | DragDropEffects.Move);
            }
            //DragDrop.DoDragDrop(b, b.Content, DragDropEffects.Copy);
        }

        private void Border_Drop(object sender, DragEventArgs e)
        {
            MessageBox.Show("Border_Drop");
        }

        private void Button_DragEnter(object sender, DragEventArgs e)
        {
            MessageBox.Show("Button_DragEnter");

        }

        private void Button_DragLeave(object sender, DragEventArgs e)
        {
            MessageBox.Show("Button_DragLeave");

        }

        private void Button_DragOver(object sender, DragEventArgs e)
        {
            MessageBox.Show("Button_DragOver");

        }

        private void Button_Drop(object sender, DragEventArgs e)
        {
            MessageBox.Show("Button_Drop");

        }

        private void Button_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            MessageBox.Show("Button_GiveFeedback");

        }

        //private void Border_MouseMove(object sender, MouseEventArgs e)
        //{
        //    (sender as Border).AllowDrop
        //}





        //private void ListViewOnMouseMove(object sender, MouseEventArgs mouseEventArgs)
        //{
        //    //dragSource = (sender as ListView);
        //    if (mouseEventArgs.LeftButton == MouseButtonState.Pressed)
        //    {
        //        if (dragSource.SelectedItems.Count > 0)
        //        {
        //            var items = (dragSource.SelectedItems as IList);
        //            dragSource.AllowDrop = true;
        //            DataObject dataObject = new DataObject(typeof(Collection), items);
        //            DragDrop.DoDragDrop((sender as ListView), dataObject, DragDropEffects.Copy);
        //        }
        //    }
        //}


    }
}
