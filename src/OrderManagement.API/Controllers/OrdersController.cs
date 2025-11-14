using OrderManagement.API.Pdf;
using QuestPDF.Fluent;

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
            List<OrderTableDTO> orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }
        /// </summary>
        [HttpGet("pdf")]
        public async Task<IActionResult> GetPdf()
        {
            var model = await _orderService.GetOrderByIdAsync(4);
            // Retornar PDF para o cliente
            var document = new InvoiceDocument(model); // ou InvoiceDocument se estiveres a usar o antigo

            // Gerar PDF em memória
            byte[] pdfBytes;
            using (var ms = new MemoryStream())
            {
                document.GeneratePdf(ms);
                pdfBytes = ms.ToArray();
            }

            // Retornar PDF para o cliente
            return File(pdfBytes, "application/pdf", $"nota_encomenda_{model.Id}.pdf");
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
            Validator.New()
                .When(id <= 0, "O Id da encomenda é invalido.")
                .TriggerBadRequestExceptionIfExist();

            OrderDTO orderDTO = await _orderService.GetOrderByIdAsync(id);

            return Ok(orderDTO);
        }

        /// <summary>
        /// Get Order
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("customer/{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllByCustomerIdAsync([FromRoute] long id)
        {
            Validator.New()
                .When(id <= 0, "O Id da encomenda é invalido.")
                .TriggerBadRequestExceptionIfExist();

            List<OrderTableDTO> orders = await _orderService.GetAllByCustomerIdAsync(id);

            return Ok(orders);
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
            Validator.New()
                .When(id <= 0, "O Id da encomenda é invalido.")
                .TriggerBadRequestExceptionIfExist();

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
