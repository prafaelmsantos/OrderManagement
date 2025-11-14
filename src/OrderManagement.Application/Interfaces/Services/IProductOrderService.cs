namespace OrderManagement.Application.Interfaces.Services
{
    public interface IProductOrderService
    {
        Task<List<ProductSalesDTO>> GetProductSalesByProductIdAsync(long productId);
    }
}
