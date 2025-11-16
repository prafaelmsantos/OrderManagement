using OrderManagement.Application.Interfaces.Repositories;
using OrderManagement.Domain.Entities;

namespace OrderManagement.API.Controllers
{
    [ApiVersion("1.0", Deprecated = false)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Properties
        private readonly IProductService _productService;
        private readonly IProductRepository _productRepository;
        #endregion

        #region Constructors
        public ProductsController(IProductService productService, IProductRepository productRepository)
        {
            _productService = productService;
            _productRepository = productRepository;
        }
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Get All Products
        /// </summary>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAsync()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        /// <summary>
        /// Get All Products
        /// </summary>
        [HttpGet("table")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetTableAsync()
        {
            var products = await _productService.GetAllProductsTableAsync();
            return Ok(products);
        }

        // <summary>
        /// Get All Products
        /// </summary>
        [HttpGet("newtable")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetTableAsync([FromQuery] PageParams pageParams)
        {
            var query = _productRepository.GetAllQueryable();

            // --- Aplicar filtro manual ---
            if (!string.IsNullOrWhiteSpace(pageParams.Filter))
            {
                var filterLower = pageParams.Filter.ToLower();
                query = query.Where(p =>
                    p.Reference.ToLower().Contains(filterLower)
                );
            }

            // --- Aplicar sort manual ---
            if (!string.IsNullOrWhiteSpace(pageParams.Sort))
            {
                // Exemplo: "Nome asc" ou "Preco desc"
                var parts = pageParams.Sort.Split(' ');
                var field = parts[0];
                var direction = parts.Length > 1 ? parts[1].ToLower() : "asc";

                query = field switch
                {
                    "reference" => direction == "asc" ? query.OrderBy(p => p.Reference) : query.OrderByDescending(p => p.Reference),
                    "price" => direction == "asc" ? query.OrderBy(p => p.UnitPrice) : query.OrderByDescending(p => p.UnitPrice),
                    "id" => direction == "asc" ? query.OrderBy(p => p.Id) : query.OrderByDescending(p => p.Id),
                    _ => query.OrderByDescending(p => p.Id)
                };
            }
            else
            {
                query = query.OrderBy(p => p.Id); // sort padrão
            }

            // --- Paginar ---
            var itemsPaged = await PageList<Product>.CreateAsync(
                query,
                pageParams.PageNumber,
                pageParams.PageSize
            );

            // --- Montar DTO para frontend ---
            var result = new PagedResult<Product>
            {
                Items = itemsPaged.ToList(),
                CurrentPage = itemsPaged.CurrentPage,
                TotalPages = itemsPaged.TotalPages,
                PageSize = itemsPaged.PageSize,
                TotalCount = itemsPaged.TotalCount
            };

            return Ok(result);
        }


        /// <summary>
        /// Get Product
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            Validator.New()
                .When(id <= 0, "O Id do produto é invalido.")
                .TriggerBadRequestExceptionIfExist();

            var productDTO = await _productService.GetProductByIdAsync(id);

            return Ok(productDTO);
        }

        /// <summary>
        /// Get Product
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("report/{id}")]
        [Consumes("application/json")]
        [Produces("application/pdf")]
        public async Task<IActionResult> GetProducReportByIdAsync([FromRoute] long id)
        {
            Validator.New()
                .When(id <= 0, "O Id do produto é invalido.")
                .TriggerBadRequestExceptionIfExist();

            ProductReportDTO productSalesBySize = await _productService.GetProducReportByIdAsync(id);

            var document = new ProductReportsDocument(productSalesBySize);

            // Gerar PDF em memória
            byte[] pdfBytes;
            using (var ms = new MemoryStream())
            {
                document.GeneratePdf(ms);
                pdfBytes = ms.ToArray();
            }
            return File(pdfBytes, "application/pdf", $"report_Product_{productSalesBySize.Product.Reference.Trim()}.pdf");
        }

        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="productDTO"></param>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> PostAsync([FromBody] ProductDTO productDTO)
        {
            productDTO.Id = 0;
            productDTO = await _productService.AddProductAsync(productDTO);
            return Ok(productDTO);
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productDTO"></param>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> PutAsync([FromRoute] long id, [FromBody] ProductDTO productDTO)
        {
            Validator.New()
                .When(id <= 0, "O Id do produto é invalido.")
                .TriggerBadRequestExceptionIfExist();

            productDTO.Id = id;
            productDTO = await _productService.UpdateProductAsync(productDTO);
            return Ok(productDTO);
        }

        //// <summary>
        /// Delete Products
        /// </summary>
        /// <param name="productsIds"></param>
        [HttpPost("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteAsync([FromBody] List<long> productsIds)
        {
            var baseResponses =
                await _productService.DeleteProductsAsync(productsIds);

            return Ok(baseResponses);
        }
        #endregion
    }
}
