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
using WFDMemberStatus.Models;
using WFDMemberStatus.ViewModels;

namespace WFDMemberStatus.UserControlsAndViews
{
    /// <summary>
    /// Interaction logic for ViewMembersNeeding.xaml
    /// </summary>
    public partial class ViewMembersNeeding : Window
    {
        private readonly string reportTitle;
        readonly CollectionViewSource collectionViewSource;
        public ViewMembersNeeding()
        {
            InitializeComponent();
        }
        public ViewMembersNeeding(string request)
        {
            collectionViewSource = new CollectionViewSource();
            switch (request)
            {
                case "RequestRefresher":
                    this.Title = "Members Needing Refresher This Year";
                    reportTitle = "Members Needing Refresher This Year";
                    RefresherList refresherList = new RefresherList();
                    collectionViewSource.Source = refresherList.refresherListCollection;
                    break;
                case "RequestHazMat":
                    this.Title = "Members Needing HazMat Refresher";
                    reportTitle = "Members Needing HazMat Refresher";
                    HazMatRefresherList hazMatRefresherList = new HazMatRefresherList();
                    collectionViewSource.Source = hazMatRefresherList.members;
                    break;
                default:
                    break;
            }
            InitializeComponent();
            dataGrid.IsReadOnly = true;
            dataGrid.ItemsSource = collectionViewSource.View;
        }
        private void PrintList(object sender, RoutedEventArgs e)
        {
            FlowDocument flowDocument = new FlowDocument();
            bool pageBreakBeforeSection = false;
            int index = 0;
            Table table = null;
            TableRow currentRow;

            foreach (Member member in collectionViewSource.View)
            {
                if (index % 40 == 0)
                {
                    table = CreateNewReportTable(pageBreakBeforeSection);
                    flowDocument.Blocks.Add(table);
                    index = table.RowGroups[2].Rows.Count();
                }
                pageBreakBeforeSection = true;
                table.RowGroups[2].Rows.Add(new TableRow());
                currentRow = table.RowGroups[2].Rows[index];
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(member.Company))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(member.FirstName))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(member.LastName))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(member.PhoneNumber))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(member.CellPhone))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(member.EmailAddress))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(member.DepartmentClass))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(member.YearsOfService.ToString()))));
                index++;
            }

            //FlowDocumentView flowDocumentView = new FlowDocumentView();
            //flowDocumentView.flowDocumentReader.Document = flowDocument;
            //flowDocumentView.Show();

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() != true) return;
            flowDocument.PageHeight = printDialog.PrintableAreaHeight;
            flowDocument.PageWidth = printDialog.PrintableAreaWidth;
            flowDocument.ColumnWidth = printDialog.PrintableAreaWidth;
            IDocumentPaginatorSource documentPaginatorSource = flowDocument as IDocumentPaginatorSource;
            printDialog.PrintDocument(documentPaginatorSource.DocumentPaginator, "Printing List");
            
        }
        Table CreateNewReportTable(bool pageBreakBeforeSection)
        {
            Table table = new Table
            {
                CellSpacing = 10,
                BreakPageBefore = pageBreakBeforeSection
            };

            for (int i = 0; i < 8; i++)
            {
                table.Columns.Add(new TableColumn());
            }

            Style styleCenter = new Style();
            styleCenter.Setters.Add(new Setter(Paragraph.TextAlignmentProperty, TextAlignment.Center));

            table.RowGroups.Add(new TableRowGroup());
            table.RowGroups[0].Rows.Add(new TableRow());
            TableRow currentRow = table.RowGroups[0].Rows[0];
            currentRow.FontSize = 32;
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Westbury Fire Department"))));
            currentRow.Cells[0].ColumnSpan = 8;
            currentRow.Cells[0].TextAlignment = TextAlignment.Center;

            table.RowGroups[0].Rows.Add(new TableRow());
            currentRow = table.RowGroups[0].Rows[1];
            currentRow.FontSize = 24;
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run(reportTitle)))
            { BorderBrush = Brushes.MidnightBlue, BorderThickness = new Thickness(0, 0, 0, 1) });
            currentRow.Cells[0].ColumnSpan = 8;
            currentRow.Cells[0].TextAlignment = TextAlignment.Center;


            table.RowGroups.Add(new TableRowGroup());
            table.RowGroups[1].FontSize = 12;
            table.RowGroups[1].Style = styleCenter;
            table.RowGroups[1].Rows.Add(new TableRow());
            currentRow = table.RowGroups[1].Rows[0];
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Company")))
            { BorderBrush = Brushes.Black, BorderThickness = new Thickness(0, 0, 0, 0.5) });
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("First Name")))
            { BorderBrush = Brushes.Black, BorderThickness = new Thickness(0, 0, 0, 0.5) });
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Last Name")))
            { BorderBrush = Brushes.Black, BorderThickness = new Thickness(0, 0, 0, 0.5) });
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Phone Number")))
            { BorderBrush = Brushes.Black, BorderThickness = new Thickness(0, 0, 0, 0.5) });
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Cell Phone")))
            { BorderBrush = Brushes.Black, BorderThickness = new Thickness(0, 0, 0, 0.5) });
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Email Address")))
            { BorderBrush = Brushes.Black, BorderThickness = new Thickness(0, 0, 0, 0.5) });
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Department Class")))
            { BorderBrush = Brushes.Black, BorderThickness = new Thickness(0, 0, 0, 0.5) });
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Years Service")))
            { BorderBrush = Brushes.Black, BorderThickness = new Thickness(0, 0, 0, 0.5) });

            table.RowGroups.Add(new TableRowGroup());
            table.RowGroups[2].FontSize = 10;
            table.RowGroups[2].Style = styleCenter;

            return table;
        }
    }
}
