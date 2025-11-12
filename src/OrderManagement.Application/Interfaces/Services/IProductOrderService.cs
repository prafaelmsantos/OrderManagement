namespace OrderManagement.Application.Interfaces.Services
{
    public interface IProductOrderService
    {
        Task<List<ProductSalesSummaryDTO>> GetAllMetrics(long productId);
        Task<List<ProductSalesBySizeDTO>> GetAllMetricsTop(long productId);
    }
}
