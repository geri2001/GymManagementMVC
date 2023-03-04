using GymManagementMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymManagementMVC.Data;

public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Discount> Discounts { get; set; } = null!;
    public virtual DbSet<DiscountedMemberSubscription> DiscountedMemberSubscriptions { get; set; } = null!;
    public virtual DbSet<MemberSubscription> MemberSubscriptions { get; set; } = null!;
    public virtual DbSet<Subscription> Subscriptions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Discount>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Code).HasMaxLength(50);

            entity.Property(e => e.EndDate).HasColumnType("date");

            entity.Property(e => e.StartDate).HasColumnType("date");

            entity.Property(e => e.Value).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<DiscountedMemberSubscription>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.DiscountsId).HasColumnName("DiscountsID");

            entity.Property(e => e.MemberSubscriptionsId).HasColumnName("MemberSubscriptionsID");

            entity.HasOne(d => d.Discounts)
                .WithMany(p => p.DiscountedMemberSubscriptions)
                .HasForeignKey(d => d.DiscountsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiscountedMemberSubscriptions_Discounts");

            entity.HasOne(d => d.MemberSubscriptions)
                .WithMany(p => p.DiscountedMemberSubscriptions)
                .HasForeignKey(d => d.MemberSubscriptionsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiscountedMemberSubscriptions_MemberSubscriptions");
        });

        modelBuilder.Entity<MemberSubscription>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.AspNetUsersId).HasColumnName("AspNetUsersID");

            entity.Property(e => e.DiscountValue).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.EndDate).HasColumnType("date");

            entity.Property(e => e.OriginalPrice).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.PaidPrice).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.StartDate).HasColumnType("date");

            entity.Property(e => e.SubscriptionsId).HasColumnName("SubscriptionsID");

            entity.HasOne(d => d.AspNetUsers)
                .WithMany(p => p.MemberSubscriptions)
                .HasForeignKey(d => d.AspNetUsersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberSubscriptions_AspNetUsers");

            entity.HasOne(d => d.Subscriptions)
                .WithMany(p => p.MemberSubscriptions)
                .HasForeignKey(d => d.SubscriptionsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberSubscriptions_Subscriptions");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Code).HasMaxLength(50);

            entity.Property(e => e.Description).HasMaxLength(250);

            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.WeekFrequency).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
