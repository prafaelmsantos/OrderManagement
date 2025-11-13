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
                .GroupBy(po => po.Color)
                .Select(g => new ProductSalesDTO()
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

            for (int i = 0; i < productOrders.Count; i++)
            {
                productOrders[i].Id = i + 1;
            }

            return productOrders;
        }

        public async Task<List<ProductSalesBySizeResponseDTO>> GetAllMetricsTop(long productId)
        {
            var productOrdersData = await _productOrderRepository
                .GetAllQueryable()
                .Where(po => po.ProductId == productId)
                .AsNoTracking()
                .ToListAsync();

            var allSizes = new[]
            {
        new { Size = "0", Index = 0 },
        new { Size = "1", Index = 1 },
        new { Size = "3", Index = 2 },
        new { Size = "6", Index = 3 },
        new { Size = "12", Index = 4 },
        new { Size = "18", Index = 5 },
        new { Size = "24", Index = 6 },
        new { Size = "36", Index = 7 },
        new { Size = "1Y", Index = 8 },
        new { Size = "2Y", Index = 9 },
        new { Size = "3Y", Index = 10 },
        new { Size = "4Y", Index = 11 },
        new { Size = "6Y", Index = 12 },
        new { Size = "8Y", Index = 13 },
        new { Size = "10Y", Index = 14 },
        new { Size = "12Y", Index = 15 },
    };

            var result = productOrdersData
                .GroupBy(po => po.Color ?? string.Empty)
                .Select(g => new ProductSalesBySizeResponseDTO
                {
                    Color = g.Key,
                    Values = allSizes.Select(sz =>
                    {
                        var totalQuantity = g.Sum(po => sz.Size switch
                        {
                            "0" => po.ZeroMonths,
                            "1" => po.OneMonth,
                            "3" => po.ThreeMonths,
                            "6" => po.SixMonths,
                            "12" => po.TwelveMonths,
                            "18" => po.EighteenMonths,
                            "24" => po.TwentyFourMonths,
                            "36" => po.ThirtySixMonths,
                            "1Y" => po.OneYear,
                            "2Y" => po.TwoYears,
                            "3Y" => po.ThreeYears,
                            "4Y" => po.FourYears,
                            "6Y" => po.SixYears,
                            "8Y" => po.EightYears,
                            "10Y" => po.TenYears,
                            "12Y" => po.TwelveYears,
                            _ => 0
                        });

                        return new ProductSalesBySizeValuesDTO
                        {
                            Size = sz.Size,
                            Index = sz.Index,
                            TotalQuantity = totalQuantity,
                            TotalPrice = totalQuantity * g.First().UnitPrice
                        };
                    }).ToList()
                })
                .ToList();

            return result;
        }

        #endregion
    }
}
