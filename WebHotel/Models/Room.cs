using System;
using System.Collections.Generic;

namespace WebHotel.Model;

public partial class Room
{
    public string Id { get; set; } = null!;

    public string RoomNumber { get; set; } = null!;

    public string Name { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? Description { get; set; }

    public string? RoomPicture { get; set; }

    public float? Star { get; set; }

    public bool? GuestNumber { get; set; }

    public decimal CurrentPrice { get; set; }

    public decimal? DiscountPrice { get; set; }

    public DateTime? CreatedAt { get; set; }

    public byte[]? UpdatedAt { get; set; }

    public int RoomTypeId { get; set; }

    public virtual ICollection<DiscountRoomDetail> DiscountRoomDetails { get; } = new List<DiscountRoomDetail>();

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();

    public virtual ICollection<RoomStar> RoomStarts { get; } = new List<RoomStar>();

    public virtual RoomType RoomType { get; set; } = null!;
}
