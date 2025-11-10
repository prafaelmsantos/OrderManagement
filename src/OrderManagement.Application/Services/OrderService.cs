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
                .OrderByDescending(x => x.CreatedDate)
                .AsNoTracking()
                .ToListAsync();

            return [.. orders.Select(x => x.ToOrderTableDTO())];
        }

        public async Task<OrderDTO> GetOrderByIdAsync(long orderId)
        {
            Order order = await GetOrderAsync(orderId);

            return order.ToOrderDTO();
        }

        public async Task<OrderDTO> AddOrderAsync(OrderDTO orderDTO)
        {
            List<ProductOrder> productsOrders = await GetProductsAsync(orderDTO.ProductsOrders);

            Order order = new(orderDTO.Status, orderDTO.Observations, orderDTO.PaymentMethod, orderDTO.CustomerId);

            order.SetProductsOrders(productsOrders);

            order = await _orderRepository.AddAsync(order);

            return order.ToOrderDTO();
        }


        public async Task<OrderDTO> UpdateOrderAsync(OrderDTO orderDTO)
        {
            Order order = await GetOrderAsync(orderDTO.Id);

            List<ProductOrder> productsOrders = await GetProductsAsync(orderDTO.ProductsOrders);

            order.Update(orderDTO.Status, orderDTO.Observations, orderDTO.PaymentMethod, orderDTO.CustomerId);

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
        private async Task<Order> GetOrderAsync(long id)
        {
            Order? order = await _orderRepository.GetByIdAsync(id) ??
                throw new Exception("Erro ao tentar encontrar a encomenda por id.");

            return order;
        }

        private async Task<List<ProductOrder>> GetProductsAsync(List<ProductOrderDTO> productOrderDTOs)
        {
            if (productOrderDTOs.Count == 0)
            {
                return [];
            }

            List<long> productIds = [.. productOrderDTOs.Select(x => x.ProductId)];

            List<Product> products = await _productRepository
                .GetAllQueryable()
                .Where(x => productIds.Contains(x.Id))
                .ToListAsync();

            //var productOrderDTOMap = productOrderDTOs.ToDictionary(x => x.ProductId + x.Color, x => x);

            List<ProductOrder> productOrders = [.. productOrderDTOs.Select(productOrderDTO => new ProductOrder(
                productOrderDTO.ProductId,
                productOrderDTO.Color,
                productOrderDTO.UnitPrice,
                productOrderDTO.ZeroMonths,
                productOrderDTO.OneMonth,
                productOrderDTO.ThreeMonths,
                productOrderDTO.SixMonths,
                productOrderDTO.TwelveMonths,
                productOrderDTO.EighteenMonths,
                productOrderDTO.TwentyFourMonths,
                productOrderDTO.ThirtySixMonths,
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
