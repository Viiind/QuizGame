using CommunityToolkit.Mvvm;
using QuizApp.Messages;
using QuizApp.ViewModels;
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

namespace QuizApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = new MainViewModel();
            InitializeComponent();
        }

        private void BTNnext_MouseEnter(object sender, MouseEventArgs e)
        {
            BTNnext.Background = Brushes.OrangeRed;
        }

        private void BTNnext_MouseLeave(object sender, MouseEventArgs e)
        {
            BTNnext.Background = Brushes.Orange;
        }
    }
}
