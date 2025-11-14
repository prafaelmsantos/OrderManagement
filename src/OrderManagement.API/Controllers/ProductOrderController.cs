namespace OrderManagement.API.Controllers
{
    [ApiVersion("1.0", Deprecated = false)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductOrderController : ControllerBase
    {
        #region Properties
        private readonly IProductOrderService _productOrderService;
        #endregion

        #region Constructors
        public ProductOrderController(IProductOrderService productOrderService)
        {
            _productOrderService = productOrderService;
        }
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Get Product
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("sales/{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetProductSalesAsync([FromRoute] long id)
        {
            Validator.New()
                .When(id <= 0, "O Id do produto é invalido.")
                .TriggerBadRequestExceptionIfExist();

            var products = await _productOrderService.GetProductSalesByProductIdAsync(id);
            return Ok(products);
        }
        #endregion
    }
}

