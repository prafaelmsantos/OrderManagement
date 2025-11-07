namespace OrderManagement.Application.Mappers
{
    public static class OrderMapper
    {
        public static OrderDTO ToOrderDTO(this Order order)
        {
            List<ProductOrderDTO> productOrderDTOs = [.. order.ProductsOrders.Select(p => p.ToProductOrderDTO())];

            return new OrderDTO
            {
                Id = order.Id,
                Status = order.Status,
                CreatedAt = order.CreatedAt,
                CustomerId = order.CustomerId,
                Customer = order.Customer.ToCustomerDTO(),
                QuantityTotal = productOrderDTOs.Select(x => x.QuantityTotal).Sum(),
                PriceTotal = productOrderDTOs.Select(x => x.PriceTotal).Sum(),
                ProductsOrders = productOrderDTOs
            };
        }
    }
}
