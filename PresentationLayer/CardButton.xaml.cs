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
    /// Interaction logic for CardButton.xaml
    /// </summary>
    public partial class CardButton : UserControl
    {
        public CardButton()
        {
            InitializeComponent();
        }

        private void DrugBtn_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                // Package the data.
                DataObject data = new DataObject();
                data.SetData("Object", this);

                // Inititate the drag-and-drop operation.
                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        private void DrugBtn_Click(object sender, RoutedEventArgs e)
        {
            UIElement _element = this;
            while (!(_element is MainWindow))
            {
                _element = (UIElement)VisualTreeHelper.GetParent(_element);
            }
            //MessageBox.Show(_element.ToString());
            //(_element as MainWindow).ReadFromDb();
            CardEditWindow cardEditWindow = new CardEditWindow((int)(sender as Button).Tag);
            cardEditWindow.Owner = (_element as MainWindow);
            cardEditWindow.Show();
            // cardEditWindow.ShowDialog();
        }

        private void DrugBtnUI_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && (e.OriginalSource is Button))
            {
                // Package the data.
                DataObject data = new DataObject();
                data.SetData("Object", this);

                // Inititate the drag-and-drop operation.
                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        //private void DrugBtnUI_PreviewMouseMove(object sender, MouseEventArgs e)
        //{
        //    if (e.LeftButton == MouseButtonState.Pressed)
        //    {
        //        // Package the data.
        //        DataObject data = new DataObject();
        //        data.SetData("Object", this);

        //        // Inititate the drag-and-drop operation.
        //        DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
        //    }
        //}
    }
