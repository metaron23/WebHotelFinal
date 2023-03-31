using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebHotel.Model;

namespace WebHotel.Data;

public partial class MyDBContext : IdentityDbContext<ApplicationUser>
{
    public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
    {
    }

    public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<DiscountReservationDetail> DiscountReservationDetails { get; set; }

    public virtual DbSet<DiscountRoomDetail> DiscountRoomDetails { get; set; }

    public virtual DbSet<DiscountServiceDetail> DiscountServiceDetails { get; set; }

    public virtual DbSet<DiscountType> DiscountTypes { get; set; }

    public virtual DbSet<InvoiceReservation> InvoiceReservations { get; set; }

    public virtual DbSet<OrderService> OrderServices { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<ReservationChat> ReservationChats { get; set; }

    public virtual DbSet<ReservationStatus> ReservationStatuses { get; set; }

    public virtual DbSet<ReservationStatusEvent> ReservationStatusEvents { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomStar> RoomStarts { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    public virtual DbSet<ServiceAttach> ServiceAttaches { get; set; }

    public virtual DbSet<ServiceAttachDetail> ServiceAttachDetails { get; set; }

    public virtual DbSet<ServiceRoom> ServiceRooms { get; set; }

    public virtual DbSet<TokenInfo> TokenInfos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Image).HasMaxLength(450);
            entity.Property(e => e.CreatedAt).IsRowVersion().IsConcurrencyToken().HasDefaultValueSql("GetDate()");
        });
        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discount__3214EC07023FEEE8");

            entity.ToTable("Discount");

            entity.HasIndex(e => e.DiscountCode, "Discount_DiscountCode").IsUnique();

