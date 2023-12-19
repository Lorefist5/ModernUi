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

namespace ModernUi.WPF.Components
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {



        public ICommand NavigateToEdit
        {
            get { return (ICommand)GetValue(NavigateToEditProperty); }
            set { SetValue(NavigateToEditProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NavigateToEdit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NavigateToEditProperty =
            DependencyProperty.Register("NavigateToEdit", typeof(ICommand), typeof(UserView));


        public ICommand NavigateToDelete
        {
            get { return (ICommand)GetValue(NavigateToDeleteProperty); }
            set { SetValue(NavigateToDeleteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NavigateToDelete.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NavigateToDeleteProperty =
            DependencyProperty.Register("NavigateToDelete", typeof(ICommand), typeof(UserView));


        public UserView()
        {
            InitializeComponent();
        }
    }
}
