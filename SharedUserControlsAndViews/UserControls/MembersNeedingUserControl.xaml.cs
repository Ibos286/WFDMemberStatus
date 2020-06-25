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
    /// Interaction logic for MembersNeedingUserControl.xaml
    /// </summary>
    public partial class MembersNeedingUserControl : UserControl
    {
        public MembersNeedingUserControl()
        {
            InitializeComponent();
            DepartmentRefresher.Content = new ViewMembersNeedingControl("RequestRefresher");
            HazMatRefresher.Content = new ViewMembersNeedingControl("RequestHazMat");
            MaskConfidence.Content = new ViewMembersNeedingControl("RequestMaskConfidence");
            FitTest.Content = new ViewMembersNeedingControl("RequestFitTest");
            PSS.Content = new ViewMembersNeedingControl("RequestPSS");
        }
    }
}
