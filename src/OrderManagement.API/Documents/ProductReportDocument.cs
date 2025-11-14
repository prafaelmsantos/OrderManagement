namespace OrderManagement.API.Documents
{
    public class ProductReportsDocument : IDocument
    {
        public static Image LogoImage { get; } = Image.FromFile("logo.png");
        private readonly ProductReportDTO _productReportDTO;

        public ProductReportsDocument(ProductReportDTO productReportDTO)
        {
            _productReportDTO = productReportDTO;
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
                row.ConstantItem(80).AlignLeft().AlignMiddle().Image(LogoImage);

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
            var headerStyle = TextStyle.Default.ExtraBold().FontSize(10);

            container.Column(col =>
            {
                foreach (var report in _productReportDTO.ProductSalesBySizes)
                {
                    col.Spacing(20);
                    // Título do produto
                    col.Item().AlignCenter().Text($"Cor: {report.Color}").SemiBold().FontSize(14);

                    // Tabela de tamanhos
                    col.Item().Table(table =>
                    {
                        // Colunas
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(4);
                            columns.RelativeColumn(4);
                            columns.RelativeColumn(4);
                        });

                        // Cabeçalho
                        table.Header(header =>
                        {
                            header.Cell().Element(CellStyle).AlignCenter().AlignMiddle().Text("Tamanho").Style(headerStyle);
                            header.Cell().Element(CellStyle).AlignCenter().AlignMiddle().Text("Quantidade Total").Style(headerStyle);
                            header.Cell().Element(CellStyle).AlignCenter().AlignMiddle().Text("Preço Total").Style(headerStyle);
                        });

                        // Linhas de dados
                        foreach (var item in report.Values)
                        {
                            table.Cell().Element(CellStyle).Text(item.Size.ToProductSizeString());
                            table.Cell().Element(CellStyle).Text(item.TotalQuantity.ToString());
                            table.Cell().Element(CellStyle).Text(item.TotalPrice.ToString("C2"));
                        }

                        // Linha de totais
                        table.Cell().Element(CellStyle).Text("Total").SemiBold();
                        table.Cell().Element(CellStyle).Text(report.TotalQuantity.ToString()).SemiBold();
                        table.Cell().Element(CellStyle).Text(report.TotalPrice.ToString("C2")).SemiBold();

                        // Função de estilo das células
                        static IContainer CellStyle(IContainer c) => c
                            .Padding(5).AlignCenter();
                    });
                }
            });
        }

    }

}
