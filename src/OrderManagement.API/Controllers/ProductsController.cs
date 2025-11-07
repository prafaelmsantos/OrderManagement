namespace ProductManagement.API.Controllers
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
            List<ProductDTO> products = await _productService.GetAllProductsAsync();
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
            ProductDTO productDTO = await _productService.GetProductByIdAsync(id);

            return Ok(productDTO);
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
            List<BaseResponseDTO> baseResponses =
                await _productService.DeleteProductsAsync(productsIds);

            return Ok(baseResponses);
        }
        #endregion
    }
}
