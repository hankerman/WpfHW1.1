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
using WpfHW1.ViewModel;

namespace WpfHW1
{
    /// <summary>
    /// Логика взаимодействия для AutorizationWindow.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {
        private AutorizationVM vm;
        public AutorizationWindow()
        {
            InitializeComponent();
            vm  = new AutorizationVM();
            this.DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (vm.Auth(pwdBox.Password))
            {
                (new UserWindow()).Show();
                this.Owner.Close();                
            }

        }
    }
}
