using WebHotel.Model;

namespace WebHotel.Repository.EmailRepository
{
    public interface IMailRepository
    {
        void Email(EmailRequest mailRequest);
    }
}
