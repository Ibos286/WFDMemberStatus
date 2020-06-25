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
using WFDMemberStatus.UserControlsAndViews;
using WFDMemberStatus.ViewModels;

namespace WFDMemberStatus.UserControlsAndViews
{
    /// <summary>
    /// Interaction logic for MainTabbedPage.xaml
    /// </summary>
    public partial class MainTabbedPage : Window
    {
        public MainTabbedPage()
        {
            InitializeComponent();
            ProbationStatusTab.Content = new StatusUserControl("Probation");
            MemberStatusTab.Content = new StatusUserControl("Member");
            MembersNeedingRefresher.Content = new ViewMembersNeedingControl("RequestRefresher");
            MembersNeedingHazMatRefresher.Content = new ViewMembersNeedingControl("RequestHazMat");
            MembersNeedingMaskConfidence.Content = new ViewMembersNeedingControl("RequestMaskConfidence");
            MembersNeedingFitTest.Content = new ViewMembersNeedingControl("RequestFitTest");
            MembersNeedingPSS.Content = new ViewMembersNeedingControl("RequestPSS"); 
        }
    }
}
