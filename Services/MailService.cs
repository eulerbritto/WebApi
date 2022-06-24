using WebApi.Entities;
using WebApi.Interfaces;

namespace WebApi.Services
{
    public class MailService: IMailService
    {
        public void Send(Lead lead)
        {
            //sendgrid
            string path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Personal)}\Email.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine($"Mail sent to {lead.Email} at {DateTime.UtcNow}.");
                    sw.WriteLine($"{lead.LastName}, {lead.FirstName} you have a job to do.");
                    sw.WriteLine($"Local: {lead.Suburb}, {lead.DateCreated}");
                    sw.WriteLine($"Job desciption: {lead.Description}");
                    sw.WriteLine($"Price: U${lead.Price}");
                }
            }
        }
    }
}
