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
using WFDMemberStatus.Models;
using WFDMemberStatus.ViewModels;

namespace WFDMemberStatus.UserControlsAndViews
{
    /// <summary>
    /// Interaction logic for StatusWindow.xaml
    /// </summary>
    public partial class StatusWindow : Window
    {
        private readonly string appName;

        public StatusWindow()
        {
            InitializeComponent();
        }
        public StatusWindow(string caller)
        {
            InitializeComponent();
            appName = Application.Current.Properties["AppName"].ToString();
            StatusUserControl statusUserControl = new StatusUserControl(caller);
            DisplayStatusUserControl.Content = statusUserControl;
        }
    }
}
