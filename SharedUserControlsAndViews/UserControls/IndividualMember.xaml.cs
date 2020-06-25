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
using WFDMemberStatus.Models;

namespace WFDMemberStatus.UserControlsAndViews
{
    /// <summary>
    /// Interaction logic for IndividualMember.xaml
    /// </summary>
    public partial class IndividualMember : UserControl
    {
        public IndividualMember()
        {
            InitializeComponent();
        }
        public IndividualMember(Member member)
        {
            InitializeComponent();
            this.DataContext = member;
        }
    }
}
