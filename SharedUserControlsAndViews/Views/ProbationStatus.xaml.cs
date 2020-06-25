using System.ComponentModel;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WFDMemberStatus.Models;
using WFDMemberStatus.ViewModels;

namespace WFDMemberStatus.UserControlsAndViews
{
	/// <summary>
	/// Interaction logic for ProbationStatus.xaml
	/// </summary>
	public partial class ProbationStatus : Window
	{
		public string appName;
		public ProbationCollection probationCollection;
		public GridViewColumnHeader lastHeaderClicked = null;
		public ListSortDirection lastDirection = ListSortDirection.Ascending;
		public Member currentMember;
		public readonly List<Member> sortedList;
		public readonly CollectionViewSource collectionViewSource;
		public string filterConditionCompany;

		public ProbationStatus()
		{
			appName = Application.Current.Properties["AppName"].ToString();
			probationCollection = new ProbationCollection();
			
			InitializeComponent();

			if (appName == "CompanyViews")
			{
				FilterPanel.Visibility = Visibility.Hidden;
				FilterPanel.Visibility = Visibility.Collapsed;
			}

			collectionViewSource = new CollectionViewSource()
			{
				Source = probationCollection.members
			};
			collectionViewSource.Filter += FilterMemberView;
			memberListView.ItemsSource = collectionViewSource.View;
			DataContext = collectionViewSource.View;
		}
		void ChangedMember(object sender, SelectionChangedEventArgs args)
		{
			currentMember = ((sender as DataGrid).SelectedItem as Member);
		}
		void PrintMemberClicked(object sender, RoutedEventArgs e)
		{
			IndividualProbationStatus individualProbationStatus = new IndividualProbationStatus(currentMember);
			List<UserControl> userControls = new List<UserControl>() { individualProbationStatus };
			PrintViewer printViewer = new PrintViewer(userControls, "LetterPortrait");
			printViewer.Show();
		}
		void PrintAllMembersClicked(object sender, RoutedEventArgs e)
		{
			List<UserControl> userControls = new List<UserControl>();
			foreach (Member item in collectionViewSource.View)
			{
				IndividualProbationStatus individualProbationStatus = new IndividualProbationStatus(item) { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Top };
				userControls.Add(individualProbationStatus);
			}

			PrintViewer printViewer = new PrintViewer(userControls, "LetterPortrait");
			printViewer.Show();
		}
		private void FilterMemberView(object sender, FilterEventArgs e)
		{
			Member member = e.Item as Member;

			if (filterConditionCompany == "All" || filterConditionCompany == member.Company)
			{
				e.Accepted = true;
			}
			else
			{
				e.Accepted = false;
			}
		}
		private void CompanyFilterChecked(object sender, RoutedEventArgs e)
		{
			RadioButton rb = sender as RadioButton;
			filterConditionCompany = rb.Tag.ToString();
			if (collectionViewSource != null)
			{
				collectionViewSource.View.Refresh();
			}
		}
	}
}
