namespace OrderManagement.API.Controllers
{
    [ApiVersion("1.0", Deprecated = false)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductOrdersController : ControllerBase
    {
        #region Properties
        private readonly IProductOrderService _productOrderService;
        #endregion

        #region Constructors
        public ProductOrdersController(IProductOrderService productOrderService)
        {
            _productOrderService = productOrderService;
        }
        #endregion

        #region CRUD Methods

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

            var products = await _productOrderService.GetAllMetrics(id);
            return Ok(products);
        }

        /// <summary>
        /// Get Product
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("top/{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetByIdTopAsync([FromRoute] long id)
        {
            Validator.New()
                .When(id <= 0, "O Id do produto é invalido.")
                .TriggerBadRequestExceptionIfExist();

            var products = await _productOrderService.GetAllMetricsTop(id);
            return Ok(products);
        }
        #endregion
    }
}

