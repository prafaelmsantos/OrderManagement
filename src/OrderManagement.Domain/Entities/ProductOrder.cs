namespace OrderManagement.Domain.Entities
{
    public class ProductOrder : BaseEntity
    {
        public long ProductId { get; private set; }
        public virtual Product Product { get; private set; } = null!;

        public long OrderId { get; private set; }
        public virtual Order Order { get; private set; } = null!;

        public string? Color { get; private set; }
        public double UnitPrice { get; private set; }

        public int ZeroMonths { get; private set; }
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
            int zeroMonths,
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
            Validator.New()
                .When(productId <= 0, "O id do produto é inválido.")
                .When(unitPrice <= 0, "O preço unitário é inválido.")
                .When(zeroMonths < 0, "A quantidade de 0 meses não pode ser menor que 0.")
                .When(oneMonth < 0, "A quantidade de 1 mês não pode ser menor que 0.")
                .When(threeMonths < 0, "A quantidade de 3 meses não pode ser menor que 0.")
                .When(sixMonths < 0, "A quantidade de 6 meses não pode ser menor que 0.")
                .When(twelveMonths < 0, "A quantidade de 12 meses não pode ser menor que 0.")
                .When(eighteenMonths < 0, "A quantidade de 18 meses não pode ser menor que 0.")
                .When(twentyFourMonths < 0, "A quantidade de 24 meses não pode ser menor que 0.")
                .When(thirtySixMonths < 0, "A quantidade de 36 meses não pode ser menor que 0.")
                .When(oneYear < 0, "A quantidade de 1 ano não pode ser menor que 0.")
                .When(twoYears < 0, "A quantidade de 2 anos não pode ser menor que 0.")
                .When(threeYears < 0, "A quantidade de 3 anos não pode ser menor que 0.")
                .When(fourYears < 0, "A quantidade de 4 anos não pode ser menor que 0.")
                .When(sixYears < 0, "A quantidade de 6 anos não pode ser menor que 0.")
                .When(eightYears < 0, "A quantidade de 8 anos não pode ser menor que 0.")
                .When(tenYears < 0, "A quantidade de 10 anos não pode ser menor que 0.")
                .When(twelveYears < 0, "A quantidade de 12 anos não pode ser menor que 0.")
                .TriggerBadRequestExceptionIfExist();

            ProductId = productId;
            Color = color;
            UnitPrice = unitPrice;

            ZeroMonths = zeroMonths;
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
            long id,
            long productId,
            long orderId,
            string? color,
            double unitPrice,
            int zeroMonths = 0,
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
            Validator.New()
                .When(id <= 0, "O id do registo produto-pedido é inválido.")
                .When(productId <= 0, "O id do produto é inválido.")
                .When(orderId <= 0, "O id do pedido é inválido.")
                .When(unitPrice <= 0, "O preço unitário é inválido.")
                .When(zeroMonths < 0, "A quantidade de 0 meses não pode ser menor que 0.")
                .When(oneMonth < 0, "A quantidade de 1 mês não pode ser menor que 0.")
                .When(threeMonths < 0, "A quantidade de 3 meses não pode ser menor que 0.")
                .When(sixMonths < 0, "A quantidade de 6 meses não pode ser menor que 0.")
                .When(twelveMonths < 0, "A quantidade de 12 meses não pode ser menor que 0.")
                .When(eighteenMonths < 0, "A quantidade de 18 meses não pode ser menor que 0.")
                .When(twentyFourMonths < 0, "A quantidade de 24 meses não pode ser menor que 0.")
                .When(thirtySixMonths < 0, "A quantidade de 36 meses não pode ser menor que 0.")
                .When(oneYear < 0, "A quantidade de 1 ano não pode ser menor que 0.")
                .When(twoYears < 0, "A quantidade de 2 anos não pode ser menor que 0.")
                .When(threeYears < 0, "A quantidade de 3 anos não pode ser menor que 0.")
                .When(fourYears < 0, "A quantidade de 4 anos não pode ser menor que 0.")
                .When(sixYears < 0, "A quantidade de 6 anos não pode ser menor que 0.")
                .When(eightYears < 0, "A quantidade de 8 anos não pode ser menor que 0.")
                .When(tenYears < 0, "A quantidade de 10 anos não pode ser menor que 0.")
                .When(twelveYears < 0, "A quantidade de 12 anos não pode ser menor que 0.")
                .TriggerBadRequestExceptionIfExist();

            Id = id;
            ProductId = productId;
            OrderId = orderId;
            Color = color;
            UnitPrice = unitPrice;

            ZeroMonths = zeroMonths;
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
            TotalQuantity = ZeroMonths + OneMonth + ThreeMonths + SixMonths + TwelveMonths +
                            EighteenMonths + TwentyFourMonths + ThirtySixMonths +
                            OneYear + TwoYears + ThreeYears + FourYears +
                            SixYears + EightYears + TenYears + TwelveYears;

            TotalPrice = TotalQuantity * UnitPrice;
        }
    }
}
