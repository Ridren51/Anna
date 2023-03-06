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
using EasySave_2._0.Models;
using EasySave_2._0.ViewModels;

namespace EasySave_2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            model.language = "en";
            model.dictionary.Source = new Uri("../../Langs/en.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(model.dictionary);
        }

        private void Btn_Click_EB(object sender, RoutedEventArgs e)
        {
            DataContext = new ExecuteBackupViewModel();
        }

        private void Btn_Click_CB(object sender, RoutedEventArgs e)
        {
            DataContext = new CreateBackupViewModel();
        }

        private void Btn_Click_Settings(object sender, RoutedEventArgs e)
        {
            DataContext = new SettingsViewModel();
        }
    }
}
