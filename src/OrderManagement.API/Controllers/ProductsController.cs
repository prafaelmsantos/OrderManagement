namespace OrderManagement.API.Controllers
{
    [ApiVersion("1.0", Deprecated = false)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Properties
        private readonly IProductService _productService;
        #endregion

        #region Constructors
        public ProductsController(IProductService productService)
        {
            _productService = productService;
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
        [HttpGet("sales/{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetSalesByIdAsync([FromRoute] long id)
        {
            Validator.New()
                .When(id <= 0, "O Id do produto é invalido.")
                .TriggerBadRequestExceptionIfExist();

            ProductReportDTO productSalesBySize = await _productService.GetProductSalesByIdAsync(id);

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
        [HttpPost("Delete")]
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
