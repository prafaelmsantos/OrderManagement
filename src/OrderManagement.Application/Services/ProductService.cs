namespace OrderManagement.Application.Services
{
    public sealed class ProductService : IProductService
    {
        #region Private variables
        private readonly IProductRepository _productRepository;
        #endregion

        #region Constructors
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region Public methods
        public async Task<List<ProductTableDTO>> GetAllProductsTableAsync()
        {
            List<Product> products = await _productRepository
                .GetAllQueryable()
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync();

            return [.. products.Select(x => x.ToProductTableDTO())];
        }

        public async Task<List<ProductDTO>> GetAllProductsAsync()
        {
            List<Product> products = await _productRepository
                .GetAllQueryable()
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync();

            return [.. products.Select(x => x.ToProductDTO())];
        }

        public async Task<ProductDTO> GetProductByIdAsync(long productId)
        {
            Product? product = await _productRepository
                .GetAllQueryable()
                .AsNoTracking()
                .Where(x => x.Id == productId)
                .FirstOrDefaultAsync();

            Validator.New()
                .When(product is null, "Produto não encontrado.")
                .TriggerBadRequestExceptionIfExist();

            return product!.ToProductDTO();
        }

        public async Task<ProductDTO> AddProductAsync(ProductDTO productDTO)
        {
            await ExistsAsync(productDTO);

            Product product = new(productDTO.Reference, productDTO.Description, productDTO.UnitPrice);

            product = await _productRepository.AddAsync(product);

            return product.ToProductDTO();
        }

        public async Task<ProductDTO> UpdateProductAsync(ProductDTO productDTO)
        {
            Product? product = await _productRepository.GetByIdAsync(productDTO.Id);

            Validator.New()
               .When(product is null, "Produto não encontrado.")
               .TriggerBadRequestExceptionIfExist();

            await ExistsAsync(productDTO);

            product!.Update(productDTO.Reference, productDTO.Description, productDTO.UnitPrice);

            product = await _productRepository.UpdateAsync(product);

            return product.ToProductDTO();
        }

        public async Task<List<BaseResponseDTO>> DeleteProductsAsync(List<long> productsIds)
        {
            return await DeleteAsync(productsIds);
        }
        #endregion

        #region Private methods
        private async Task ExistsAsync(ProductDTO productDTO)
        {
            bool exists = await _productRepository
                .GetAllQueryable()
                .AsNoTracking()
                .AnyAsync(x => x.Id != productDTO.Id &&
                    x.Reference.Trim().ToLower() == productDTO.Reference.Trim().ToLower());

            Validator.New()
               .When(exists, "Produto com a mesma referência já existe.")
               .TriggerBadRequestExceptionIfExist();
        }

        private async Task<List<BaseResponseDTO>> DeleteAsync(List<long> productsIds)
        {
            List<BaseResponseDTO> internalBaseResponseDTOs = [];

            foreach (long productId in productsIds)
            {
                BaseResponseDTO internalBaseResponseDTO = new() { Id = productId, Success = false };
                try
                {
                    Product? product = await _productRepository.GetByIdAsync(productId);

                    if (product is not null)
                    {
                        if (product.ProductsOrders.Count != 0)
                        {
                            internalBaseResponseDTO.Message = $"Produto {product.Reference} contém encomendas.";
                        }
                        else
                        {
                            await _productRepository.RemoveAsync(product);
                            internalBaseResponseDTO.Success = true;
                        }
                    }
                    else
                    {
                        internalBaseResponseDTO.Message = "Produto não encontrado.";
                    }
                }
                catch (Exception)
                {
                    internalBaseResponseDTO.Message = "Erro ao tentar apagar o produto.";
                }

                internalBaseResponseDTOs.Add(internalBaseResponseDTO);
            }

            return internalBaseResponseDTOs;
        }
        #endregion
    }
}
