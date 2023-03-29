using Microsoft.AspNetCore.Mvc;
using WebHotel.DTO;
using WebHotel.DTO.Authentication;

namespace WebHotel.Repository.AuthenRepository
{
    public interface IAuthenRepository
    {
        //Login
        Task<object> Login([FromBody] LoginDto model);
        //Register and send mail confirm
        Task<StatusDto> Registration([FromBody] RegistrationDto model);
        //Register with admin
        Task<StatusDto> RegistrationAdmin([FromBody] RegistrationDto model);
        //Confirm successful registration by mail
        Task<bool> ConfirmEmailRegiste(string email, string code);
        // Confirm successful change pass
        Task<StatusDto> RequestResetPassword(string? email);
        Task<StatusDto> RequestChangePassword(ForgotPasswordDto forgotPasswordModel);
        Task<StatusDto> ConfirmChangePassword(ResetPasswordDto resetPasswordModel);
    }
}
