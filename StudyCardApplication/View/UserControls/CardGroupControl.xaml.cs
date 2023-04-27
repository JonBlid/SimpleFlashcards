using StudyCardApplication.Model;
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

namespace StudyCardApplication.View.UserControls
{
    /// <summary>
    /// Interaction logic for CardGroupControl.xaml
    /// </summary>
    public partial class CardGroupControl : UserControl
    {
        public CardGroup CardGroup
        {
            get { return (CardGroup)GetValue(CardGroupProperty); }
            set { SetValue(CardGroupProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CardGroup.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CardGroupProperty =
            DependencyProperty.Register("CardGroup", typeof(CardGroup), typeof(CardGroupControl), new PropertyMetadata(null, SetValues));

        private static void SetValues(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CardGroupControl cardGroupControl = (CardGroupControl)d;

            if (cardGroupControl != null)
            {
                cardGroupControl.DataContext = cardGroupControl.CardGroup;
            }
        }

        public CardGroupControl()
        {
            InitializeComponent();
        }
    }
}
