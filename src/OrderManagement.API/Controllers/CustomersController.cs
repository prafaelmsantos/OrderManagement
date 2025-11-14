namespace OrderManagement.API.Controllers
{
    [ApiVersion("1.0", Deprecated = false)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        #region Properties
        private readonly ICustomerService _customerService;
        #endregion

        #region Constructors
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Get All Customers
        /// </summary>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAsync()
        {
            List<CustomerDTO> customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("table")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetTableAsync()
        {
            List<CustomerTableDTO> customers = await _customerService.GetAllCustomersTableAsync();
            return Ok(customers);
        }

        /// <summary>
        /// Get Customer
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            Validator.New()
              .When(id <= 0, "O Id do cliente é invalido.")
              .TriggerBadRequestExceptionIfExist();

            var customerDTO = await _customerService.GetCustomerByIdAsync(id);

            return Ok(customerDTO);
        }

        /// <summary>
        /// Create Customer
        /// </summary>
        /// <param name="customerDTO"></param>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> PostAsync([FromBody] CustomerDTO customerDTO)
        {
            customerDTO.Id = 0;
            customerDTO = await _customerService.AddCustomerAsync(customerDTO);
            return Ok(customerDTO);
        }

        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customerDTO"></param>
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> PutAsync([FromRoute] long id, [FromBody] CustomerDTO customerDTO)
        {
            Validator.New()
                .When(id <= 0, "O Id do cliente é invalido.")
                .TriggerBadRequestExceptionIfExist();

            customerDTO.Id = id;
            customerDTO = await _customerService.UpdateCustomerAsync(customerDTO);
            return Ok(customerDTO);
        }

        //// <summary>
        /// Delete Customers
        /// </summary>
        /// <param name="customersIds"></param>
        [HttpPost("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteAsync([FromBody] List<long> customersIds)
        {
            var baseResponses =
                await _customerService.DeleteCustomersAsync(customersIds);

            return Ok(baseResponses);
        }
        #endregion
    }
}
