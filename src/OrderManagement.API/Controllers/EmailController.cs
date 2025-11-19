namespace OrderManagement.API.Controllers
{
    [ApiVersion("1.0", Deprecated = false)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        #region Properties
        private readonly IEmailService _emailService;
        #endregion

        #region Constructors
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Get All Customers
        /// </summary>
        [HttpPost("email")]
        public async Task<IActionResult> SendEmailAsync()
        {
            await _emailService.BackupAndSendEmailAsync();
            return Ok("Enviado!");
        }
        #endregion
    }
}
