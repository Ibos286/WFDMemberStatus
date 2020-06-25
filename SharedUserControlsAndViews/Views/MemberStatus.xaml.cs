using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WFDMemberStatus.ViewModels;
using WFDMemberStatus.Models;


namespace WFDMemberStatus.UserControlsAndViews
{
	/// <summary>
	/// Interaction logic for MemberStatus.xaml
	/// </summary>
	public partial class MemberStatus : Window
	{
		string appName;
		string filterConditionLOS;
		string filterConditionCompany;
		Member member;
		public MemberCollection memberCollection;
		public GridViewColumnHeader lastHeaderClicked = null;
		public ListSortDirection lastDirection = ListSortDirection.Ascending;
		public CollectionViewSource cvs;
		public MemberStatus()
		{
			appName = Application.Current.Properties["AppName"].ToString();
			memberCollection = new MemberCollection();

			InitializeComponent();

			if (appName == "CompanyViews")
			{
				FilterPanel.Visibility = Visibility.Hidden;
				FilterPanel.Visibility = Visibility.Collapsed;
				CompanyGridColumn.Visibility = Visibility.Hidden;
				CompanyGridColumn.Visibility = Visibility.Collapsed;
			}

			cvs = new CollectionViewSource
			{
				Source = memberCollection.members
			};		

			cvs.Filter += FilterMemberView;
			memberListView.ItemsSource = cvs.View;
			DataContext = cvs.View ;
		}

		void ChangedMember(object sender, SelectionChangedEventArgs args)
		{
			member = ((sender as DataGrid).SelectedItem as Member);		
		}

		void MemberViewHeaderClickHandler(object seder, RoutedEventArgs e)
		{
			ListSortDirection listSortDirection;

			if (e.OriginalSource is GridViewColumnHeader headerClicked)
			{
				if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
				{
					if (headerClicked != lastHeaderClicked)
					{
						listSortDirection = ListSortDirection.Ascending;
						if (lastHeaderClicked != null)
						{
							lastHeaderClicked.Column.Width = lastHeaderClicked.Column.ActualWidth - 20;

						}
						headerClicked.Column.Width = headerClicked.ActualWidth + 20;
					}
					else
					{
						if (lastDirection == ListSortDirection.Ascending)
						{
							listSortDirection = ListSortDirection.Descending;
						}
						else
						{
							listSortDirection = ListSortDirection.Ascending;
						}
					}
					var columnBinding = headerClicked.Column.DisplayMemberBinding as Binding;
					var sortBy = columnBinding?.Path.Path ?? headerClicked.Column.Header as string;

					Sort(sortBy, listSortDirection);

					if (listSortDirection == ListSortDirection.Ascending)
					{
						headerClicked.Column.HeaderTemplate = Resources["HeaderTemplateArrowUp"] as DataTemplate;
					}
					else
					{
						headerClicked.Column.HeaderTemplate = Resources["HeaderTemplateArrowDown"] as DataTemplate;
					}
					//Remove previous sort header arrow.
					if (lastHeaderClicked != null && lastHeaderClicked != headerClicked)
					{
						lastHeaderClicked.Column.HeaderTemplate = null;
					}
					lastHeaderClicked = headerClicked;
					lastDirection = listSortDirection;
				}
			}
		}
		private void Sort(string sortBy, ListSortDirection listSortDirection)
		{
			ICollectionView dataView = CollectionViewSource.GetDefaultView(memberListView.ItemsSource);
			dataView.SortDescriptions.Clear();
			SortDescription sortDescription = new SortDescription(sortBy, listSortDirection);
			dataView.SortDescriptions.Add(sortDescription);
			dataView.Refresh();
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
		private void LOSFilterChecked (object sender, RoutedEventArgs e)
		{
			RadioButton rb = sender as RadioButton;
			filterConditionLOS = rb.Tag.ToString();
			if (cvs != null)
			{
				cvs.View.Refresh();
			}
		}
		private void CompanyFilterChecked(object sender, RoutedEventArgs e)
		{
			RadioButton rb = sender as RadioButton;
			filterConditionCompany = rb.Tag.ToString();
			if (cvs != null)
			{
				cvs.View.Refresh();
			}
		}
		private void PrintMemberStatus(object sender, RoutedEventArgs e)
		{
			IndividualMember individualMember = new IndividualMember(member)
			{
				HorizontalAlignment = HorizontalAlignment.Center,
				VerticalAlignment = VerticalAlignment.Top
			};
			//Grid grid = new Grid { Margin = new Thickness(0, 30, 0, 10) };
			//grid.Children.Add(individualMember);

			//PrintViewer printViewer = new PrintViewer(grid);

			List<UserControl> userControls = new List<UserControl>() { individualMember };
			PrintViewer printViewer = new PrintViewer(userControls, "LetterPortrain");
			printViewer.Show();
		}
		private void PrintMultiple(object sender, RoutedEventArgs e)
		{
			List<UserControl> userControls = new List<UserControl>();
			foreach (Member member in cvs.View)
			{
				IndividualMember individualMember = new IndividualMember(member) { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Top };
				userControls.Add(individualMember);
			}
			PrintViewer printViewer = new PrintViewer(userControls, "LetterPortrait");
			printViewer.Show();
		}
	}
}
