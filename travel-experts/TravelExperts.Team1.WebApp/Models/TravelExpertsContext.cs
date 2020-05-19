using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TravelExperts.Team1.WebApp.Models
{
    public partial class TravelExpertsContext : DbContext
    {
        public TravelExpertsContext()
        {
        }
        
        public TravelExpertsContext(DbContextOptions<TravelExpertsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Affiliations> Affiliations { get; set; }
        public virtual DbSet<Agencies> Agencies { get; set; }
        public virtual DbSet<Agents> Agents { get; set; }
        public virtual DbSet<Authentication> Authentication { get; set; }
        public virtual DbSet<BookingDetails> BookingDetails { get; set; }
        public virtual DbSet<Bookings> Bookings { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<CreditCards> CreditCards { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<CustomersRewards> CustomersRewards { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Fees> Fees { get; set; }
        public virtual DbSet<Packages> Packages { get; set; }
        public virtual DbSet<PackagesProductsSuppliers> PackagesProductsSuppliers { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductsSuppliers> ProductsSuppliers { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<Rewards> Rewards { get; set; }
        public virtual DbSet<SupplierContacts> SupplierContacts { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<TripTypes> TripTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=TravelExperts_Team1;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Affiliations>(entity =>
            {
                entity.HasKey(e => e.AffilitationId)
                    .HasName("aaaaaAffiliations_PK")
                    .IsClustered(false);
            });

            modelBuilder.Entity<Agents>(entity =>
            {
                entity.HasOne(d => d.Agency)
                    .WithMany(p => p.Agents)
                    .HasForeignKey(d => d.AgencyId)
                    .HasConstraintName("FK_Agents_Agencies");
            });

            modelBuilder.Entity<Authentication>(entity =>
            {
                entity.HasIndex(e => new { e.Username, e.Password })
                    .HasName("UC_Auth")
                    .IsUnique();

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Authentication)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuthenticationCustomers");
            });

            modelBuilder.Entity<BookingDetails>(entity =>
            {
                entity.HasKey(e => e.BookingDetailId)
                    .HasName("aaaaaBookingDetails_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.BookingId)
                    .HasName("BookingsBookingDetails");

                entity.HasIndex(e => e.ClassId)
                    .HasName("ClassesBookingDetails");

                entity.HasIndex(e => e.FeeId)
                    .HasName("FeesBookingDetails");

                entity.HasIndex(e => e.ProductSupplierId)
                    .HasName("ProductSupplierId");

                entity.HasIndex(e => e.RegionId)
                    .HasName("DestinationsBookingDetails");

                entity.Property(e => e.BookingId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductSupplierId).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK_BookingDetails_Bookings");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_BookingDetails_Classes");

                entity.HasOne(d => d.Fee)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.FeeId)
                    .HasConstraintName("FK_BookingDetails_Fees");

                entity.HasOne(d => d.ProductSupplier)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.ProductSupplierId)
                    .HasConstraintName("FK_BookingDetails_Products_Suppliers");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK_BookingDetails_Regions");
            });

            modelBuilder.Entity<Bookings>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("aaaaaBookings_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.CustomerId)
                    .HasName("CustomersBookings");

                entity.HasIndex(e => e.PackageId)
                    .HasName("PackagesBookings");

                entity.HasIndex(e => e.TripTypeId)
                    .HasName("TripTypesBookings");

                entity.Property(e => e.PackageId).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("Bookings_FK00");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("Bookings_FK01");

                entity.HasOne(d => d.TripType)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.TripTypeId)
                    .HasConstraintName("Bookings_FK02");
            });

            modelBuilder.Entity<Classes>(entity =>
            {
                entity.HasKey(e => e.ClassId)
                    .HasName("aaaaaClasses_PK")
                    .IsClustered(false);
            });

            modelBuilder.Entity<CreditCards>(entity =>
            {
                entity.HasKey(e => e.CreditCardId)
                    .HasName("aaaaaCreditCards_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.CustomerId)
                    .HasName("CustomersCreditCards");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CreditCards)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CreditCards_FK00");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("aaaaaCustomers_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.AgentId)
                    .HasName("EmployeesCustomers");

                entity.HasOne(d => d.Agent)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AgentId)
                    .HasConstraintName("FK_Customers_Agents");
            });

            modelBuilder.Entity<CustomersRewards>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.RewardId })
                    .HasName("aaaaaCustomers_Rewards_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.CustomerId)
                    .HasName("CustomersCustomers_Rewards");

                entity.HasIndex(e => e.RewardId)
                    .HasName("RewardsCustomers_Rewards");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomersRewards)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Customers_Rewards_FK00");

                entity.HasOne(d => d.Reward)
                    .WithMany(p => p.CustomersRewards)
                    .HasForeignKey(d => d.RewardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Customers_Rewards_FK01");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Fees>(entity =>
            {
                entity.HasKey(e => e.FeeId)
                    .HasName("aaaaaFees_PK")
                    .IsClustered(false);
            });

            modelBuilder.Entity<Packages>(entity =>
            {
                entity.HasKey(e => e.PackageId)
                    .HasName("aaaaaPackages_PK")
                    .IsClustered(false);

                entity.Property(e => e.PkgAgencyCommission).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<PackagesProductsSuppliers>(entity =>
            {
                entity.HasKey(e => new { e.PackageId, e.ProductSupplierId })
                    .HasName("aaaaaPackages_Products_Suppliers_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.PackageId)
                    .HasName("PackagesPackages_Products_Suppliers");

                entity.HasIndex(e => e.ProductSupplierId)
                    .HasName("ProductSupplierId");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.PackagesProductsSuppliers)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Packages_Products_Supplie_FK00");

                entity.HasOne(d => d.ProductSupplier)
                    .WithMany(p => p.PackagesProductsSuppliers)
                    .HasForeignKey(d => d.ProductSupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Packages_Products_Supplie_FK01");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("aaaaaProducts_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.ProductId)
                    .HasName("ProductId");
            });

            modelBuilder.Entity<ProductsSuppliers>(entity =>
            {
                entity.HasKey(e => e.ProductSupplierId)
                    .HasName("aaaaaProducts_Suppliers_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.ProductId)
                    .HasName("ProductsProducts_Suppliers1");

                entity.HasIndex(e => e.ProductSupplierId)
                    .HasName("ProductSupplierId");

                entity.HasIndex(e => e.SupplierId)
                    .HasName("SuppliersProducts_Suppliers1");

                entity.Property(e => e.ProductId).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductsSuppliers)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("Products_Suppliers_FK00");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.ProductsSuppliers)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("Products_Suppliers_FK01");
            });

            modelBuilder.Entity<Regions>(entity =>
            {
                entity.HasKey(e => e.RegionId)
                    .HasName("aaaaaRegions_PK")
                    .IsClustered(false);
            });

            modelBuilder.Entity<Rewards>(entity =>
            {
                entity.HasKey(e => e.RewardId)
                    .HasName("aaaaaRewards_PK")
                    .IsClustered(false);

                entity.Property(e => e.RewardId).ValueGeneratedNever();
            });

            modelBuilder.Entity<SupplierContacts>(entity =>
            {
                entity.HasKey(e => e.SupplierContactId)
                    .HasName("aaaaaSupplierContacts_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.AffiliationId)
                    .HasName("AffiliationsSupCon");

                entity.HasIndex(e => e.SupplierId)
                    .HasName("SuppliersSupCon");

                entity.Property(e => e.SupplierContactId).ValueGeneratedNever();

                entity.Property(e => e.SupplierId).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Affiliation)
                    .WithMany(p => p.SupplierContacts)
                    .HasForeignKey(d => d.AffiliationId)
                    .HasConstraintName("SupplierContacts_FK00");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.SupplierContacts)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("SupplierContacts_FK01");
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.HasKey(e => e.SupplierId)
                    .HasName("aaaaaSuppliers_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.SupplierId)
                    .HasName("SupplierId");

                entity.Property(e => e.SupplierId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TripTypes>(entity =>
            {
                entity.HasKey(e => e.TripTypeId)
                    .HasName("aaaaaTripTypes_PK")
                    .IsClustered(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
