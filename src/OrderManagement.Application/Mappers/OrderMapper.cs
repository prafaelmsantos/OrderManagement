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
                TotalQuantity = order.ProductsOrders.Select(x => x.TotalQuantity).Sum(),
                TotalPrice = order.ProductsOrders.Select(x => x.TotalPrice).Sum(),
                ProductsOrders = [.. order.ProductsOrders.Select(productOrder => new ProductOrderDTO()
                {
                    OrderId = productOrder.OrderId,
                    ProductId = productOrder.ProductId,
                   //Product = new ProductDTO(){
                   //    Id = productOrder.Product.Id,
                   //    Reference = productOrder.Product.Reference,
                   //    Description = productOrder.Product.Description,
                   //    UnitPrice = productOrder.Product.UnitPrice,
                   //    CreatedDate = productOrder.Product.CreatedAt
                   //},
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
                    TotalPrice = productOrder.TotalPrice
                })]
            };
        }

        public static OrderTableDTO ToOrderTableDTO(this Order order)
        {
            return new OrderTableDTO()
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                CustomerFullName = order.Customer.FullName,
                CustomerTaxIdentificationNumber = order.Customer.TaxIdentificationNumber,
                Status = order.Status,
                CreatedDate = order.CreatedAt,
                TotalQuantity = order.ProductsOrders.Select(x => x.TotalQuantity).Sum(),
                TotalPrice = order.ProductsOrders.Select(x => x.TotalPrice).Sum()
            };
        }
    }
}
