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

namespace ModernUi.WPF.Common
{
    public partial class BackPageLayout : UserControl
    {
        public static readonly DependencyProperty BackCommandProperty = DependencyProperty.Register(
           "BackCommand",
           typeof(ICommand),
           typeof(BackPageLayout)
           );
        public ICommand BackCommand
        {
            get { return (ICommand)GetValue(BackCommandProperty); }
            set { SetValue(BackCommandProperty, value); }
        }

        public static readonly DependencyProperty NavBarItemsProperty =
            DependencyProperty.Register(
                "NavBarItems",
                typeof(UIElement),
                typeof(BackPageLayout),
                new PropertyMetadata(null)
                );

        public UIElement NavBarItems
        {
            get { return (UIElement)GetValue(NavBarItemsProperty); }
            set { SetValue(NavBarItemsProperty, value); }
        }
        public BackPageLayout()
        {
            InitializeComponent();
        }
    }
}
