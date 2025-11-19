
using System.IO.Compression;
using MailKit.Net.Smtp;
using MimeKit;

namespace OrderManagement.Application.Services
{
    public class EmailService : IEmailService
    {
        #region Private variables


        #endregion

        #region Constructors

        public EmailService()
        {
        }

        #endregion

        #region Public methods

        public async Task BackupAndSendEmailAsync()
        {
            // 1️⃣ Criar ZIP do SQLite
            string dbFolder = Path.Combine(AppContext.BaseDirectory, "SQLite");
            string zipFolder = Path.Combine(AppContext.BaseDirectory, "SQLiteZip");

            string zipFileName = $"backup_{DateTime.Now:yyyyMMdd_HHmmss}.zip";
            string zipPath = Path.Combine(zipFolder, zipFileName);

            // Arquivos SQLite típicos: .db, -wal, -shm
            string[] filesToBackup = Directory.GetFiles(dbFolder, "*.db*");

            using (var zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                foreach (var file in filesToBackup)
                {
                    zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);
                }
            }

            // 2️⃣ Criar e-mail
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sistema de Backup", "backup@sistema.com"));
            message.To.Add(new MailboxAddress("Rafael", "prafaelmsantos@gmail.com"));
            message.Subject = "backup";

            var builder = new BodyBuilder();

            // Anexo ZIP
            builder.Attachments.Add(zipPath);

            message.Body = builder.ToMessageBody();

            using var client = new SmtpClient();
            client.ServerCertificateValidationCallback = (s, c, h, e) => true;

            await client.ConnectAsync("in.mailjet.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            await client.AuthenticateAsync("MAILJET_API_KEY", "MAILJET_SECRET_KEY");
            await client.SendAsync(message);
            await client.DisconnectAsync(true);

            // 4️⃣ Apagar o ZIP após envio
            if (File.Exists(zipPath))
            {
                File.Delete(zipPath);
            }

        }
        #endregion

        #region Private methods




        #endregion
    }
}
