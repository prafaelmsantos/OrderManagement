namespace OrderManagement.API.Controllers
{
    [ApiVersion("1.0", Deprecated = false)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        #region Properties
        private readonly IOrderService _orderService;
        #endregion

        #region Constructors
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Get All Orders
        /// </summary>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAsync()
        {
            List<OrderDTO> orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }


        /// <summary>
        /// Get Order
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            OrderDTO orderDTO = await _orderService.GetOrderByIdAsync(id);

            return Ok(orderDTO);
        }


        /// <summary>
        /// Create Order
        /// </summary>
        /// <param name="orderDTO"></param>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> PostAsync([FromBody] OrderDTO orderDTO)
        {
            orderDTO.Id = 0;
            orderDTO = await _orderService.AddOrderAsync(orderDTO);
            return Ok(orderDTO);
        }

        /// <summary>
        /// Update Order
        /// </summary>
        /// <param name="id"></param>
        /// <param name="orderDTO"></param>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> PutAsync([FromRoute] long id, [FromBody] OrderDTO orderDTO)
        {
            orderDTO.Id = id;
            orderDTO = await _orderService.UpdateOrderAsync(orderDTO);
            return Ok(orderDTO);
        }

        //// <summary>
        /// Delete Orders
        /// </summary>
        /// <param name="ordersIds"></param>
        [HttpPost("Delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteAsync([FromBody] List<long> ordersIds)
        {
            List<BaseResponseDTO> baseResponses =
                await _orderService.DeleteOrdersAsync(ordersIds);

            return Ok(baseResponses);
        }
        #endregion
    }
}
