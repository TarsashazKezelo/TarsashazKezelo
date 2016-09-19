using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace wpfapp1
{
    class PaginatorWrapper : DocumentPaginator
    {
        public override DocumentPage GetPage(int pageNumber)
        {
            DrawingVisual headerFooter = new DrawingVisual();
            using (DrawingContext ctx = headerFooter.RenderOpen())
            {
                drawMethod(ctx, pageNumber, pageMargin, PageSize);
            }

            DocumentPage page = innerPaginator.GetPage(pageNumber);

            ContainerVisual newpage = new ContainerVisual();
            newpage.Children.Add(page.Visual);
            newpage.Children.Add(headerFooter);

            return new DocumentPage(newpage, pageSize, page.BleedBox, page.ContentBox);
        }

        public override bool IsPageCountValid { get { return innerPaginator.IsPageCountValid; } }
        public override int PageCount { get { return innerPaginator.PageCount; } }
        public override Size PageSize
        {
            get { return innerPaginator.PageSize; }
            set { innerPaginator.PageSize = value; }
        }
        public override IDocumentPaginatorSource Source { get { return innerPaginator.Source; } }

        Size pageSize;
        Size pageMargin;
        DocumentPaginator innerPaginator;
        Action<DrawingContext, int, Size, Size> drawMethod;

        public PaginatorWrapper(DocumentPaginator paginator, Size size, Size margin, Action<DrawingContext, int, Size, Size> method)
        {
            innerPaginator = paginator;
            pageSize = size;
            pageMargin = margin;
            drawMethod = method;
            innerPaginator.PageSize = new Size(size.Width - margin.Width * 2, size.Height - margin.Height * 2);

        }
    }
}
