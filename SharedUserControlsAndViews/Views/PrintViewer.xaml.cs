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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WFDMemberStatus.UserControlsAndViews
{
    /// <summary>
    /// Interaction logic for PrintViewer.xaml
    /// </summary>
    public partial class PrintViewer : Window
    {
        public string documentPaperSize;
        public List<UserControl> userControls;
        public ReportPrint reportPrint;
        public PrintViewer()
        {
            InitializeComponent();

            reportPrint = new ReportPrint()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top
            };
        }
        public PrintViewer (List<UserControl> userControlsFromSender, string paperSize)
        {
            documentPaperSize = paperSize;
            userControls = userControlsFromSender;
            InitializeComponent();
        }
        private void FixedDocumentIsLoaded(object sender, RoutedEventArgs e)
        {
            FixedDocument fixedDocument = sender as FixedDocument;

            foreach (UserControl userControl in userControls)
            {
                PageContent pageContent = new PageContent();
                FixedPage fixedPage = new FixedPage();
                Grid grid = new Grid() { Margin = new Thickness(0, 30, 0, 10) };
                Binding bindingWidth = new Binding("ActualWidth") { Source = fixedPage };
                Binding bindingHeight = new Binding("ActualHeight") { Source = fixedPage };
                switch (documentPaperSize)
                {
                    case "LetterPortrait":
                        fixedPage.Height = 1056;
                        fixedPage.Width = 816;
                        break;
                    case "LetterLandscape":
                        fixedPage.Height = 816;
                        fixedPage.Width = 1056;
                        break;
                    case "Envelope":
                        fixedPage.Height = 900;
                        fixedPage.Width = 300;
                        RotateTransform rotateTransform = new RotateTransform(90);
                        userControl.LayoutTransform = rotateTransform;
                        break;
                    default:
                        break;
                }
                
                grid.Children.Add(userControl);
                fixedPage.Children.Add(grid);
                grid.SetBinding(Grid.WidthProperty, bindingWidth);
                grid.SetBinding(Grid.HeightProperty, bindingHeight);
                (pageContent as IAddChild).AddChild(fixedPage);
                fixedDocument.Pages.Add(pageContent);
            }
        }
    }
}
