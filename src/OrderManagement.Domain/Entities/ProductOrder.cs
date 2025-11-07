namespace OrderManagement.Domain.Entities
{
    public class ProductOrder
    {
        public long ProductId { get; private set; }
        public virtual Product Product { get; private set; } = null!;

        public long OrderId { get; private set; }
        public virtual Order Order { get; private set; } = null!;

        public string? Color { get; private set; }
        public double UnitPrice { get; private set; }

        public int OneMonth { get; private set; }
        public int ThreeMonths { get; private set; }
        public int SixMonths { get; private set; }
        public int TwelveMonths { get; private set; }
        public int EighteenMonths { get; private set; }
        public int TwentyFourMonths { get; private set; }
        public int ThirtySixMonths { get; private set; }

        public int OneYear { get; private set; }
        public int TwoYears { get; private set; }
        public int ThreeYears { get; private set; }
        public int FourYears { get; private set; }
        public int SixYears { get; private set; }
        public int EightYears { get; private set; }
        public int TenYears { get; private set; }
        public int TwelveYears { get; private set; }

        public int TotalQuantity { get; set; }
        public double TotalPrice { get; set; }

        protected ProductOrder() { }

        public ProductOrder(
            long productId,
            string? color,
            double unitPrice,
            int oneMonth,
            int threeMonths,
            int sixMonths,
            int twelveMonths,
            int eighteenMonths,
            int twentyFourMonths,
            int thirtySixMonths,
            int oneYear,
            int twoYears,
            int threeYears,
            int fourYears,
            int sixYears,
            int eightYears,
            int tenYears,
            int twelveYears)
        {
            ProductId = productId;
            Color = color;
            UnitPrice = unitPrice;

            OneMonth = oneMonth;
            ThreeMonths = threeMonths;
            SixMonths = sixMonths;
            TwelveMonths = twelveMonths;
            EighteenMonths = eighteenMonths;
            TwentyFourMonths = twentyFourMonths;
            ThirtySixMonths = thirtySixMonths;

            OneYear = oneYear;
            TwoYears = twoYears;
            ThreeYears = threeYears;
            FourYears = fourYears;
            SixYears = sixYears;
            EightYears = eightYears;
            TenYears = tenYears;
            TwelveYears = twelveYears;

            UpdateTotals();
        }

        public ProductOrder(
            long productId,
            long orderId,
            string? color,
            double unitPrice,
            int oneMonth = 0,
            int threeMonths = 0,
            int sixMonths = 0,
            int twelveMonths = 0,
            int eighteenMonths = 0,
            int twentyFourMonths = 0,
            int thirtySixMonths = 0,
            int oneYear = 0,
            int twoYears = 0,
            int threeYears = 0,
            int fourYears = 0,
            int sixYears = 0,
            int eightYears = 0,
            int tenYears = 0,
            int twelveYears = 0)
        {
            ProductId = productId;
            OrderId = orderId;
            Color = color;
            UnitPrice = unitPrice;

            OneMonth = oneMonth;
            ThreeMonths = threeMonths;
            SixMonths = sixMonths;
            TwelveMonths = twelveMonths;
            EighteenMonths = eighteenMonths;
            TwentyFourMonths = twentyFourMonths;
            ThirtySixMonths = thirtySixMonths;

            OneYear = oneYear;
            TwoYears = twoYears;
            ThreeYears = threeYears;
            FourYears = fourYears;
            SixYears = sixYears;
            EightYears = eightYears;
            TenYears = tenYears;
            TwelveYears = twelveYears;

            UpdateTotals();
        }

        private void UpdateTotals()
        {
            TotalQuantity = OneMonth + ThreeMonths + SixMonths + TwelveMonths +
                            EighteenMonths + TwentyFourMonths + ThirtySixMonths +
                            OneYear + TwoYears + ThreeYears + FourYears +
                            SixYears + EightYears + TenYears + TwelveYears;

            TotalPrice = TotalQuantity * UnitPrice;
        }
    }
}
