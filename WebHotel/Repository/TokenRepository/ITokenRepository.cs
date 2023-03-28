using WebHotel.Model.Token;
using System.Security.Claims;

namespace WebHotel.Repository.TokenRepository
{
    public interface ITokenRepository
    {
        AccessTokenResponse GetAccessToken(IEnumerable<Claim> claim);
        string GetRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        object RefreshToken(TokenRequest tokenRequest);
        bool Revoke(TokenRequest tokenRequest);
    }
}
