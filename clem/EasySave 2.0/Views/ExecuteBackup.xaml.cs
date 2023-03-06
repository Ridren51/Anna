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
    /// Logique d'interaction pour ExecuteBackup.xaml
    /// </summary>
    public partial class ExecuteBackup : UserControl
    {
        public ExecuteBackup()
        {
            InitializeComponent();
            updateGrid();
        }
        void updateGrid()
        {
            jobs.loadJobsFromXml();

            List<CreateBackupViewModel> truc = new List<CreateBackupViewModel>();


            for (int i = 0; i < jobs.listJobs.Count; i++)
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

        void btnExecuteJob(object sender, RoutedEventArgs e)
        {
            bool correct = false;
            foreach (job job in jobs.listJobs)
            {
                if (job.name == jobNameExecute.Text)
                {
                    correct = true;
                    jobs.executeJob(job);
                }
            }
            if (!correct) 
            {
                MessageBox.Show("name not found");
                return;
            }

            ClearFields();
        }

        void btnDeleteJob(object sender, RoutedEventArgs e)
        {
            bool correct = false;
            for (int i = 0; i<jobs.listJobs.Count; i++)
            {
                if (jobs.listJobs[i].name == jobNameDelete.Text)
                {
                    jobs.deleteJob(i);
                    correct = true;
                    break;
                }
            }
            if (!correct)
            {
                MessageBox.Show("name not found");
                return;
            }


            ClearFields();
            updateGrid();
        }

        public void ClearFields()
        {
            jobNameExecute.Text = "";
            jobNameDelete.Text = "";
        }
    }
}
