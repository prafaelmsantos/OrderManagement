namespace OrderManagement.Domain.Extensions
{
    public static class ProductSizeExtensions
    {
        public static string ToProductSizeString(this ProductSize size)
        {
            return size switch
            {
                ProductSize.ZeroMonths => "0 M",
                ProductSize.OneMonth => "1 M",
                ProductSize.ThreeMonths => "3 M",
                ProductSize.SixMonths => "6 M",
                ProductSize.TwelveMonths => "12 M",
                ProductSize.EighteenMonths => "18 M",
                ProductSize.TwentyFourMonths => "24 M",
                ProductSize.ThirtySixMonths => "36 M",
                ProductSize.OneYear => "1 A",
                ProductSize.TwoYears => "2 A",
                ProductSize.ThreeYears => "3 A",
                ProductSize.FourYears => "4 A",
                ProductSize.SixYears => "6 A",
                ProductSize.EightYears => "8 A",
                ProductSize.TenYears => "10 A",
                ProductSize.TwelveYears => "12 A",
                _ => size.ToString()
            };
        }
    }
}
