using WebHotel.DTO;

namespace WebHotel.Repository.EmailRepository
{
    public interface IMailRepository
    {
        bool Email(EmailRequestDto mailRequest);
    }
}
