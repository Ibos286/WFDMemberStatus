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
    /// Interaction logic for MaterialDesignMainWindow.xaml
    /// </summary>
    public partial class MaterialDesignMainWindow : Window
    {
        public MaterialDesignMainWindow()
        {
            InitializeComponent();
            NotificationUserControl notificationUserControl = new NotificationUserControl();
            StatusUserControl memberUserControl = new StatusUserControl("Member");
            StatusUserControl probationUserControl = new StatusUserControl("Probation");
            MembersNeedingUserControl membersNeedingUserControl = new MembersNeedingUserControl();
            PrintEnvelopesUserControl printEnvelopesUserControl = new PrintEnvelopesUserControl();

            NotificationUserControl.Content = notificationUserControl;
            MemberStatusControl.Content = memberUserControl;
            ProbationMemberStatusControl.Content = probationUserControl;
            MembersNeeding.Content = membersNeedingUserControl;
            printEnvelopes.Content = printEnvelopesUserControl;
        }
    }
}
