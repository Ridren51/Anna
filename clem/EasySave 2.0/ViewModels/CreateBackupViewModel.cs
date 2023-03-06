using EasySave_2._0.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EasySave_2._0.ViewModels
{
    public class CreateBackupViewModel
    {

        private string _jobName = string.Empty;
        public string JobName
        {
            get
            {
                return _jobName;
            }
            set
            {
                _jobName = value;
            }
        }

        private string _pathSource = string.Empty;
        public string PathSource
        {
            get
            {
                return _pathSource;
            }
            set
            {
                _pathSource = value;
            }
        }

        private string _pathTarget = string.Empty;
        public string PathTarget
        {
            get
            {
                return _pathTarget;
            }
            set
            {
                _pathTarget = value;
            }
        }

        private string _type = string.Empty;
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

    }
}
