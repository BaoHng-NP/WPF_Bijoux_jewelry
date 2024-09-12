using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bijoux_Jewelry.DataAccess.Models;

public partial class DiamondShopDbContext : DbContext
{
    public DiamondShopDbContext()
    {
    }

    public DiamondShopDbContext(DbContextOptions<DiamondShopDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Diamond> Diamonds { get; set; }

    public virtual DbSet<DiamondClarity> DiamondClarities { get; set; }

    public virtual DbSet<DiamondColor> DiamondColors { get; set; }

    public virtual DbSet<DiamondOrigin> DiamondOrigins { get; set; }

    public virtual DbSet<Metal> Metals { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductDiamond> ProductDiamonds { get; set; }

    public virtual DbSet<ProductMetal> ProductMetals { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<ProductionProcess> ProductionProcesses { get; set; }

    public virtual DbSet<ProductionStatus> ProductionStatuses { get; set; }

    public virtual DbSet<Quote> Quotes { get; set; }

    public virtual DbSet<QuoteStatus> QuoteStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //var connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("ConnectionStrings");
            optionsBuilder.UseSqlServer(GetConnectionString());
        }
    }
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();
            var strConn = config["ConnectionStrings:DefaultConnectionStringDB"];

            return strConn;
        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3213E83FBFE68529");

            entity.ToTable("Account");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.Dob)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Fullname).HasColumnName("fullname");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("phone");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Username)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("username");
        });

        modelBuilder.Entity<Diamond>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Diamond__3213E83FB5853AB8");

            entity.ToTable("Diamond");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.DiamondClarityId).HasColumnName("diamond_clarity_id");
            entity.Property(e => e.DiamondColorId).HasColumnName("diamond_color_id");
            entity.Property(e => e.DiamondOriginId).HasColumnName("diamond_origin_id");
            entity.Property(e => e.ImageUrl).HasColumnName("imageUrl");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.DiamondClarity).WithMany(p => p.Diamonds)
                .HasForeignKey(d => d.DiamondClarityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Diamond__diamond__7A672E12");

            entity.HasOne(d => d.DiamondColor).WithMany(p => p.Diamonds)
                .HasForeignKey(d => d.DiamondColorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Diamond__diamond__787EE5A0");

            entity.HasOne(d => d.DiamondOrigin).WithMany(p => p.Diamonds)
                .HasForeignKey(d => d.DiamondOriginId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Diamond__diamond__797309D9");
        });

        modelBuilder.Entity<DiamondClarity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Diamond___3213E83F359E7EF3");

            entity.ToTable("Diamond_Clarity");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<DiamondColor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Diamond___3213E83FDA3EBE26");

            entity.ToTable("Diamond_Color");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<DiamondOrigin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Diamond___3213E83FDE89FD22");

            entity.ToTable("Diamond_Origin");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Metal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Metal__3213E83FC4D7F042");

            entity.ToTable("Metal");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BuyPricePerGram).HasColumnName("buy_price_per_gram");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.Deactivated).HasColumnName("deactivated");
            entity.Property(e => e.ImageUrl).HasColumnName("imageUrl");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.SalePricePerGram).HasColumnName("sale_price_per_gram");
            entity.Property(e => e.SpecificWeight).HasColumnName("specific_weight");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3213E83F8C185415");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.DesignStaffId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("design_staff_id");
            entity.Property(e => e.Note)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("note");
            entity.Property(e => e.OrderStatusId).HasColumnName("order_status_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductPrice).HasColumnName("product_price");
            entity.Property(e => e.ProductionPrice).HasColumnName("production_price");
            entity.Property(e => e.DepositHasPaid).HasColumnName("deposit_has_paid");
            entity.Property(e => e.ProductionStaffId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("production_staff_id");
            entity.Property(e => e.ProfitRate).HasColumnName("profit_rate");
            entity.Property(e => e.TotalPrice).HasColumnName("total_price");

            entity.HasOne(d => d.Account).WithMany(p => p.OrderAccounts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__account___66603565");

            entity.HasOne(d => d.DesignStaff).WithMany(p => p.OrderDesignStaffs)
                .HasForeignKey(d => d.DesignStaffId)
                .HasConstraintName("FK__Orders__design_s__68487DD7");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__order_st__6754599E");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__product___656C112C");

            entity.HasOne(d => d.ProductionStaff).WithMany(p => p.OrderProductionStaffs)
                .HasForeignKey(d => d.ProductionStaffId)
                .HasConstraintName("FK__Orders__producti__693CA210");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order_St__3213E83F5392F250");

            entity.ToTable("Order_Status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3213E83F5B230C79");

            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ImageUrl).HasColumnName("imageUrl");
            entity.Property(e => e.MountingSize)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("mounting_size");
            entity.Property(e => e.ProductTypeId).HasColumnName("product_type_id");

            entity.HasOne(d => d.ProductType).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__product__5441852A");
        });

        modelBuilder.Entity<ProductDiamond>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product___3213E83FD4536576");

            entity.ToTable("Product_Diamond");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.DiamondId).HasColumnName("diamond_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Diamond).WithMany(p => p.ProductDiamonds)
                .HasForeignKey(d => d.DiamondId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product_D__diamo__00200768");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductDiamonds)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product_D__produ__7F2BE32F");
        });

        modelBuilder.Entity<ProductMetal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product___3213E83F9108C4AF");

            entity.ToTable("Product_Metal");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MetalId).HasColumnName("metal_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.Metal).WithMany(p => p.ProductMetals)
                .HasForeignKey(d => d.MetalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product_M__metal__03F0984C");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductMetals)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product_M__produ__02FC7413");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product___3213E83F1E45DF52");

            entity.ToTable("Product_Type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<ProductionProcess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producti__3213E83FE8F72C63");

            entity.ToTable("Production_Process");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.ImageUrl)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("imageUrl");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductionStatusId).HasColumnName("production_status_id");

            entity.HasOne(d => d.Order).WithMany(p => p.ProductionProcesses)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productio__order__6EF57B66");

            entity.HasOne(d => d.ProductionStatus).WithMany(p => p.ProductionProcesses)
                .HasForeignKey(d => d.ProductionStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productio__produ__6FE99F9F");
        });

        modelBuilder.Entity<ProductionStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producti__3213E83F2D5CE82C");

            entity.ToTable("Production_Status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Quote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Quote__3213E83F3917BD3A");

            entity.ToTable("Quote");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.DesignStaffId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("design_staff_id");
            entity.Property(e => e.Note)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("note");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductPrice).HasColumnName("product_price");
            entity.Property(e => e.ProductionPrice).HasColumnName("production_price");
            entity.Property(e => e.ProductionStaffId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("production_staff_id");
            entity.Property(e => e.ProfitRate).HasColumnName("profit_rate");
            entity.Property(e => e.QuoteStatusId).HasColumnName("quote_status_id");
            entity.Property(e => e.TotalPrice)
                .HasComputedColumnSql("(([product_price]*((100)+[profit_rate]))/(100)+[production_price])", true)
                .HasColumnName("total_price");

            entity.HasOne(d => d.Account).WithMany(p => p.QuoteAccounts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Quote__account_i__5AEE82B9");

            entity.HasOne(d => d.DesignStaff).WithMany(p => p.QuoteDesignStaffs)
                .HasForeignKey(d => d.DesignStaffId)
                .HasConstraintName("FK__Quote__design_st__5CD6CB2B");

            entity.HasOne(d => d.Product).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Quote__product_i__59FA5E80");

            entity.HasOne(d => d.ProductionStaff).WithMany(p => p.QuoteProductionStaffs)
                .HasForeignKey(d => d.ProductionStaffId)
                .HasConstraintName("FK__Quote__productio__5DCAEF64");

            entity.HasOne(d => d.QuoteStatus).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.QuoteStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Quote__quote_sta__5BE2A6F2");
        });

        modelBuilder.Entity<QuoteStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Quote_St__3213E83F5FE0FA5C");

            entity.ToTable("Quote_Status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
