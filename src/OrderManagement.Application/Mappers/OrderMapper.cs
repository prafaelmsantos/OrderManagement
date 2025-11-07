namespace OrderManagement.Application.Mappers
{
    public static class OrderMapper
    {
        public static OrderDTO ToOrderDTO(this Order order)
        {
            return new OrderDTO()
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                Status = order.Status,
                CreatedAt = order.CreatedAt,
                QuantityTotal = order.ProductsOrders.Select(x => x.TotalQuantity).Sum(),
                PriceTotal = order.ProductsOrders.Select(x => x.UnitPrice).Sum(),
                ProductsOrders = [.. order.ProductsOrders.Select(productOrder => new ProductOrderDTO()
                {
                    OrderId = productOrder.OrderId,
                    ProductId = productOrder.ProductId,
                    Product = new ProductDTO(){
                        Id = productOrder.Product.Id,
                        Reference = productOrder.Product.Reference,
                        Description = productOrder.Product.Description,
                        UnitPrice = productOrder.Product.UnitPrice,
                        CreatedAt = productOrder.Product.CreatedAt,
                        ProductsOrders = []
                    },
                    UnitPrice = productOrder.UnitPrice,
                    Color = productOrder.Color,

                    OneMonth = productOrder.OneMonth,
                    ThreeMonths = productOrder.ThreeMonths,
                    SixMonths = productOrder.SixMonths,
                    TwelveMonths = productOrder.TwelveMonths,
                    EighteenMonths = productOrder.EighteenMonths,
                    TwentyFourMonths = productOrder.TwentyFourMonths,
                    ThirtySixMonths = productOrder.ThirtySixMonths,

                    OneYear = productOrder.OneYear,
                    TwoYears = productOrder.TwoYears,
                    ThreeYears = productOrder.ThreeYears,
                    FourYears = productOrder.FourYears,
                    SixYears = productOrder.SixYears,
                    EightYears = productOrder.EightYears,
                    TenYears = productOrder.TenYears,
                    TwelveYears = productOrder.TwelveYears,

                    TotalQuantity = productOrder.TotalQuantity,
                    TotalPrice = productOrder.TotalQuantity * productOrder.UnitPrice
                })]
            };
        }
    }
}
