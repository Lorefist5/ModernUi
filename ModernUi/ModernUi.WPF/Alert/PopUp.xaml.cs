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

namespace ModernUi.WPF.Alert
{
    /// <summary>
    /// Interaction logic for PopUp.xaml
    /// </summary>
    public partial class PopUp : Window
    {
        public string Message { get; set; }

        public PopUp(string title, string message)
        {

            InitializeComponent();
            DataContext = this;
            this.Title = title;
            Message = message;

            // Disable the parent window
            Owner = Application.Current.MainWindow;
            Owner.IsEnabled = false;
        }

        private void OkayButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Owner.IsEnabled = true;
        }
    }
}

