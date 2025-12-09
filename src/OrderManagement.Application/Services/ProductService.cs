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

        public async Task<ProductReportDTO> GetProducReportByIdAsync(long productId)
        {
            Product? product = await _productRepository
                .GetAllQueryable()
                .AsNoTracking()
                .Where(po => po.Id == productId)
                .FirstOrDefaultAsync();

            Validator.New()
                .When(product is null, "Produto não encontrado.")
                .TriggerBadRequestExceptionIfExist();

            List<ProductSize> allSizes = [.. Enum.GetValues<ProductSize>().Cast<ProductSize>()];

            List<ProductSalesBySizeDTO> productSalesBySizes = [.. product!.ProductsOrders
                .GroupBy(po => po.Color)
                .Select(g =>
                {
                    List<ProductSalesBySizeValuesDTO> productSalesBySizeValues = [.. allSizes.Select(sz =>
                    {
                        return new ProductSalesBySizeValuesDTO()
                        {
                            Size = sz,
                            TotalQuantity = g.Sum(po => GetQuantity(po, sz))
                        };
                    }).OrderBy(x => x.Size)];

                    return new ProductSalesBySizeDTO()
                    {
                        Color = g.Key,
                        TotalQuantity = productSalesBySizeValues.Sum(x=> x.TotalQuantity),
                        Values = productSalesBySizeValues
                    };
                })];

            ProductReportDTO productReportDTO = new()
            {
                ProductId = product.Id,
                Product = product.ToProductDTO(),
                TotalQuantity = productSalesBySizes.Sum(x => x.TotalQuantity),
                ProductSalesBySizes = productSalesBySizes,
            };

            return productReportDTO;
        }

        public async Task<ProductDTO> AddProductAsync(ProductDTO productDTO)
        {
            await ExistsAsync(productDTO);

            Product product = new(
                reference: productDTO.Reference,
                description: string.IsNullOrWhiteSpace(productDTO.Description) ? null : productDTO.Description,
                unitPrice: productDTO.UnitPrice
            );

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

            product!.Update(
                reference: productDTO.Reference,
                description: string.IsNullOrWhiteSpace(productDTO.Description) ? null : productDTO.Description,
                unitPrice: productDTO.UnitPrice
            );

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
                            internalBaseResponseDTO.Message = $"Produto {product.Reference} está presente em encomendas. Por favor apague as encomendas e tente novamente.";
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

        private static int GetQuantity(ProductOrder po, ProductSize size) => size switch
        {
            ProductSize.ZeroMonths => po.ZeroMonths,
            ProductSize.OneMonth => po.OneMonth,
            ProductSize.ThreeMonths => po.ThreeMonths,
            ProductSize.SixMonths => po.SixMonths,
            ProductSize.NineMonths => po.NineMonths,
            ProductSize.TwelveMonths => po.TwelveMonths,
            ProductSize.EighteenMonths => po.EighteenMonths,
            ProductSize.TwentyFourMonths => po.TwentyFourMonths,
            ProductSize.OneYear => po.OneYear,
            ProductSize.TwoYears => po.TwoYears,
            ProductSize.ThreeYears => po.ThreeYears,
            ProductSize.FourYears => po.FourYears,
            ProductSize.SixYears => po.SixYears,
            ProductSize.EightYears => po.EightYears,
            ProductSize.TenYears => po.TenYears,
            ProductSize.TwelveYears => po.TwelveYears,
            _ => 0
        };
        #endregion
    }
}
