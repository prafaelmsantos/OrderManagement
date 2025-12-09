namespace OrderManagement.API.Documents
{
    public class ProductReportsDocument : IDocument
    {
        private readonly Image? _logoImage;
        private readonly ProductReportDTO _productReportDTO;

        public ProductReportsDocument(ProductReportDTO productReportDTO)
        {
            _productReportDTO = productReportDTO;

            string path = Path.Combine(AppContext.BaseDirectory, "logo.png");

            _logoImage = File.Exists(path) ? Image.FromFile(path) : null;
        }

        public DocumentMetadata GetMetadata() => new()
        {
            Title = $"Relatório de Vendas: Produto {_productReportDTO.Product.Reference}"
        };

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(40);

                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);

                page.Footer().AlignCenter().Text(text =>
                {
                    text.CurrentPageNumber();
                    text.Span(" / ");
                    text.TotalPages();
                });
            });
        }

        void ComposeHeader(IContainer container)
        {
            container.Row(row =>
            {
                if (_logoImage is not null)
                {
                    row.ConstantItem(80).AlignLeft().AlignMiddle().Image(_logoImage);
                }

                row.RelativeItem(7).Column(column =>
                {
                    column.Item().PaddingLeft(10).Text("Raith – Exportação de Têxteis, S.A.")
                        .FontSize(12).Bold();

                    column.Item().PaddingLeft(10).Text("NIF: 501380523");
                    column.Item().PaddingLeft(10).Text("Rua Um da Zona Industrial, 205");
                    column.Item().PaddingLeft(10).Text("4630-488 Marco de Canaveses");
                    column.Item().PaddingLeft(10).Text("Tel: 255 534 211 / 939 587 886");
                    column.Item().PaddingLeft(10).Text("Email: geral@raithsa.com");
                });

                row.RelativeItem(5).Column(column =>
                {
                    column.Item().Text("Relatório de vendas").FontSize(18).Bold();

                    column.Item().Text($"Produto {_productReportDTO.Product.Reference}")
                        .FontSize(14).SemiBold();

                    column.Item().Text($"Descrição: {_productReportDTO.Product.Description}");
                    column.Spacing(5);
                    column.Item().Text($"Data/Hora: {DateTime.UtcNow:G}")
                        .FontSize(9).SemiBold();
                });
            });
        }

        void ComposeContent(IContainer container)
        {
            container.PaddingTop(40).Column(column =>
            {
                column.Spacing(30);

                column.Item().PaddingTop(20).Element(ComposeTable);
            });
        }

        void ComposeTable(IContainer container)
        {
            TextStyle headerStyle = TextStyle.Default.ExtraBold().FontSize(9);

            container.PaddingTop(10).Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(16);       // Cor
                    columns.RelativeColumn(2);        // 0M
                    columns.RelativeColumn(2);        // 1M
                    columns.RelativeColumn(2);        // 3M
                    columns.RelativeColumn(2);        // 6M
                    columns.RelativeColumn(2);        // 9M
                    columns.RelativeColumn(2);        // 12M
                    columns.RelativeColumn(2);        // 18M
                    columns.RelativeColumn(2);        // 24M
                    columns.RelativeColumn(2);        // 1Y
                    columns.RelativeColumn(2);        // 2Y
                    columns.RelativeColumn(2);        // 3Y
                    columns.RelativeColumn(2);        // 4Y
                    columns.RelativeColumn(2);        // 6Y
                    columns.RelativeColumn(2);        // 8Y
                    columns.RelativeColumn(2);        // 10Y
                    columns.RelativeColumn(2);        // 12Y
                    columns.RelativeColumn(10);       //Qt Total
                });

                table.Header(header =>
                {
                    header.Cell().AlignLeft().Text("Cor").Style(headerStyle);
                    header.Cell().AlignCenter().Text("00 M").Style(headerStyle);
                    header.Cell().AlignCenter().Text("01 M").Style(headerStyle);
                    header.Cell().AlignCenter().Text("03 M").Style(headerStyle);
                    header.Cell().AlignCenter().Text("06 M").Style(headerStyle);
                    header.Cell().AlignCenter().Text("09 M").Style(headerStyle);
                    header.Cell().AlignCenter().Text("12 M").Style(headerStyle);
                    header.Cell().AlignCenter().Text("18 M").Style(headerStyle);
                    header.Cell().AlignCenter().Text("24 M").Style(headerStyle);
                    header.Cell().AlignCenter().Text("01 Y").Style(headerStyle);
                    header.Cell().AlignCenter().Text("02 Y").Style(headerStyle);
                    header.Cell().AlignCenter().Text("03 Y").Style(headerStyle);
                    header.Cell().AlignCenter().Text("04 Y").Style(headerStyle);
                    header.Cell().AlignCenter().Text("06 Y").Style(headerStyle);
                    header.Cell().AlignCenter().Text("08 Y").Style(headerStyle);
                    header.Cell().AlignCenter().Text("10 Y").Style(headerStyle);
                    header.Cell().AlignCenter().Text("12 Y").Style(headerStyle);
                    header.Cell().AlignRight().Text("Qt. Total").Style(headerStyle);

                    header.Cell().ColumnSpan(18).PaddingTop(3).BorderColor(Colors.Black);
                });

                TextStyle cellStyle = TextStyle.Default.FontSize(9);

                foreach (var size in _productReportDTO.ProductSalesBySizes)
                {
                    table.Cell().AlignLeft().Element(CellStyle).Text(size.Color).Style(cellStyle);

                    foreach (var sizeValue in size.Values)
                    {
                        table.Cell().AlignCenter().Element(CellStyle).Text(sizeValue.TotalQuantity > 0 ? sizeValue.TotalQuantity.ToString() : "-").Style(cellStyle);
                    }

                    table.Cell().AlignRight().Element(CellStyle).Text(size.TotalQuantity.ToString()).Style(cellStyle);

                    static IContainer CellStyle(IContainer container) =>
                        container.PaddingVertical(5);
                }

                table.Cell().ColumnSpan(17).AlignRight().PaddingTop(15).Text("Total:").Style(headerStyle);
                table.Cell().AlignRight().PaddingTop(15).Text(_productReportDTO.TotalQuantity > 0 ? _productReportDTO.TotalQuantity.ToString() : string.Empty).Style(headerStyle);
            });
        }
    }
}
