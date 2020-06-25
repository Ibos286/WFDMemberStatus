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
using WFDMemberStatus.ViewModels;
using WFDMemberStatus.Models;
using MaterialDesignColors;
using MaterialDesignThemes;
using System.Collections.ObjectModel;

namespace WFDMemberStatus.UserControlsAndViews
{
    /// <summary>
    /// Interaction logic for NotificationUserControl.xaml
    /// </summary>
    public partial class NotificationUserControl : UserControl
    {
        public readonly MemberCollection memberCollection;
        public readonly List<Member> members;
        public List<Member> anniversaries;
        public NotificationUserControl()
        {
            InitializeComponent();

            memberCollection = new MemberCollection();
            members = new List<Member>();

            anniversaries = memberCollection.members.ToList<Member>().FindAll( delegate (Member member)
            {
                return member.ServiceDate.Month == DateTime.Now.Month;
            });
            anniversaries = anniversaries.OrderBy(x => x.ServiceDate).ToList();
            AnniversariesListBox.ItemsSource = anniversaries;
        }
    }
}
