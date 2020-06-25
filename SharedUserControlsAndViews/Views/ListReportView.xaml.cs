using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WFDMemberStatus.UserControlsAndViews
{
    /// <summary>
    /// Interaction logic for RefresherView.xaml
    /// </summary>
    public partial class ListReportView : Window
    {
        private readonly string request;
        public ListReportView()
        {
            InitializeComponent();           
        }
        public ListReportView(string inRequest)
        {
            request = inRequest;
            InitializeComponent();
            switch (request)
            {                
                case "RequestRefresher":
                    MembersNeedingRefresher refresher = new MembersNeedingRefresher();
                    MainGrid.Children.Add(refresher);
                    Grid.SetRow(refresher, 0);
                    break;
                case "RequestHazMat":
                    MembersNeedingHMatRefresher membersNeedingHMatRefresher = new MembersNeedingHMatRefresher();
                    MainGrid.Children.Add(membersNeedingHMatRefresher);
                    Grid.SetRow(membersNeedingHMatRefresher, 0);
                    break;
                default:
                    break;
            }           
        }
        public void PrintListClicked(object sender, RoutedEventArgs e)
        {
            ReportPrint reportPrint = new ReportPrint(request)
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top
            };

            List<UserControl> userControls = new List<UserControl>() { reportPrint };

            PrintViewer printViewer = new PrintViewer(userControls, "LetterPortrait");
            printViewer.Show();
        }
    }
}
