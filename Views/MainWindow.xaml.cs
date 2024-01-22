using RandomFactory.Models;
using RandomFactory.Models.DataAccess;
using RandomFactory.ViewModels;
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

namespace RandomFactory
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ValueDbContext valueDb;
        public MainWindow()
        {
            InitializeComponent();
            valueDb = new ValueDbContext();
            DataContext = new MainVM(valueDb);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            valueDb.Dispose();
        }
    }
}
