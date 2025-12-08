namespace OrderManagement.API.Documents
{
    public class OrderDocument : IDocument
    {
        private readonly Image? _logoImage;

        private readonly OrderDTO _order;

        public OrderDocument(OrderDTO orderDTO)
        {
            _order = orderDTO;
            string path = Path.Combine(AppContext.BaseDirectory, "logo.png");

            _logoImage = File.Exists(path) ? Image.FromFile(path) : null;
        }

        public DocumentMetadata GetMetadata() => new()
        {
            Title = $"Nota de Encomenda Nº{_order.Id}"
        };

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(25);

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
                    column.Item().Text($"Nota de Encomenda Nº{_order.Id}")
                        .FontSize(20).Bold();

                    column.Spacing(5);

                    column.Item().Text($"Método de Pagamento: {_order.Customer?.PaymentMethod ?? "-"}");
                    column.Item().Text($"Data: {_order.CreatedDate:G}").FontSize(9);
                });
            });
        }

        void ComposeContent(IContainer container)
        {
            container.PaddingTop(40).Column(column =>
            {
                column.Spacing(30);

                column.Item().Element(c =>
                {
                    c.Column(cc =>
                    {
                        cc.Item().Text("Dados do cliente:").Bold();
                        cc.Spacing(10);
                        cc.Item().Row(row =>
                        {
                            row.RelativeItem(8).Text(text =>
                            {
                                text.Span("Nome: ").Bold();
                                text.Span(_order.Customer?.FullName ?? "-");
                            });

                            row.RelativeItem(4).Text(text =>
                            {
                                text.Span("NIF: ").Bold();
                                text.Span(_order.Customer?.TaxIdentificationNumber ?? "-");
                            });
                        });
                        cc.Spacing(10);
                        cc.Item().Row(row =>
                        {
                            row.RelativeItem(8).Text(text =>
                            {
                                text.Span("Morada: ").Bold();
                                text.Span(_order.Customer?.Address ?? "-");
                            });

                            row.RelativeItem(4).Text(text =>
                            {
                                text.Span("Código-Postal: ").Bold();
                                text.Span(_order.Customer?.PostalCode ?? "-");
                            });
                        });
                        cc.Spacing(10);
                        cc.Item().Row(row =>
                        {
                            row.RelativeItem(8).Text(text =>
                            {
                                text.Span("Cidade: ").Bold();
                                text.Span(_order.Customer?.City ?? "-");
                            });

                            row.RelativeItem(4).Text(text =>
                            {
                                text.Span("Contacto: ").Bold();
                                text.Span(_order.Customer?.Contact ?? "-");
                            });
                        });
                    });
                });

                column.Item().PaddingTop(20).Element(ComposeObservations);

                column.Item().PaddingTop(30).Element(ComposeTable);
            });
        }

        void ComposeTable(IContainer container)
        {
            TextStyle headerStyle = TextStyle.Default.ExtraBold().FontSize(9);

            container.PaddingTop(10).Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(6);        // Produto
                    columns.RelativeColumn(16);       // Descrição
                    columns.RelativeColumn(5);        // Cor
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
                    columns.RelativeColumn(6);
                });

                table.Header(header =>
                {
                    header.Cell().AlignLeft().Text("Ref.").Style(headerStyle);
                    header.Cell().AlignLeft().Text("Descrição").Style(headerStyle);
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
                    header.Cell().AlignRight().Text("Preço Unit.").Style(headerStyle);

                    header.Cell().ColumnSpan(20).PaddingTop(3).BorderColor(Colors.Black);
                });

                TextStyle cellStyle = TextStyle.Default.FontSize(9);

                foreach (var item in _order.ProductsOrders)
                {
                    table.Cell().AlignLeft().Element(CellStyle).Text(item.Product?.Reference ?? "-").Style(cellStyle);
                    table.Cell().AlignLeft().Element(CellStyle).Text(item.Product?.Description ?? "-").Style(cellStyle);
                    table.Cell().AlignLeft().Element(CellStyle).Text(item.Color).Style(cellStyle);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.ZeroMonths > 0 ? item.ZeroMonths.ToString() : "-").Style(cellStyle);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.OneMonth > 0 ? item.OneMonth.ToString() : "-").Style(cellStyle);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.ThreeMonths > 0 ? item.ThreeMonths.ToString() : "-").Style(cellStyle);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.SixMonths > 0 ? item.SixMonths.ToString() : "-").Style(cellStyle);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.NineMonths > 0 ? item.NineMonths.ToString() : "-").Style(cellStyle);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.TwelveMonths > 0 ? item.TwelveMonths.ToString() : "-").Style(cellStyle);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.EighteenMonths > 0 ? item.EighteenMonths.ToString() : "-").Style(cellStyle);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.TwentyFourMonths > 0 ? item.TwentyFourMonths.ToString() : "-").Style(cellStyle);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.OneYear > 0 ? item.OneYear.ToString() : "-").Style(cellStyle);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.TwoYears > 0 ? item.TwoYears.ToString() : "-").Style(cellStyle);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.ThreeYears > 0 ? item.ThreeYears.ToString() : "-").Style(cellStyle);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.FourYears > 0 ? item.FourYears.ToString() : "-").Style(cellStyle);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.SixYears > 0 ? item.SixYears.ToString() : "-").Style(cellStyle);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.EightYears > 0 ? item.EightYears.ToString() : "-").Style(cellStyle);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.TenYears > 0 ? item.TenYears.ToString() : "-").Style(cellStyle);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.TwelveYears > 0 ? item.TwelveYears.ToString() : "-").Style(cellStyle);
                    table.Cell().AlignRight().Element(CellStyle).Text($"€ {item.UnitPrice:F2}").Style(cellStyle.Bold());


                    static IContainer CellStyle(IContainer container) =>
                        container.PaddingVertical(5);
                }
            });
        }

        void ComposeObservations(IContainer container)
        {
            container.ShowEntire().Column(column =>
            {
                column.Item().Text("Observações: ").FontSize(12).Bold();
                column.Item().Text(_order.Observations);
            });
        }
    }
}
