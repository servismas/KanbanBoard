using DataAccessLayer.cs;
using DataAccessLayer.cs.Models;
using DataAccessLayer.cs.Repository;
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
    /// Interaction logic for CardEditWindow.xaml
    /// </summary>
    public partial class CardEditWindow : Window
    {
 
        public CardEditWindow()
        {
            InitializeComponent();

            using (KanbanBoardContext db = new KanbanBoardContext())
            {
                Card card = new Card();
                Repository<Card> rep = new Repository<Card>(db);
                card = rep.Find(1);

                cardName_tb.Text = card.Name;
                description_tb.Text = card.Description;
            }
        }
    }
}
