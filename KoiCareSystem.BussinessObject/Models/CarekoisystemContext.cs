using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoiCareSystem.BussinessObject.Models;

public partial class CarekoisystemContext : DbContext
{
    public CarekoisystemContext()
    {
    }

    public CarekoisystemContext(DbContextOptions<CarekoisystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<CareProperty> CareProperties { get; set; }

    public virtual DbSet<CareSchedule> CareSchedules { get; set; }

    public virtual DbSet<Feeding> Feedings { get; set; }

    public virtual DbSet<FoodItem> FoodItems { get; set; }

    public virtual DbSet<KoiFish> KoiFishes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Pond> Ponds { get; set; }

    public virtual DbSet<PondFeeding> PondFeedings { get; set; }

    public virtual DbSet<PondKoiFish> PondKoiFishes { get; set; }

    public virtual DbSet<WaterParameter> WaterParameters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local);Database=carekoisystem;Uid=sa;Pwd=sa12345;Trusted_Connection=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3213E83F0D37750A");

            entity.ToTable("Account");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Avatar).HasMaxLength(255);
            entity.Property(e => e.Deleted).HasDefaultValue(false);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(255);
        });

        modelBuilder.Entity<CareProperty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CareProp__3213E83F5C56DB78");

            entity.ToTable("CareProperty");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .HasColumnName("value");

            entity.HasOne(d => d.Schedule).WithMany(p => p.CareProperties)
                .HasForeignKey(d => d.ScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarePrope__sched__66603565");
        });

        modelBuilder.Entity<CareSchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CareSche__3213E83F1044989E");

            entity.ToTable("CareSchedule");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CareType)
                .HasMaxLength(255)
                .HasColumnName("care_type");
            entity.Property(e => e.Details).HasColumnName("details");
            entity.Property(e => e.PondId).HasColumnName("pond_id");
            entity.Property(e => e.ScheduledDate)
                .HasColumnType("datetime")
                .HasColumnName("scheduled_date");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");

            entity.HasOne(d => d.Pond).WithMany(p => p.CareSchedules)
                .HasForeignKey(d => d.PondId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CareSched__pond___6383C8BA");
        });

        modelBuilder.Entity<Feeding>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Feeding__3213E83F257EF478");

            entity.ToTable("Feeding");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FeedAmount)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("feed_amount");
            entity.Property(e => e.FeedingTime)
                .HasColumnType("datetime")
                .HasColumnName("feeding_time");
            entity.Property(e => e.FoodType)
                .HasMaxLength(255)
                .HasColumnName("food_type");
            entity.Property(e => e.PondFeedingId).HasColumnName("pond_feeding_id");
        });

        modelBuilder.Entity<FoodItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FoodItem__3213E83F59F455AD");

            entity.ToTable("FoodItem");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category)
                .HasMaxLength(255)
                .HasColumnName("category");
            entity.Property(e => e.Deleted).HasDefaultValue(false);
            entity.Property(e => e.FoodName)
                .HasMaxLength(255)
                .HasColumnName("food_name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
        });

        modelBuilder.Entity<KoiFish>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KoiFish__3213E83F52EFFAB1");

            entity.ToTable("KoiFish");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.Deleted)
                .HasDefaultValue(false)
                .HasColumnName("deleted");
            entity.Property(e => e.FishName)
                .HasMaxLength(255)
                .HasColumnName("fishName");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .HasColumnName("gender");
            entity.Property(e => e.HealthStatus)
                .HasMaxLength(50)
                .HasColumnName("healthStatus");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(255)
                .HasColumnName("imagePath");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.Origin)
                .HasMaxLength(255)
                .HasColumnName("origin");
            entity.Property(e => e.Species)
                .HasMaxLength(255)
                .HasColumnName("species");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3213E83F568F0AF9");

            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Deleted).HasDefaultValue(false);
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("orderDate");
            entity.Property(e => e.Receiver)
                .HasMaxLength(255)
                .HasColumnName("receiver");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("totalAmount");

            entity.HasOne(d => d.Account).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order__account_i__49C3F6B7");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3213E83F7C33A207");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FoodItemId).HasColumnName("foodItem_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.FoodItem).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.FoodItemId)
                .HasConstraintName("FK__OrderDeta__foodI__5165187F");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__order__5070F446");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payment__3213E83FD64D66F4");

            entity.ToTable("Payment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.PaymentDate)
                .HasColumnType("datetime")
                .HasColumnName("paymentDate");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payment__order_i__5535A963");
        });

        modelBuilder.Entity<Pond>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pond__3213E83F9BCC49CD");

            entity.ToTable("Pond");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Deleted).HasDefaultValue(false);
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Account).WithMany(p => p.Ponds)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pond__account_id__3D5E1FD2");
        });

        modelBuilder.Entity<PondFeeding>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pond_Fee__3213E83F8FFBECB6");

            entity.ToTable("Pond_Feeding");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FeedingDate)
                .HasColumnType("datetime")
                .HasColumnName("feeding_date");
            entity.Property(e => e.FeedingId).HasColumnName("feeding_id");
            entity.Property(e => e.PondId).HasColumnName("pond_id");

            entity.HasOne(d => d.Feeding).WithMany(p => p.PondFeedings)
                .HasForeignKey(d => d.FeedingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pond_Feed__feedi__5EBF139D");

            entity.HasOne(d => d.Pond).WithMany(p => p.PondFeedings)
                .HasForeignKey(d => d.PondId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pond_Feed__pond___5DCAEF64");
        });

        modelBuilder.Entity<PondKoiFish>(entity =>
        {
            entity.HasKey(e => new { e.PondId, e.KoifishId }).HasName("PK__Pond_Koi__68CE746372AA502F");

            entity.ToTable("Pond_KoiFish");

            entity.Property(e => e.PondId).HasColumnName("pond_id");
            entity.Property(e => e.KoifishId).HasColumnName("koifish_id");
            entity.Property(e => e.AddedDate)
                .HasColumnType("datetime")
                .HasColumnName("added_date");
            entity.Property(e => e.RemovedDate)
                .HasColumnType("datetime")
                .HasColumnName("removed_date");

            entity.HasOne(d => d.Koifish).WithMany(p => p.PondKoiFishes)
                .HasForeignKey(d => d.KoifishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pond_KoiF__koifi__44FF419A");

            entity.HasOne(d => d.Pond).WithMany(p => p.PondKoiFishes)
                .HasForeignKey(d => d.PondId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pond_KoiF__pond___440B1D61");
        });

        modelBuilder.Entity<WaterParameter>(entity =>
        {
            entity.HasKey(e => new { e.PondId, e.CheckDate }).HasName("PK__WaterPar__89AD05644D8973A1");

            entity.ToTable("WaterParameter");

            entity.Property(e => e.PondId).HasColumnName("pond_id");
            entity.Property(e => e.CheckDate)
                .HasColumnType("datetime")
                .HasColumnName("checkDate");
            entity.Property(e => e.Co2)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("CO2");
            entity.Property(e => e.No2)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("NO2");
            entity.Property(e => e.PH)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("pH");
            entity.Property(e => e.Temperature)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("temperature");

            entity.HasOne(d => d.Pond).WithMany(p => p.WaterParameters)
                .HasForeignKey(d => d.PondId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WaterPara__pond___5812160E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
