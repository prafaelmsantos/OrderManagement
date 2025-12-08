namespace OrderManagement.Application.Mappers
{
    public static class ProductMapper
    {
        public static ProductDTO ToProductDTO(this Product product)
        {
            if (product is null)
            {
                return null!;
            }

            return new ProductDTO
            {
                Id = product.Id,
                Reference = product.Reference,
                Description = product.Description,
                UnitPrice = Math.Round(product.UnitPrice, 2),
                CreatedDate = product.CreatedDate
            };
        }

        public static ProductTableDTO ToProductTableDTO(this Product product)
        {
            return new ProductTableDTO
            {
                Id = product.Id,
                Reference = product.Reference,
                Description = product.Description,
                UnitPrice = Math.Round(product.UnitPrice, 2).ToString("F2"),
                TotalOrders = product.ProductsOrders.Select(x => x.TotalQuantity).Sum(),
                CreatedDate = product.CreatedDate.ToString("dd-MM-yyyy HH:mm:ss")
            };
        }
    }
}
