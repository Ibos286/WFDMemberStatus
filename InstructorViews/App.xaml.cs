using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WFDMemberStatus.UserControlsAndViews;

namespace InstructorViews
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Properties["AppName"] = "InstructorViews";
            StatusWindow statusWindow = new StatusWindow("Probation");
            statusWindow.Show();
        }
        public void AppStartup(object sender, System.EventArgs e)
        {
            
        }
    }
}
