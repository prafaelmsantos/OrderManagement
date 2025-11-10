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
                .OrderByDescending(x => x.CreatedAt)
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

            Order order = new(orderDTO.Status, orderDTO.CustomerId);

            order.SetProductsOrders(productsOrders);

            order = await _orderRepository.AddAsync(order);

            return order.ToOrderDTO();
        }


        public async Task<OrderDTO> UpdateOrderAsync(OrderDTO orderDTO)
        {
            Order order = await GetOrderAsync(orderDTO.Id);

            List<ProductOrder> productsOrders = await GetProductsAsync(orderDTO.ProductsOrders);

            order.Update(orderDTO.Status, orderDTO.CustomerId);

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

            var productOrderDTOMap = productOrderDTOs.ToDictionary(x => x.ProductId, x => x);

            List<ProductOrder> productOrders = [.. products.Select(product => new ProductOrder(
                product.Id,
                productOrderDTOMap[product.Id].Color,
                product.UnitPrice,
                productOrderDTOMap[product.Id].OneMonth,
                productOrderDTOMap[product.Id].ThreeMonths,
                productOrderDTOMap[product.Id].SixMonths,
                productOrderDTOMap[product.Id].TwelveMonths,
                productOrderDTOMap[product.Id].EighteenMonths,
                productOrderDTOMap[product.Id].TwentyFourMonths,
                productOrderDTOMap[product.Id].ThirtySixMonths,
                productOrderDTOMap[product.Id].OneYear,
                productOrderDTOMap[product.Id].TwoYears,
                productOrderDTOMap[product.Id].ThreeYears,
                productOrderDTOMap[product.Id].FourYears,
                productOrderDTOMap[product.Id].SixYears,
                productOrderDTOMap[product.Id].EightYears,
                productOrderDTOMap[product.Id].TenYears,
                productOrderDTOMap[product.Id].TwelveYears))];

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
