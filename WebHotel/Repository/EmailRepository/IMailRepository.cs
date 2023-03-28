using WebHotel.Model;

namespace WebHotel.Repository.EmailRepository
{
    public interface IMailRepository
    {
        bool Email(EmailRequest mailRequest);
    }
}
