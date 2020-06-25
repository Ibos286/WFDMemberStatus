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
using WFDMemberStatus.ViewModels;

namespace WFDMemberStatus.UserControlsAndViews
{
    /// <summary>
    /// Interaction logic for MembersNeedingRefresher.xaml
    /// </summary>
    public partial class MembersNeedingRefresher : UserControl
    {
        readonly CollectionViewSource collectionViewSource;
        public MembersNeedingRefresher()
        {
            RefresherList refresherList = new RefresherList();
            collectionViewSource = new CollectionViewSource()
            {
                Source = refresherList.refresherListCollection
            };
            InitializeComponent();
            refresherDataGrid.ItemsSource = collectionViewSource.View;
        }
    }
}
