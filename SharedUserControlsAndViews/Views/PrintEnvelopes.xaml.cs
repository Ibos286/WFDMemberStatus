using UserControlsAndViews;
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
    /// Interaction logic for PrintEnvelopes.xaml
    /// </summary>
    public partial class PrintEnvelopes : Window
    {
        public MemberCollection memberCollection;
        public CollectionViewSource collectionViewSource;
        public PrintEnvelopes()
        {
            memberCollection = new MemberCollection();
            InitializeComponent();
            collectionViewSource = new CollectionViewSource() { Source = memberCollection.members };
            memberEnvelopeGrid.ItemsSource = collectionViewSource.View;
            DataContext = collectionViewSource.View;
        }
        private void PrintSelectedClicked (object sender, RoutedEventArgs e)
        {
            List<UserControl> size10Envelopes;
            if (memberEnvelopeGrid.SelectedItems.Count > 0)
            {
                size10Envelopes = new List<UserControl>();
            }
            else
            {
                return;
            }
            foreach (Member member in memberEnvelopeGrid.SelectedItems)
            {
                size10Envelopes.Add(new Size10Envelope(member));
            }
            PrintViewer printViewer = new PrintViewer(size10Envelopes, "Envelope");
            printViewer.Show();
        }
    }
}
