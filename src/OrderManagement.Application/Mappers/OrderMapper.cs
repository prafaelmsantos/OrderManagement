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
                Customer = order.Customer.ToCustomerDTO(),
                Observations = order.Observations,
                PaymentMethod = order.PaymentMethod,
                CreatedDate = order.CreatedDate,
                TotalQuantity = order.ProductsOrders.Select(x => x.TotalQuantity).Sum(),
                TotalPrice = order.ProductsOrders.Select(x => x.TotalPrice).Sum(),
                ProductsOrders = [.. order.ProductsOrders.Select(productOrder => new ProductOrderDTO()
                {
                    Id = productOrder.Id,
                    OrderId = productOrder.OrderId,
                    ProductId = productOrder.ProductId,
                    Product = productOrder.Product.ToProductDTO(),
                    UnitPrice = productOrder.UnitPrice,
                    Color = productOrder.Color,

                    ZeroMonths = productOrder.ZeroMonths,
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
                CreatedDate = order.CreatedDate.ToString("dd-MM-yyyy HH:mm:ss"),
                TotalQuantity = order.ProductsOrders.Select(x => x.TotalQuantity).Sum(),
                TotalPrice = order.ProductsOrders.Select(x => x.TotalPrice).Sum()
            };
        }
    }
}
