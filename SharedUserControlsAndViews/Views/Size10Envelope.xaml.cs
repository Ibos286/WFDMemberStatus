using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using WFDMemberStatus.Models;

namespace WFDMemberStatus.UserControlsAndViews
{
    /// <summary>
    /// Interaction logic for Size10Envelope.xaml
    /// </summary>
    public partial class Size10Envelope : UserControl
    {
        public Size10Envelope()
        {
            InitializeComponent();
        }
        public Size10Envelope(Member member)
        {
            InitializeComponent();
            DataContext = member;
        }
        private void ControlLoaded(object sender, RoutedEventArgs e)
        {
#if HOOKANDLADDER
            AddressLine1.Text = "Hook & Ladder Company #1";
#elif HOSE1
            AddressLine1.Text = "Hose Company # 1";
#else
            AddressLine1.Text = "";
#endif
        }
    }
}
