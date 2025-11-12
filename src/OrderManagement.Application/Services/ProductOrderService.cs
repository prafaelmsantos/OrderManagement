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
        public async Task<List<ProductSalesSummaryDTO>> GetAllMetrics(long productId)
        {
            var productOrders = await _productOrderRepository
             .GetAllQueryable()
             .Where(po => po.ProductId == productId)
             .AsNoTracking()
             .GroupBy(po => po.Color)
             .Select(g => new ProductSalesSummaryDTO()
             {
                 Color = g.Key,
                 TotalQuantity = g.Sum(po =>
                     po.ZeroMonths +
                     po.OneMonth +
                     po.ThreeMonths +
                     po.SixMonths +
                     po.TwelveMonths +
                     po.EighteenMonths +
                     po.TwentyFourMonths +
                     po.ThirtySixMonths +
                     po.OneYear +
                     po.TwoYears +
                     po.ThreeYears +
                     po.FourYears +
                     po.SixYears +
                     po.EightYears +
                     po.TenYears +
                     po.TwelveYears),
                 TotalPrice = g.Sum(po =>
                     (po.ZeroMonths +
                      po.OneMonth +
                      po.ThreeMonths +
                      po.SixMonths +
                      po.TwelveMonths +
                      po.EighteenMonths +
                      po.TwentyFourMonths +
                      po.ThirtySixMonths +
                      po.OneYear +
                      po.TwoYears +
                      po.ThreeYears +
                      po.FourYears +
                      po.SixYears +
                      po.EightYears +
                      po.TenYears +
                      po.TwelveYears) * po.UnitPrice)
             })
             .ToListAsync();


            return productOrders;
        }

        public async Task<List<ProductSalesBySizeDTO>> GetAllMetricsTop(long productId)
        {
            var productOrdersData = await _productOrderRepository
                .GetAllQueryable()
                .Where(po => po.ProductId == productId)
                .AsNoTracking()
                .ToListAsync(); // executa a query no banco

            // 2️⃣ Transformar cada ProductOrder em várias linhas, uma por tamanho
            var productOrdersBySize = productOrdersData
                .SelectMany(po => new[]
                {
        new ProductSalesBySizeDTO { Index = 1,Color = po.Color, Size = "0", TotalQuantity = po.ZeroMonths, TotalPrice = po.ZeroMonths * po.UnitPrice },
        new ProductSalesBySizeDTO { Index = 2,Color = po.Color, Size = "1", TotalQuantity = po.OneMonth, TotalPrice = po.OneMonth * po.UnitPrice },
        new ProductSalesBySizeDTO { Index = 3,Color = po.Color, Size = "3", TotalQuantity = po.ThreeMonths, TotalPrice = po.ThreeMonths * po.UnitPrice },
        new ProductSalesBySizeDTO { Index = 4,Color = po.Color, Size = "6", TotalQuantity = po.SixMonths, TotalPrice = po.SixMonths * po.UnitPrice },
        new ProductSalesBySizeDTO { Index = 5,Color = po.Color, Size = "12", TotalQuantity = po.TwelveMonths, TotalPrice = po.TwelveMonths * po.UnitPrice },
        new ProductSalesBySizeDTO { Index = 6,Color = po.Color, Size = "18", TotalQuantity = po.EighteenMonths, TotalPrice = po.EighteenMonths * po.UnitPrice },
        new ProductSalesBySizeDTO { Index =7,Color = po.Color, Size = "24", TotalQuantity = po.TwentyFourMonths, TotalPrice = po.TwentyFourMonths * po.UnitPrice },
        new ProductSalesBySizeDTO { Index = 8,Color = po.Color, Size = "36", TotalQuantity = po.ThirtySixMonths, TotalPrice = po.ThirtySixMonths * po.UnitPrice },
        new ProductSalesBySizeDTO { Index = 9,Color = po.Color, Size = "1Y", TotalQuantity = po.OneYear, TotalPrice = po.OneYear * po.UnitPrice },
        new ProductSalesBySizeDTO { Index = 10,Color = po.Color, Size = "2Y", TotalQuantity = po.TwoYears, TotalPrice = po.TwoYears * po.UnitPrice },
        new ProductSalesBySizeDTO { Index = 11,Color = po.Color, Size = "3Y", TotalQuantity = po.ThreeYears, TotalPrice = po.ThreeYears * po.UnitPrice },
        new ProductSalesBySizeDTO { Index = 12,Color = po.Color, Size = "4Y", TotalQuantity = po.FourYears, TotalPrice = po.FourYears * po.UnitPrice },
        new ProductSalesBySizeDTO { Index = 13,Color = po.Color, Size = "6Y", TotalQuantity = po.SixYears, TotalPrice = po.SixYears * po.UnitPrice },
        new ProductSalesBySizeDTO { Index = 14,Color = po.Color, Size = "8Y", TotalQuantity = po.EightYears, TotalPrice = po.EightYears * po.UnitPrice },
        new ProductSalesBySizeDTO { Index = 15,Color = po.Color, Size = "10Y", TotalQuantity = po.TenYears, TotalPrice = po.TenYears * po.UnitPrice },
        new ProductSalesBySizeDTO { Index = 16,Color = po.Color, Size = "12Y", TotalQuantity = po.TwelveYears, TotalPrice = po.TwelveYears * po.UnitPrice },
                })
                .Where(x => x.TotalQuantity >= 0) // opcional, remove tamanhos com 0 vendas
                .GroupBy(x => new { x.Color, x.Size })
                .Select(g => new ProductSalesBySizeDTO
                {
                    Color = g.Key.Color,
                    Size = g.Key.Size,
                    TotalQuantity = g.Sum(x => x.TotalQuantity),
                    TotalPrice = g.Sum(x => x.TotalPrice)
                })
                .OrderBy(x => x.Index)
                .ToList();

            return productOrdersBySize;
        }


        #endregion
    }
}
