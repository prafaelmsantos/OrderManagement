namespace OrderManagement.Application.Dtos
{
    public record ProductSalesSummaryDTO
    {
        /// <summary>
        /// Cor do produto
        /// </summary>
        public string? Color { get; set; }

        public string? Size { get; set; }

        /// <summary>
        /// Quantidade total vendida desse produto nesta cor
        /// </summary>
        public int TotalQuantity { get; set; }

        /// <summary>
        /// Valor total vendido para esta cor
        /// </summary>
        public double TotalPrice { get; set; }
    }
}
