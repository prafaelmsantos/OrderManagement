namespace OrderManagement.Application.Mappers
{
    public static class ProductMapper
    {
        public static ProductDTO ToProductDTO(this Product product)
        {
            return new ProductDTO
            {
                Id = product.Id,
                Reference = product.Reference,
                Description = product.Description,
                UnitPrice = product.UnitPrice,
                CreatedAt = product.CreatedAt,
                ProductsOrders = [.. product.ProductsOrders.Select(o => o.ToProductOrderDTO())]
            };
        }
    }
}
