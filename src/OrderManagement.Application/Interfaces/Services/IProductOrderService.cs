namespace OrderManagement.Application.Interfaces.Services
{
    public interface IProductOrderService
    {
        Task<List<ProductSalesDTO>> GetProductSalesByProductIdAsync(long productId);
        Task<List<ProductSalesBySizeResponseDTO>> GetAllMetricsTop(long productId);
    }
}
