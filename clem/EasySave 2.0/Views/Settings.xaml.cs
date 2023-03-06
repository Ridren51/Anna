using EasySave_2._0.Models;
using EasySave_2._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasySave_2._0.Views
{
    /// <summary>
    /// Logique d'interaction pour Setting.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
			myTextBlock.Text = ViewModels.SettingsViewModel.logFormat;
		}

		private void AllFeatures_CheckedChanged(object sender, RoutedEventArgs e)
		{
			bool newVal = (AllFeatures.IsChecked == true);
			Featuretxt.IsChecked = newVal;
			Featurepdf.IsChecked = newVal;
			//Featuredocx.IsChecked = newVal;
		}

		private void Feature_CheckedChanged(object sender, RoutedEventArgs e)
		{
			var Settings = new SettingsViewModel();

			AllFeatures.IsChecked = null;
			if ((Featuretxt.IsChecked == true) && (Featurepdf.IsChecked == true))// && (Featuredocx.IsChecked == true))
				AllFeatures.IsChecked = true;
			if ((Featuretxt.IsChecked == false) && (Featurepdf.IsChecked == false))// && (Featuredocx.IsChecked == false))
				AllFeatures.IsChecked = false;
			if ((Featuretxt.IsChecked == true))
            {
				SettingsViewModel.FileTypes.Add(".txt");
			}
			if ((Featurepdf.IsChecked == true))
			{
				SettingsViewModel.FileTypes.Add(".pdf");
			}
			//if ((Featuredocx.IsChecked == true))
			//{
			//	SettingsViewModel.FileTypes.Add(".docx");
			//}

			if ((Featuretxt.IsChecked == false))
			{
                try
                {
					SettingsViewModel.FileTypes.Remove(".txt");
                }
                catch { }
			}
			if ((Featurepdf.IsChecked == false))
			{
				try
				{
					SettingsViewModel.FileTypes.Remove(".pdf");
				}
				catch { }
			}
			//if ((Featuredocx.IsChecked == false))
			//{
			//	try
			//	{
			//		SettingsViewModel.FileTypes.Remove(".docx");
			//	}
			//	catch { }
			//}
		}

		public void cmb_changed(object sender, RoutedEventArgs e)
        {
			if (cmb.SelectedIndex == 0)
            {
				model.language = "en";
				model.dictionary.Source = new Uri("../../Langs/en.xaml", UriKind.Relative);
				Application.Current.Resources.MergedDictionaries.Add(model.dictionary);
            }
            else
            {
				model.language = "fr";
				model.dictionary.Source = new Uri("../../Langs/fr.xaml", UriKind.Relative);
				Application.Current.Resources.MergedDictionaries.Add(model.dictionary);
			}
        }

	}
}
