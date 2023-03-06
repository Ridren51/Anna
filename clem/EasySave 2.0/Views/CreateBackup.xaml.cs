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
using EasySave_2._0.ViewModels;
using EasySave_2._0.Models;

namespace EasySave_2._0.Views
{
    /// <summary>
    /// Logique d'interaction pour CreateBackup.xaml
    /// </summary>
    public partial class CreateBackup : UserControl
    {
        public CreateBackup()
        {
            InitializeComponent();
            updateGrid();
        }

        void btnCreateJob(object sender, RoutedEventArgs e)
        {

            CreateBackupViewModel CBVM = new CreateBackupViewModel()
            {
                JobName = textBoxJobName.Text,
                PathSource = textBoxJobSource.Text,
                PathTarget = textBoxJobTarget.Text,
                Type = textBoxJobType.Text
            };

            jobs.createJob(CBVM);

            updateGrid();
            

            ClearFields();
        }

        public void ClearFields()
        {
            textBoxJobName.Text = "";
            textBoxJobSource.Text = "";
            textBoxJobTarget.Text = "";
            textBoxJobType.Text = "";
        }

        void updateGrid()
        {
            jobs.loadJobsFromXml();

            List<CreateBackupViewModel> truc = new List<CreateBackupViewModel>();

            
            for (int i = 0; i<jobs.listJobs.Count; i++)
            {
                truc.Add(new CreateBackupViewModel()
                {
                    JobName = jobs.listJobs[i].name,
                    PathSource = jobs.listJobs[i].pathSource,
                    PathTarget = jobs.listJobs[i].pathTarget,
                    Type = jobs.listJobs[i].type
                });

            }
          
            dgLstFile.ItemsSource = truc;
        }
    }
}
