using RandomFactory.Models;
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
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = PropertiesManager.ReadRandomGeneratorVM();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            PropertiesManager.SaveRandomGeneratorVM(this.DataContext as RandomGeneratorVM);
        }
    }
}
