using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using wpfapp1;

namespace tarsashazkezelo_admin_frontend.Model
{
    class FlowDocumentGenerator
    {



        public static FlowDocument GenerateDocFromBuildingInvoice(BuildingInvoice bi, string serviceName)
        {
            FlowDocument doc = new FlowDocument();

            Paragraph p = new Paragraph();
            p.Inlines.Add("Épületszámla");
            p.FontSize = 20;
            p.TextAlignment = TextAlignment.Center;

            Paragraph p2 = new Paragraph(new LineBreak());
            p2.Inlines.Add($"Szolgáltatás neve: {serviceName}\n");
            p2.Inlines.Add($"Dátum: {bi.Date}\n");
            p2.Inlines.Add($"Összeg: {bi.Amount}\n");
            p2.FontSize = 15;
            p2.TextAlignment = TextAlignment.Left;

            Paragraph p3=new Paragraph();
            p3.Inlines.Add($"Leírás:\n{bi.Description}");
            doc.Blocks.Add(p);
            doc.Blocks.Add(p2);
            doc.Blocks.Add(p3);
            return doc;
        }

        public static FlowDocument GenerateDocFromInvoice(Invoice i, string serviceName)
        {
            FlowDocument doc = new FlowDocument();

            Paragraph p = new Paragraph();
            p.Inlines.Add("Számla");
            p.FontSize = 20;
            p.TextAlignment = TextAlignment.Center;

            Paragraph p2 = new Paragraph(new LineBreak());
            p2.Inlines.Add($"Szolgáltatás neve: {serviceName}\n");
            p2.Inlines.Add($"Lejárati dátum: {i.DeadLine}\n");
            p2.Inlines.Add($"Összeg: {i.Amount}\n");
            p2.FontSize = 15;
            p2.TextAlignment = TextAlignment.Left;

            Paragraph p3 = new Paragraph();
            p3.Inlines.Add($"Leírás:\n{i.Description}");
            doc.Blocks.Add(p);
            doc.Blocks.Add(p2);
            doc.Blocks.Add(p3);
            return doc;
        }

        public static DocumentPaginator GetPaginator(FlowDocument doc)
        {
            doc.PageHeight = (double)new LengthConverter().ConvertFromInvariantString("29.7cm");
            doc.PageWidth = (double)new LengthConverter().ConvertFromInvariantString("21cm");
            doc.PagePadding = new Thickness((double)new LengthConverter().ConvertFromInvariantString("2cm"));
            doc.Name = "SomeDocument";

            Size pageSize = new Size(doc.PageWidth, doc.PageHeight);
            Size pageMargin = new Size(doc.PagePadding.Left, doc.PagePadding.Top);
            DocumentPaginator innerPaginator = (doc as IDocumentPaginatorSource).DocumentPaginator;
            return new PaginatorWrapper(innerPaginator, pageSize, pageMargin, HeaderFooter);
        }

        public static void HeaderFooter(DrawingContext ctx, int pageNumber, Size margin, Size page)
        {
        }
    }
}
