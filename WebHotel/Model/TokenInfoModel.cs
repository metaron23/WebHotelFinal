using System;
using System.Collections.Generic;

namespace WebHotel.Model;

public partial class TokenInfoModel
{

    public string? Usename { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime RefreshTokenExpiry { get; set; }
}
