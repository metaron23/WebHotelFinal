﻿using System;
using System.Collections.Generic;

namespace WebHotel.Model;

public partial class RoomStar
{
    public int Id { get; set; }

    public int Number { get; set; }

    public string RoomId { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
