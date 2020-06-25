using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ChiefsViews
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void AppStartup (object sender, System.EventArgs e)
        {
            Properties["AppName"] = "ChiefsViews";
        }
    }
}
