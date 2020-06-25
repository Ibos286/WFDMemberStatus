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

namespace WFDMemberStatus.UserControlsAndViews
{
    /// <summary>
    /// Interaction logic for MembersNeedingHMatRefresher.xaml
    /// </summary>
    public partial class MembersNeedingHMatRefresher : UserControl
    {
        public CollectionViewSource cvs;
        public MembersNeedingHMatRefresher()
        {
            HazMatRefresherList hazMatRefresherList = new HazMatRefresherList();
            cvs = new CollectionViewSource()
            {
                Source = hazMatRefresherList.members
            };
            InitializeComponent();
            hazMatDataGrid.ItemsSource = cvs.View;
        }
    }
}