            entity.Property(e => e.CreatorId).HasMaxLength(450);
            entity.Property(e => e.DiscountCode).HasMaxLength(255);
            entity.Property(e => e.DiscountPercent).HasColumnType("decimal(19, 2)");
            entity.Property(e => e.EndAt).HasColumnType("datetime");
            entity.Property(e => e.IsPermanent).HasDefaultValueSql("((0))");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.StartAt).HasColumnType("datetime");

            entity.HasOne(d => d.Creator).WithMany(p => p.Discounts)
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKDiscount927333");

            entity.HasOne(d => d.DiscountType).WithMany(p => p.Discounts)
                .HasForeignKey(d => d.DiscountTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKDiscount61895");
        });

        modelBuilder.Entity<DiscountReservationDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discount__3214EC073350C584");

            entity.ToTable("DiscountReservationDetail");

            entity.Property(e => e.CreatorId).HasMaxLength(450);
            entity.Property(e => e.ReservationId).HasMaxLength(255);

            entity.HasOne(d => d.Creator).WithMany(p => p.DiscountReservationDetails)
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKDiscountRe595640");

            entity.HasOne(d => d.Discount).WithMany(p => p.DiscountReservationDetails)
                .HasForeignKey(d => d.DiscountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKDiscountRe678897");

            entity.HasOne(d => d.Reservation).WithMany(p => p.DiscountReservationDetails)
                .HasForeignKey(d => d.ReservationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKDiscountRe215096");
        });

        modelBuilder.Entity<DiscountRoomDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discount__3214EC078E422AFB");

            entity.ToTable("DiscountRoomDetail");

            entity.Property(e => e.CreatorId).HasMaxLength(450);
            entity.Property(e => e.RoomId).HasMaxLength(255);

            entity.HasOne(d => d.Creator).WithMany(p => p.DiscountRoomDetails)
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKDiscountRo944649");

            entity.HasOne(d => d.Discount).WithMany(p => p.DiscountRoomDetails)
                .HasForeignKey(d => d.DiscountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKDiscountRo138607");

            entity.HasOne(d => d.Room).WithMany(p => p.DiscountRoomDetails)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKDiscountRo29575");
        });

        modelBuilder.Entity<DiscountServiceDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discount__3214EC0758312396");

            entity.ToTable("DiscountServiceDetail");

            entity.Property(e => e.CreatorId).HasMaxLength(450);

            entity.HasOne(d => d.Creator).WithMany(p => p.DiscountServiceDetails)
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKDiscountSe833248");

            entity.HasOne(d => d.Discount).WithMany(p => p.DiscountServiceDetails)
                .HasForeignKey(d => d.DiscountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKDiscountSe250008");

            entity.HasOne(d => d.Service).WithMany(p => p.DiscountServiceDetails)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKDiscountSe716587");
        });

        modelBuilder.Entity<DiscountType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discount__3214EC077E70E0C3");

            entity.ToTable("DiscountType");

            entity.HasIndex(e => e.Name, "DiscountType_Name").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<InvoiceReservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InvoiceR__3214EC0792A2C41D");

            entity.ToTable("InvoiceReservation");

            entity.Property(e => e.ConfirmerId).HasMaxLength(450);
            entity.Property(e => e.IssuedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaidAt)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.PriceReservedRoom).HasColumnType("decimal(19, 2)");
            entity.Property(e => e.PriceService)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(19, 2)");
            entity.Property(e => e.ReservationId).HasMaxLength(255);

            entity.HasOne(d => d.Confirmer).WithMany(p => p.InvoiceReservations)
                .HasForeignKey(d => d.ConfirmerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKInvoiceRes286606");

            entity.HasOne(d => d.Reservation).WithMany(p => p.InvoiceReservations)
                .HasForeignKey(d => d.ReservationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKInvoiceRes190462");
        });

        modelBuilder.Entity<OrderService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderSer__3214EC076B892BFE");

            entity.ToTable("OrderService");

            entity.Property(e => e.Price).HasColumnType("decimal(19, 2)");
            entity.Property(e => e.ReservationId).HasMaxLength(255);
            entity.Property(e => e.ServiceName).HasMaxLength(255);
            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.Reservation).WithMany(p => p.OrderServices)
                .HasForeignKey(d => d.ReservationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKOrderServi258673");

            entity.HasOne(d => d.ServiceRoom).WithMany(p => p.OrderServices)
                .HasForeignKey(d => d.ServiceRoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKOrderServi447170");

            entity.HasOne(d => d.User).WithMany(p => p.OrderServices)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKOrderServi791508");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservat__3214EC077D5C0580");

            entity.ToTable("Reservation");

            entity.Property(e => e.Id).HasMaxLength(255);
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.DepositEndAt).HasColumnType("datetime");
            entity.Property(e => e.DepositPrice).HasColumnType("decimal(19, 2)");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.ReservationPrice).HasColumnType("decimal(19, 2)");
            entity.Property(e => e.RoomId).HasMaxLength(255);
            entity.Property(e => e.RoomPrice).HasColumnType("decimal(19, 2)");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.Room).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKReservatio111598");

            entity.HasOne(d => d.User).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKReservatio38059");
        });

        modelBuilder.Entity<ReservationChat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservat__3214EC07C34EF3BE");

            entity.ToTable("ReservationChat");

            entity.Property(e => e.Message).HasColumnType("ntext");
            entity.Property(e => e.ReceiveUsername).HasMaxLength(255);
            entity.Property(e => e.ReservationId).HasMaxLength(255);
            entity.Property(e => e.SendAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SendUsername).HasMaxLength(255);

            entity.HasOne(d => d.Reservation).WithMany(p => p.ReservationChats)
                .HasForeignKey(d => d.ReservationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKReservatio436575");
        });

        modelBuilder.Entity<ReservationStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservat__3214EC07DDAE021A");

            entity.ToTable("ReservationStatus");

            entity.Property(e => e.StatusName).HasMaxLength(255);
        });

        modelBuilder.Entity<ReservationStatusEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservat__3214EC075214B5A8");

            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.ReservationId).HasMaxLength(255);

            entity.HasOne(d => d.Reservation).WithMany(p => p.ReservationStatusEvents)
                .HasForeignKey(d => d.ReservationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKReservatio37187");

            entity.HasOne(d => d.ReservationStatus).WithMany(p => p.ReservationStatusEvents)
                .HasForeignKey(d => d.ReservationStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKReservatio956578");
        });
        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Room__3214EC0771E8712D");

            entity.ToTable("Room");

            entity.HasIndex(e => e.Name, "Room_Name").IsUnique();

            entity.HasIndex(e => e.RoomNumber, "Room_RoomNumber").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(255).HasDefaultValueSql("newid()");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CurrentPrice).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.DiscountPrice).HasColumnType("decimal(19, 2)");
            entity.Property(e => e.GuestNumber)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("('true')");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.RoomNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RoomPicture)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.RoomType).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.RoomTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKRoom188940");
        });

        modelBuilder.Entity<RoomStar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoomStar__3214EC07E2560515");

            entity.ToTable("RoomStart");

            entity.Property(e => e.RoomId).HasMaxLength(255);

            entity.HasOne(d => d.Room).WithMany(p => p.RoomStarts)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKRoomStart413566");
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoomType__3214EC07B21F96D7");

            entity.ToTable("RoomType");

            entity.HasIndex(e => e.TypeName, "RoomType_TypeName").IsUnique();

            entity.Property(e => e.TypeName).HasMaxLength(255);
        });

        modelBuilder.Entity<ServiceAttach>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ServiceA__3214EC0700176119");

            entity.ToTable("ServiceAttach");

            entity.HasIndex(e => e.Name, "ServiceAttach_Name").IsUnique();

            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<ServiceAttachDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ServiceA__3214EC0778073DD2");

            entity.ToTable("ServiceAttachDetail");

            entity.HasOne(d => d.RoomType).WithMany(p => p.ServiceAttachDetails)
                .HasForeignKey(d => d.RoomTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKServiceAtt405938");

            entity.HasOne(d => d.ServiceAttach).WithMany(p => p.ServiceAttachDetails)
                .HasForeignKey(d => d.ServiceAttachId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKServiceAtt700016");
        });

        modelBuilder.Entity<ServiceRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ServiceR__3214EC0728E81D09");

            entity.ToTable("ServiceRoom");

            entity.HasIndex(e => e.Name, "ServiceRoom_Name").IsUnique();

            entity.Property(e => e.Amount).HasDefaultValueSql("((0))");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Picture).HasColumnType("ntext");
            entity.Property(e => e.Price).HasColumnType("decimal(19, 2)");
            entity.Property(e => e.PriceDiscount).HasColumnType("decimal(19, 2)");
        });

        modelBuilder.Entity<TokenInfo>(entity =>
        {
            entity.ToTable("TokenInfo");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
