namespace OrderManagement.Application.Mappers
{
    public static class ProductOrderMapper
    {
        public static ProductOrderDTO ToProductOrderDTO(this ProductOrder productOrder)
        {
            int totalQuantity = new[]
            {
                productOrder.OneMonth,
                productOrder.ThreeMonths,
                productOrder.SixMonths,
                productOrder.TwelveMonths,
                productOrder.EighteenMonths,
                productOrder.TwentyFourMonths,
                productOrder.ThirtySixMonths,
                productOrder.OneYear,
                productOrder.TwoYears,
                productOrder.ThreeYears,
                productOrder.FourYears,
                productOrder.SixYears,
                productOrder.EightYears,
                productOrder.TenYears,
                productOrder.TwelveYears
            }.Sum();

            return new ProductOrderDTO
            {
                ProductId = productOrder.ProductId,
                Product = productOrder.Product.ToProductDTO(),
                OrderId = productOrder.OrderId,
                Order = productOrder.Order.ToOrderDTO(),
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

                QuantityTotal = totalQuantity,
                PriceTotal = totalQuantity * productOrder.UnitPrice
            };
        }
    }
}
