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
    /// <summary>
    /// Interaction logic for MainpageLayout.xaml
    /// </summary>
    public partial class MainpageLayout : UserControl
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
       "Title",
       typeof(string),
       typeof(MainpageLayout)
       );
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public MainpageLayout()
        {
            InitializeComponent();
        }
    }
}
