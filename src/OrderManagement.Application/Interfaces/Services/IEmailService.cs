namespace OrderManagement.Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task BackupAndSendEmailAsync();
    }
}
