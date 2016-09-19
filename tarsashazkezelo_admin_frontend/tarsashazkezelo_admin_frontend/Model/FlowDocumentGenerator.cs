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
            p2.Inlines.Add($"Szolgáltatás neve: {serviceName}");
            p2.Inlines.Add($"Dátum: {bi.Date}");
            p2.Inlines.Add($"Összeg: {bi.Amount}");
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
            p.Inlines.Add("Some text ");

            doc.Blocks.Add(p);
            doc.Blocks.Add(p);

            Rectangle rect = new Rectangle();
            rect.Height = 50;
            rect.Width = 100;
            rect.Fill = Brushes.Green;
            rect.Stroke = Brushes.Black;
            p = new Paragraph();
            p.Inlines.Add(new InlineUIContainer(rect));

            doc.Blocks.Add(p);

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
            Pen grayPen = new Pen(Brushes.Gray, 1);
            Typeface font = new Typeface("Arial");
            string str = string.Format("Hello, on {0} at {1}", DateTime.Now.ToShortDateString(),
                DateTime.Now.ToLongTimeString());

            ctx.DrawLine(grayPen, new Point(margin.Width, margin.Height - 10), new Point(page.Width - margin.Width, margin.Height - 10));
            ctx.DrawLine(grayPen, new Point(margin.Width, page.Height - margin.Height + 5), new Point(page.Width - margin.Width, page.Height - margin.Height + 5));

            FormattedText pagenumText = new FormattedText((pageNumber + 1).ToString(), System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, font, 16, Brushes.Black);
            FormattedText companyText = new FormattedText("SCH", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, font, 18, Brushes.Black);
            FormattedText customText = new FormattedText(str, System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, font, 14, Brushes.Black);

            ctx.DrawText(companyText, new Point(page.Width / 2 - companyText.Width / 2, margin.Height / 3));
            ctx.DrawText(pagenumText, new Point(page.Width / 2 - pagenumText.Width / 2, page.Height - margin.Height / 3 - 10));
            ctx.DrawText(customText, new Point(page.Width / 2 - customText.Width / 2, margin.Height / 3 + 20));
            ctx.DrawText(customText, new Point(page.Width / 2 - pagenumText.Width / 2, page.Height - margin.Height / 3 - 30));
        }
    }
}
