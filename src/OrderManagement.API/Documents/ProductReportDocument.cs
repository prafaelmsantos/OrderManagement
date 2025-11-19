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
            if (File.Exists(path))
            {
                _logoImage = Image.FromFile(path);
            }
            else
            {
                _logoImage = null;
            }
        }

        public DocumentMetadata GetMetadata() => new()
        {
            Title = $"Relatório de Produtos: {_productReportDTO.Product.Reference}"
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
                // ─────────────── Logotipo ───────────────
                if (_logoImage is not null)
                {
                    row.ConstantItem(80).AlignLeft().AlignMiddle().Image(_logoImage);
                }

                // ─────────────── Informação da Empresa ───────────────
                row.RelativeItem(7).Column(column =>
                {
                    column.Item().PaddingLeft(10).Text("Raith – Exportação de Têxteis, S.A.")
                        .FontSize(12).SemiBold();

                    column.Item().PaddingLeft(10).Text("NIF: 123456789");
                    column.Item().PaddingLeft(10).Text("Rua Um da Zona Industrial, 205");
                    column.Item().PaddingLeft(10).Text("4630-488 Marco de Canaveses");
                    column.Item().PaddingLeft(10).Text("Tel: 255 534 211 / 939 587 886");
                    column.Item().PaddingLeft(10).Text("Email: geral@raithsa.com");
                });

                row.RelativeItem(5).Column(column =>
                {
                    column.Item().Text("Report").FontSize(20).SemiBold();

                    column.Item().Text($"Produto {_productReportDTO.Product.Reference}")
                        .FontSize(16).SemiBold();

                    column.Item().Text($"Descrição: {_productReportDTO.Product.Description}");
                    column.Spacing(5);
                    column.Item().Text($"Data: {DateTime.UtcNow:G}")
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
                    columns.RelativeColumn(4);        // Cor
                    columns.RelativeColumn(2);        // 0M
                    columns.RelativeColumn(2);        // 1M
                    columns.RelativeColumn(2);        // 3M
                    columns.RelativeColumn(2);        // 6M
                    columns.RelativeColumn(2);        // 12M
                    columns.RelativeColumn(2);        // 18M
                    columns.RelativeColumn(2);        // 24M
                    columns.RelativeColumn(2);        // 36M
                    columns.RelativeColumn(2);        // 1Y
                    columns.RelativeColumn(2);        // 2Y
                    columns.RelativeColumn(2);        // 3Y
                    columns.RelativeColumn(2);        // 4Y
                    columns.RelativeColumn(2);        // 6Y
                    columns.RelativeColumn(2);        // 8Y
                    columns.RelativeColumn(2);        // 10Y
                    columns.RelativeColumn(2);        // 12Y
                    columns.RelativeColumn(2);        //Qt Total
                });

                // Cabeçalho
                table.Header(header =>
                {
                    header.Cell().AlignLeft().Text("Cor").Style(headerStyle);
                    header.Cell().AlignCenter().Text("00 M").Style(headerStyle);
                    header.Cell().AlignCenter().Text("01 M").Style(headerStyle);
                    header.Cell().AlignCenter().Text("03 M").Style(headerStyle);
                    header.Cell().AlignCenter().Text("06 M").Style(headerStyle);
                    header.Cell().AlignCenter().Text("12 M").Style(headerStyle);
                    header.Cell().AlignCenter().Text("18 M").Style(headerStyle);
                    header.Cell().AlignCenter().Text("24 M").Style(headerStyle);
                    header.Cell().AlignCenter().Text("36 M").Style(headerStyle);
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
                        table.Cell().AlignCenter().Element(CellStyle).Text(sizeValue.TotalQuantity > 0 ? sizeValue.TotalQuantity.ToString() : string.Empty).Style(cellStyle);
                    }

                    table.Cell().AlignRight().Element(CellStyle).Text(size.TotalQuantity > 0 ? size.TotalQuantity.ToString() : string.Empty).Style(cellStyle);

                    static IContainer CellStyle(IContainer container) =>
                        container.PaddingVertical(5);
                }
            });
        }
    }
}
