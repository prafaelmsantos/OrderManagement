using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace OrderManagement.API.Pdf
{

    // Documento PDF
    public class InvoiceDocument : IDocument
    {
        public static Image LogoImage { get; } = Image.FromFile("logo.png");
        public OrderDTO Model { get; }

        public InvoiceDocument(OrderDTO model)
        {
            Model = model;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

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
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text($"Invoice #{Model.Id}")
                        .FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);

                    column.Item().Text($"Issue date: {Model.CreatedDate:dd/MM/yyyy}");
                    column.Item().Text($"Payment: {Model.PaymentMethod}");
                });

                row.ConstantItem(175).Image(LogoImage);
            });
        }

        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(40).Column(column =>
            {
                column.Spacing(20);

                column.Item().Element(c =>
                {
                    c.Column(cc =>
                    {
                        cc.Item().Text("Customer").SemiBold();
                        cc.Item().Text(Model.Customer.FullName);
                        cc.Item().Text(Model.Customer.TaxIdentificationNumber);
                        cc.Item().Text(Model.Customer.Address);
                        cc.Item().Text(Model.Customer.PostalCode);
                        cc.Item().Text(Model.Customer.City);
                        cc.Item().Text(Model.Customer.Contact);
                    });
                });

                column.Item().Element(ComposeTable);

                column.Item().AlignRight().Text($"Grand total: {Model.TotalPrice:C}").SemiBold();

                if (!string.IsNullOrWhiteSpace(Model.Observations))
                    column.Item().PaddingTop(25).Element(ComposeObservations);
            });
        }

        void ComposeTableNew(IContainer container)
        {
            var headerStyle = TextStyle.Default.ExtraBold().FontSize(10);
            string[] sizes = { "0M", "1M", "3M", "6M", "12M", "18M", "24M", "36M",
                       "1Y", "2Y", "3Y", "4Y", "6Y", "8Y", "10Y", "12Y" };

            container.Row(row =>
            {
                // Parte esquerda (Produto, Descrição, Cor)
                row.RelativeItem(3).Column(left =>
                {
                    left.Spacing(0);
                    left.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(3);  // Produto
                            columns.RelativeColumn(5);  // Descrição
                            columns.RelativeColumn(2);  // Cor
                        });

                        // Cabeçalho
                        table.Header(header =>
                        {
                            header.Cell().AlignLeft().Text("Ref.").Style(headerStyle);
                            header.Cell().AlignLeft().Text("Descrição").Style(headerStyle);
                            header.Cell().AlignLeft().Text("Cor").Style(headerStyle);

                            header.Cell().ColumnSpan(3).PaddingTop(3).BorderBottom(1).BorderColor(Colors.Grey.Lighten2);
                        });

                        // Corpo
                        foreach (var item in Model.ProductsOrders)
                        {
                            table.Cell().AlignLeft().Element(CellStyle).Text(item.Product.Reference);
                            table.Cell().AlignLeft().Element(CellStyle).Text(item.Product.Description ?? "-");
                            table.Cell().AlignLeft().Element(CellStyle).Text(string.IsNullOrWhiteSpace(item.Color) ? "-" : item.Color);
                        }

                        static IContainer CellStyle(IContainer container) =>
                            container.BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Lighten2)
                                     .PaddingVertical(3).PaddingHorizontal(2);
                    });
                });

                // Parte direita (tamanhos + Preço Unit.)
                row.RelativeItem(7).Column(right =>
                {

                    right.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            foreach (var _ in sizes)
                                columns.RelativeColumn(2); // tamanhos iguais

                            columns.RelativeColumn(4); // Preço Unitário
                        });

                        // Cabeçalho
                        table.Header(header =>
                        {
                            foreach (var size in sizes)
                                header.Cell().AlignCenter().Text(size).Style(headerStyle);

                            header.Cell().AlignRight().Text("Preço Unit.").Style(headerStyle);
                            header.Cell().ColumnSpan(17).PaddingTop(3);
                        });

                        // Corpo
                        foreach (var item in Model.ProductsOrders)
                        {
                            var values = new int[] {
                        item.ZeroMonths, item.OneMonth, item.ThreeMonths, item.SixMonths,
                        item.TwelveMonths, item.EighteenMonths, item.TwentyFourMonths, item.ThirtySixMonths,
                        item.OneYear, item.TwoYears, item.ThreeYears, item.FourYears,
                        item.SixYears, item.EightYears, item.TenYears, item.TwelveYears
                    };

                            foreach (var val in values)
                                table.Cell().AlignCenter().Element(CellStyle).Text(val);

                            table.Cell().AlignRight().Element(CellStyle).Text($"{item.UnitPrice:C}");
                        }

                        static IContainer CellStyle(IContainer container) =>
                            container.BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Lighten2)
                                     .PaddingVertical(3).PaddingHorizontal(2);
                    });
                });
            });
        }


        void ComposeTable(IContainer container)
        {
            var headerStyle = TextStyle.Default.ExtraBold().FontSize(9);

            container.Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(6);       // Produto
                    columns.RelativeColumn(18);       // Descrição
                    columns.RelativeColumn(5);       // Cor
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
                    columns.RelativeColumn(4);

                });

                // Cabeçalho
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
                    header.Cell().AlignRight().Text("Preço Unit. €").Style(headerStyle);

                    header.Cell().ColumnSpan(20).PaddingTop(3).BorderColor(Colors.Black);
                });

                foreach (var item in Model.ProductsOrders)
                {
                    table.Cell().AlignLeft().Element(CellStyle).Text(item.Product?.Reference ?? string.Empty);
                    table.Cell().AlignLeft().Element(CellStyle).Text(item.Product?.Description ?? string.Empty);
                    table.Cell().AlignLeft().Element(CellStyle).Text(item.Color);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.ZeroMonths > 0 ? item.ZeroMonths.ToString() : string.Empty);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.OneMonth > 0 ? item.OneMonth.ToString() : string.Empty);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.ThreeMonths > 0 ? item.ThreeMonths.ToString() : string.Empty);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.SixMonths > 0 ? item.SixMonths.ToString() : string.Empty);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.TwelveMonths > 0 ? item.TwelveMonths.ToString() : string.Empty);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.EighteenMonths > 0 ? item.EighteenMonths.ToString() : string.Empty);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.TwentyFourMonths > 0 ? item.TwentyFourMonths.ToString() : string.Empty);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.ThirtySixMonths > 0 ? item.ThirtySixMonths.ToString() : string.Empty);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.OneYear > 0 ? item.OneYear.ToString() : string.Empty);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.TwoYears > 0 ? item.TwoYears.ToString() : string.Empty);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.ThreeYears > 0 ? item.ThreeYears.ToString() : string.Empty);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.FourYears > 0 ? item.FourYears.ToString() : string.Empty);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.SixYears > 0 ? item.SixYears.ToString() : string.Empty);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.EightYears > 0 ? item.EightYears.ToString() : string.Empty);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.TenYears > 0 ? item.TenYears.ToString() : string.Empty);
                    table.Cell().AlignCenter().Element(CellStyle).Text(item.TwelveYears > 0 ? item.TwelveYears.ToString() : string.Empty);
                    table.Cell().AlignRight().Element(CellStyle).Text(item.UnitPrice.ToString());

                    static IContainer CellStyle(IContainer container) =>
                        container.PaddingVertical(5);
                }
            });
        }


        void ComposeObservations(IContainer container)
        {
            container.ShowEntire().Background(Colors.Grey.Lighten3).Padding(10).Column(column =>
            {
                column.Spacing(5);
                column.Item().Text("Observations").FontSize(14).SemiBold();
                column.Item().Text(Model.Observations);
            });
        }
    }
}
