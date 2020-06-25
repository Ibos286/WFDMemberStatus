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
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using WFDMemberStatus.Models;
using WFDMemberStatus.ViewModels;

namespace WFDMemberStatus.UserControlsAndViews
{
    public partial class StatusUserControl : UserControl
    {
        private readonly string appName;
        private readonly string displayType;
        private string filterConditionLOS;
        private string filterConditionCompany;
        private Member member;
        private readonly MemberCollection memberCollection;
        private readonly ProbationCollection probationCollection;
        private readonly CollectionViewSource collectionViewSource;
        public StatusUserControl()
        {
            InitializeComponent();
        }
        public StatusUserControl(string caller)
        {
            InitializeComponent();

            displayType = caller;
            appName = Application.Current.Properties["AppName"].ToString();

            if (appName == "CompanyViews")
            {
                CompanyLOSLabel.Text = "Length of Service Filter";
                CompanyFilterPanel.Visibility = Visibility.Hidden;
                CompanyFilterPanel.Visibility = Visibility.Collapsed;
                CompanyGridColumn.Visibility = Visibility.Hidden;
                CompanyGridColumn.Visibility = Visibility.Collapsed;
            }

            collectionViewSource = new CollectionViewSource();
            collectionViewSource.Filter += FilterMemberView;
            switch (caller)
            {
                case "Member":
                    TitleBlock2.Text = "Member Status";
                    memberCollection = new MemberCollection();
                    collectionViewSource.Source = memberCollection.members;
                    IndividualMember individualMember = new IndividualMember();
                    individualMember.ContainerTitle1.Visibility = Visibility.Hidden;
                    individualMember.ContainerTitle1.Visibility = Visibility.Collapsed;
                    individualMember.ContainerTitle2.Visibility = Visibility.Hidden;
                    individualMember.ContainerTitle2.Visibility = Visibility.Collapsed;
                    IndividualContainer.Content = individualMember;
                    CompanyLOSLabel.Text = "Company & Length of Service Filters";
                    break;
                case "Probation":
                    TitleBlock2.Text = "Probationary Member Status";
                    probationCollection = new ProbationCollection();
                    collectionViewSource.Source = probationCollection.members;
                    IndividualProbationStatus individualProbationStatus = new IndividualProbationStatus();
                    individualProbationStatus.ContainerTitle1.Visibility = Visibility.Hidden;
                    individualProbationStatus.ContainerTitle1.Visibility = Visibility.Collapsed;
                    individualProbationStatus.ContainerTitle2.Visibility = Visibility.Hidden;
                    individualProbationStatus.ContainerTitle2.Visibility = Visibility.Collapsed;
                    IndividualContainer.Content = individualProbationStatus;
                    CompanyLOSLabel.Text = "Company Filter";
                    LoSFilterPanel.Visibility = Visibility.Hidden;
                    LoSFilterPanel.Visibility = Visibility.Collapsed;
                    break;
                default:
                    break;
            }

            if (collectionViewSource.Source != null)
            {
                memberListView.ItemsSource = collectionViewSource.View;
                DataContext = collectionViewSource.View;
            }
        }
        private void ChangedMember(object sender, SelectionChangedEventArgs e)
        {
            member = (sender as DataGrid).SelectedItem as Member;
            IndividualContainer.DataContext = member;
        }
        private void FilterMemberView(object sender, FilterEventArgs e)
        {
            Member member = e.Item as Member;

            if (filterConditionCompany == "All" || filterConditionCompany == member.Company)
            {
                switch (filterConditionLOS)
                {
                    case "All":
                        e.Accepted = true;
                        break;
                    case "LE5":
                        e.Accepted = member.YearsOfService < 5;
                        break;
                    case "LE10":
                        e.Accepted = member.YearsOfService < 10;
                        break;
                    case "LT20":
                        e.Accepted = member.YearsOfService < 20;
                        break;
                    default:
                        e.Accepted = false;
                        break;
                }
            }
            else
            {
                e.Accepted = false;
            }
        }
        private void LOSFilterChecked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Tag == null)
            {
                rb.Tag = "All";
            }
            filterConditionLOS = rb.Tag.ToString();
            if (collectionViewSource != null)
            {
                collectionViewSource.View.Refresh();
            }
        }
        private void CompanyFilterChecked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb.Tag == null)
            {
                rb.Tag = "All";
            }
            filterConditionCompany = rb.Tag.ToString();

            if (collectionViewSource != null)
            {
                collectionViewSource.View.Refresh();
            }
        }
        private void PrintSelectedMemberClicked(object sender, RoutedEventArgs e)
        {
            List<UserControl> userControls = new List<UserControl>();
            if (displayType == "Member")
            {
                foreach (Member member in memberListView.SelectedItems)
                {
                    userControls.Add(new IndividualMember(member));
                }
            }
            else
            {
                foreach (Member member in memberListView.SelectedItems)
                {
                    userControls.Add(new IndividualProbationStatus(member));
                }
            }
            PrintViewer printViewer = new PrintViewer(userControls, "LetterPortrait");
            printViewer.Show();
        }
        private void PrintMembersInView(object sender, RoutedEventArgs e)
        {
            List<UserControl> userControls = new List<UserControl>();
            if (displayType == "Member")
            {
                foreach (Member member in collectionViewSource.View)
                {
                    userControls.Add(new IndividualMember(member));
                }
            }
            else
            {
                foreach (Member member in collectionViewSource.View)
                {
                    userControls.Add(new IndividualProbationStatus(member));
                }
            }
            PrintViewer printViewer = new PrintViewer(userControls, "LetterPortrait");
            printViewer.Show();
        }
        private void StatusUserControlLoaded(object sender, RoutedEventArgs e)
        {
            //if (allCompanyRBChecked.IsChecked == false && hooksCompanyRBChecked.IsChecked == false && hose1RBChecked.IsChecked == false && hose2RBChecked.IsChecked == false)
            //{
            //    allCompanyRBChecked.IsChecked = true;                
            //}
            //if (allLOSRBChecked.IsChecked == false && le5RBChecked.IsChecked == false && le10RBChecked.IsChecked == false && lt20RBChecked.IsChecked == false)
            //{
            //    allLOSRBChecked.IsChecked = true;
            //}
        }
    }
}
