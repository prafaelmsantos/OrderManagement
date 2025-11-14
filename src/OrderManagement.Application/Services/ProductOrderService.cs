namespace OrderManagement.Application.Services
{
    public sealed class ProductOrderService : IProductOrderService
    {
        #region Private variables
        private readonly IProductOrderRepository _productOrderRepository;
        #endregion

        #region Constructors
        public ProductOrderService(IProductOrderRepository productOrderRepository)
        {
            _productOrderRepository = productOrderRepository;
        }
        #endregion

        #region Public methods
        public async Task<List<ProductSalesDTO>> GetProductSalesByProductIdAsync(long productId)
        {
            List<ProductSalesDTO> productOrders = await _productOrderRepository
                .GetAllQueryable()
                .AsNoTracking()
                .Where(po => po.ProductId == productId)
                .GroupBy(po => po.Color ?? "-")
                .Select(g => new ProductSalesDTO()
                {
                    Color = g.Key,
                    TotalQuantity = g.Sum(po => po.TotalQuantity),
                    TotalPrice = g.Sum(po => po.TotalPrice)
                })
                .ToListAsync();

            for (int i = 0; i < productOrders.Count; i++)
            {
                productOrders[i].Id = i + 1;
            }

            return productOrders;
        }

        #endregion
    }
}
