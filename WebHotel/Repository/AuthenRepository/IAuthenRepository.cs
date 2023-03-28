using Microsoft.AspNetCore.Mvc;
using WebHotel.Model;
using WebHotel.Model.Authentication;

namespace WebHotel.Repository.AuthenRepository
{
    public interface IAuthenRepository
    {
        //Login
        Task<object> Login([FromBody] LoginModel model);
        //Register and send mail confirm
        Task<Status> Registration([FromBody] RegistrationModel model);
        //Register with admin
        Task<Status> RegistrationAdmin([FromBody] RegistrationModel model);
        //Confirm successful registration by mail
        Task<bool> ConfirmEmailRegiste(string email, string code);
        // Confirm successful change pass
        Task<Status> RequestResetPassword(string? email);
        Task<Status> RequestChangePassword(ForgotPasswordModel forgotPasswordModel);
        Task<Status> ConfirmChangePassword(string? code, string? email, ResetPasswordModel resetPasswordModel);
    }
}
