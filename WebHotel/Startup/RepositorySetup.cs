using Microsoft.AspNetCore.SignalR;
using WebHotel.Repository.AuthenRepository;
using WebHotel.Repository.EmailRepository;
using WebHotel.Repository.NotifiHub;
using WebHotel.Repository.TokenRepository;

namespace WebHotel.Startup
{
    public static class RepositorySetup
    {
        public static IServiceCollection RepositoryService(this IServiceCollection services)
        {
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IAuthenRepository, AuthenRepository>();
            services.AddScoped<IMailRepository, MailRepository>();
            return services;
        }
    }
}
