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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Switchboard : Window
    {
        public string AppName;
        public Switchboard()
        {
            AppName = Application.Current.Properties["AppName"].ToString();
            InitializeComponent();
            switch (AppName)
            {
                case "ChiefsViews":
                    break;
                case "CompanyViews":
                    break;
                default:
                    break;
            }
        }

        void ShowMemberStatusClicked(object sender, RoutedEventArgs e)
        {
            StatusWindow statusWindow = new StatusWindow("Member");
            statusWindow.Show();
        }

        void MembersNeedRefresher(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            //ListReportView refresherView = new ListReportView(button.Tag.ToString());
            //refresherView.Show();
            ViewMembersNeeding viewMembersNeeding = new ViewMembersNeeding(button.Tag.ToString());
            viewMembersNeeding.Show();
        }
        void MembersNeedHazMat(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            ViewMembersNeeding viewMembersNeeding = new ViewMembersNeeding(button.Tag.ToString());
            viewMembersNeeding.Show();
        }
        private void ShowProbationMembers (object sender, RoutedEventArgs e)
        {
            StatusWindow statusWindow = new StatusWindow("Probation");
            statusWindow.Show();
        }
        private void PrintMailingEnvelopes (object sender, RoutedEventArgs e)
        {
            PrintEnvelopes printEnvelopes = new PrintEnvelopes();
            printEnvelopes.Show();
        }
    }
}
