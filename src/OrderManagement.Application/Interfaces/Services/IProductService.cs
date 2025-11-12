namespace OrderManagement.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<ProductTableDTO>> GetAllProductsTableAsync();
        Task<List<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(long productId);
        Task<ProductDTO> AddProductAsync(ProductDTO productDTO);
        Task<ProductDTO> UpdateProductAsync(ProductDTO productDTO);
        Task<List<BaseResponseDTO>> DeleteProductsAsync(List<long> productsIds);
    }
}
