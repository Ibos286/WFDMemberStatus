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

namespace WFDMemberStatus.UserControlsAndViews
{
    /// <summary>
    /// Interaction logic for RefresherReportTitleBlock.xaml
    /// </summary>
    public partial class ReportPrint : UserControl
    {
        public ReportPrint()
        {
            InitializeComponent();
        }
        public ReportPrint(string request)
        {
            InitializeComponent();
            switch (request)
            {
                case "RequestRefresher":
                    MembersNeedingRefresher refresher = new MembersNeedingRefresher();
                    MainGrid.Children.Add(refresher);
                    Grid.SetRow(refresher, 1);
                    break;
                case "RequestHazMat":
                    MembersNeedingHMatRefresher membersNeedingHMatRefresher = new MembersNeedingHMatRefresher();
                    MainGrid.Children.Add(membersNeedingHMatRefresher);
                    Grid.SetRow(membersNeedingHMatRefresher, 1);
                    break;
                default:
                    break;
            }
        }
    }
}
