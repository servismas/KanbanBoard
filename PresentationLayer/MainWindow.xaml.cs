using DataAccessLayer.cs;
using DataAccessLayer.cs.Models;
using DataAccessLayer.cs.Repository;
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
using WcfBussinesLogicLayerLibrary.ModelsDTO;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
static class Test
    {
        public static object GetObjectAtPoint<ItemContainer>(this ItemsControl control, Point p)
                                   where ItemContainer : DependencyObject
        {
            // ItemContainer - can be ListViewItem, or TreeViewItem and so on(depends on control) 
            ItemContainer obj = GetContainerAtPoint<ItemContainer>(control, p);
            if (obj == null)
                return null;

            return control.ItemContainerGenerator.ItemFromContainer(obj);
        }

        public static ItemContainer GetContainerAtPoint<ItemContainer>(this ItemsControl control, Point p)
                                 where ItemContainer : DependencyObject
        {
            HitTestResult result = VisualTreeHelper.HitTest(control, p);
            if (result != null)
            {
                DependencyObject obj = result.VisualHit;

                while (VisualTreeHelper.GetParent(obj) != null && !(obj is ItemContainer))
                {
                    obj = VisualTreeHelper.GetParent(obj);
                }

                // Will return null if not found 
                return obj as ItemContainer;
            }
            else return null;
        }
    }

    public partial class MainWindow : Window
    {
        //public Card card;
        public int counter=1;
        public static ObservableCollection <Card> column1, column2, column3, column4;
        public static ObservableCollection<Column> board;
        Repository<Card> cardsRepository;
        Repository<Column> columnRepository;
        StackPanel sp;
        
        public MainWindow()
        {
            InitializeComponent();
            //AuthoreRegisterWind authoreRegisterWind = new AuthoreRegisterWind();
             //authoreRegisterWind.ShowDialog();
            //LogONService.LogOnUserContractClient LogOnClient = new LogONService.LogOnUserContractClient();                     //Test
           // UserDTO curUser = LogOnClient.CheckCredationals("qwerty@qwerty.com", "�࿬쿢䘰囘燶朗㾨ꋷﱊｴ쐺쬌꤅꽿蟡얂翾邊谮蘷쮥␶荜ഓ倽⩣戜悧緖䤍");       //Test
                                                                                                                            // UserDTO curUser = authoreRegisterWind.curUser;
            ReadFromDb();
        }
        public void ReadFromDb()
        {
            board = new ObservableCollection<Column>();

            column1 = new ObservableCollection<Card>();
            column2 = new ObservableCollection<Card>();
            column3 = new ObservableCollection<Card>();
            column4 = new ObservableCollection<Card>();
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                cardsRepository = new Repository<Card>(db);
                columnRepository = new Repository<Column>(db);
                //main_listBox .ItemsSource = board;


                //foreach (Column column in columnRepository.GetAll())
                //{
                //    board.Add(column);
                //    //foreach (Card card in cardsRepository.GetAll(x => x.ColumnId == column.Id))
                //    //{
                //    //    board.
                //    //    column1.Add(card);
                //    //}
                //}
                //foreach (Card card in board[0].Cards)
                //{

                //    CardButton b = new CardButton();
                //    b.Content = card.Name;
                //    //column1.Add(card);
                //}





                foreach (Card card in cardsRepository.GetAll(x => x.ColumnId == 1))
                {
                    column1.Add(card);
                }
                foreach (Card card in cardsRepository.GetAll(x => x.ColumnId == 2))
                {
                    column2.Add(card);
                }
                foreach (Card card in cardsRepository.GetAll(x => x.ColumnId == 3))
                {
                    column3.Add(card);
                }
                foreach (Card card in cardsRepository.GetAll(x => x.ColumnId == 4))
                {
                    column4.Add(card);
                }



                //column2.Add(new Card { Name = "xdfsdfg", Description = "dfgasdfgasfdgasfgsafgasfg" });
            }
            borderListBox1.ItemsSource = column1;
            borderListBox2.ItemsSource = column2;
            borderListBox3.ItemsSource = column3;
            borderListBox4.ItemsSource = column4;
        }

        //private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    // Retrieve the coordinate of the mouse position.
        //    Point pt = e.GetPosition((UIElement)sender);

        //    // Perform the hit test against a given portion of the visual object tree.
        //    HitTestResult result = VisualTreeHelper.HitTest(main_listBox, pt);

        //    if (result != null)
        //    {
        //        MessageBox.Show(result.ToString());
        //    }
        //}

        private void ListBox_Drop(object sender, DragEventArgs e)
        {
            //Test.GetObjectAtPoint(sender, e.GetPosition);
           // MessageBox.Show(main_listBox.SelectedIndex.ToString());
            //counter = 0;
            //UIElement _destinationList=null;
            //UIElement _element = (UIElement)e.Data.GetData("Object");
                CardButton b = (CardButton)e.Data.GetData("Object");
            //ListBox _sourceListBox = (ListBox)_element;
           // ListBox _destinationListBox = new ListBox();
            //Border _border = new Border();
            //string str="";



            //UIElement _element = (UIElement)sender;
            //try
            //{
            //    do
            //    {
            //        str += _element.ToString() + "\n\r";
            //        _element = (UIElement)VisualTreeHelper.GetParent(_element);
            //        if ((UIElement)VisualTreeHelper.GetParent(_element) is ListBox && _element is Border)
            //        {
            //            _destinationList = (UIElement)VisualTreeHelper.GetParent(_element);
            //           // if(destinationList.)
            //            _border = (Border)_element;
            //            //foreach (Border item in (_destinationList as ListBox).Items)
            //            //{
            //            //    _border.Equals(item);
            //            //}
            // //   MessageBox.Show((_destinationList as ListBox).ind);

            //           // break;

            //        }
            //    } while (true);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show(str);
            //}
            //MessageBox.Show(main_listBox.ItemsSource.ToString());





            //    UIElement _e = (UIElement)VisualTreeHelper.GetParent(_element);
            //try
            //{
            //    while (
            //        !(_e is ListBox) ||                     !((_e as ListBox)?.Name == "main_listBox")
            //        /*(VisualTreeHelper.GetParent(_element) != null) || *//*!(_element is StackPanel) &&*/
            //        /*(_element as StackPanel).Name != "MainStackPanel"*/)
            //    {
            //        _element = (UIElement)VisualTreeHelper.GetParent(_element);
            //        _e = (UIElement)VisualTreeHelper.GetParent(_element);
            //        str += _element.ToString() + "\n\r";

            //        if (_element is ListBox)
            //            destinationList = _element;
            //        counter++;
            //    }
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show(str+"\r\n" +counter.ToString());
            //}
            // MessageBox.Show(main_listBox.Items.IndexOf(destinationList).ToString());
            //    MessageBox.Show(str + "\r\n" + counter.ToString());
            //try
            //{
            //    while (true)
            //    {
            //        _element = (UIElement)VisualTreeHelper.GetParent(_element);

            //        str += _element.ToString() + "\n\r";
            //        counter++;
            //    }
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show(str + "\r\n" + counter.ToString());
            //}
            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                cardsRepository = new Repository<Card>(db);
                //columnRepository = new Repository<Column>(db);
                //MessageBox.Show(MainStackPanel.Children.IndexOf(_destinationListBox).ToString());
                //MessageBox.Show((_destinationListBox.Parent as StackPanel).Children.IndexOf(_destinationListBox).ToString());
                //MessageBox.Show(b.Tag.ToString());
                Card c = cardsRepository.Find((int)b.Tag);
                //main_listBox.Items.IndexOf
                int newColumnId = Convert.ToInt32((sender as ListBox).Tag);
                c.ColumnId = newColumnId;
                //c.Column = columnRepository.Find((int)c.ColumnId);
                cardsRepository.Edit(c);
            }

            ReadFromDb();

        }

        //private void GrebanajaSP_Loaded(object sender, RoutedEventArgs e)
        //{
        //    StackPanel sp = sender as StackPanel;
        //   // sp.Children;
        //}

        //private void GrebanajaSP_Loaded(object sender, EventArgs e)
        //{
        //    StackPanel sp = sender as StackPanel;

        //}

        private void GrebanajaSP_Initialized(object sender, EventArgs e)
        {
            sp = sender as StackPanel;
           // UIElementCollection col = sp.Children;

        }

        private void AddNewTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            CardEditWindow cardEditWindow = new CardEditWindow();
            cardEditWindow.Owner = this;
            cardEditWindow.ShowDialog();
        }
        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MessageBox.Show("Button_MouseMove");
                // Package the data.
                DataObject data = new DataObject();
                data.SetData("Object", this);

                // Inititate the drag-and-drop operation.
                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }
        private void Button_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                MessageBox.Show("Button_PreviewMouseMove");
                // Package the data.
                DataObject data = new DataObject();
                data.SetData("Object", this);

                // Inititate the drag-and-drop operation.
                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }
    }
}
