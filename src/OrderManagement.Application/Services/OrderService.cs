namespace OrderManagement.Application.Services
{
    public sealed class OrderService : IOrderService
    {
        #region Private variables
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        #endregion

        #region Constructors
        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }
        #endregion

        #region Public methods
        public async Task<List<OrderTableDTO>> GetAllOrdersAsync()
        {
            List<Order> orders = await _orderRepository
                .GetAllQueryable()
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync();

            return [.. orders.Select(x => x.ToOrderTableDTO())];
        }

        public async Task<OrderDTO> GetOrderByIdAsync(long orderId)
        {
            Order? order = await _orderRepository
                .GetAllQueryable()
                .AsNoTracking()
                .Where(x => x.Id == orderId)
                .Include(x => x.ProductsOrders)
                .ThenInclude(x => x.Product)
                .Include(x => x.Customer)
                .FirstOrDefaultAsync();

            Validator.New()
                .When(order is null, "Encomenda não encontrada.")
                .TriggerBadRequestExceptionIfExist();

            return order!.ToOrderDTO();
        }

        public async Task<List<OrderTableDTO>> GetAllByCustomerIdAsync(long customerId)
        {
            List<Order> orders = await _orderRepository
                .GetAllQueryable()
                .AsNoTracking()
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();

            return [.. orders.Select(x => x.ToOrderTableDTO())];
        }

        public async Task<OrderDTO> AddOrderAsync(OrderDTO orderDTO)
        {
            Order order = new(
                observations: string.IsNullOrWhiteSpace(orderDTO.Observations) ? null : orderDTO.Observations,
                customerId: orderDTO.CustomerId
            );

            List<ProductOrder> productsOrders = GetProducts(orderDTO.ProductsOrders);

            order.SetProductsOrders(productsOrders);

            order = await _orderRepository.AddAsync(order);

            return order.ToOrderDTO();
        }


        public async Task<OrderDTO> UpdateOrderAsync(OrderDTO orderDTO)
        {
            Order? order = await _orderRepository.GetByIdAsync(orderDTO.Id);

            Validator.New()
                .When(order is null, "Encomenda não encontrada.")
                .TriggerBadRequestExceptionIfExist();

            order!.Update(
                observations: string.IsNullOrWhiteSpace(orderDTO.Observations) ? null : orderDTO.Observations,
                customerId: orderDTO.CustomerId
            );

            List<ProductOrder> productsOrders = GetProducts(orderDTO.ProductsOrders);

            order.SetProductsOrders(productsOrders);

            order = await _orderRepository.UpdateAsync(order);

            return order.ToOrderDTO();
        }

        public async Task<List<BaseResponseDTO>> DeleteOrdersAsync(List<long> ordersIds)
        {
            return await DeleteAsync(ordersIds);
        }
        #endregion

        #region Private methods

        private static List<ProductOrder> GetProducts(List<ProductOrderDTO> productOrderDTOs)
        {
            if (productOrderDTOs.Count == 0)
            {
                return [];
            }

            List<ProductOrder> productOrders = [.. productOrderDTOs.Select(productOrderDTO => new ProductOrder(
                productOrderDTO.ProductId,
                string.IsNullOrWhiteSpace(productOrderDTO.Color) ? null : productOrderDTO.Color,
                productOrderDTO.UnitPrice,
                productOrderDTO.ZeroMonths,
                productOrderDTO.OneMonth,
                productOrderDTO.ThreeMonths,
                productOrderDTO.SixMonths,
                productOrderDTO.NineMonths,
                productOrderDTO.TwelveMonths,
                productOrderDTO.EighteenMonths,
                productOrderDTO.TwentyFourMonths,
                productOrderDTO.OneYear,
                productOrderDTO.TwoYears,
                productOrderDTO.ThreeYears,
                productOrderDTO.FourYears,
                productOrderDTO.SixYears,
                productOrderDTO.EightYears,
                productOrderDTO.TenYears,
                productOrderDTO.TwelveYears))];

            return productOrders;
        }

        private async Task<List<BaseResponseDTO>> DeleteAsync(List<long> ordersIds)
        {
            List<BaseResponseDTO> internalBaseResponseDTOs = [];

            foreach (long orderId in ordersIds)
            {
                BaseResponseDTO internalBaseResponseDTO = new() { Id = orderId, Success = false };
                try
                {
                    Order? order = await _orderRepository.GetByIdAsync(orderId);

                    if (order is not null)
                    {
                        await _orderRepository.RemoveAsync(order);
                        internalBaseResponseDTO.Success = true;
                    }
                    else
                    {
                        internalBaseResponseDTO.Message = "Encomenda não encontrada.";
                    }
                }
                catch (Exception)
                {
                    internalBaseResponseDTO.Message = "Erro ao tentar apagar a encomenda.";
                }

                internalBaseResponseDTOs.Add(internalBaseResponseDTO);
            }

            return internalBaseResponseDTOs;
        }
        #endregion
    }
}
