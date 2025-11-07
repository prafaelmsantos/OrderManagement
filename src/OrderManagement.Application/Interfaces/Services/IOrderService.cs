namespace OrderManagement.Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task<List<OrderDTO>> GetAllOrdersAsync();
        Task<OrderDTO> GetOrderByIdAsync(long orderId);
        Task<OrderDTO> AddOrderAsync(OrderDTO orderDTO);
        Task<OrderDTO> UpdateOrderAsync(OrderDTO orderDTO);
        Task<List<BaseResponseDTO>> DeleteOrdersAsync(List<long> ordersIds);
    }
}
