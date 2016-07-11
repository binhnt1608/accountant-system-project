using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using MVCAccountantv2.Models;

namespace MVCAccountantv2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.CashAccount", b =>
                {
                    b.Property<int>("CashAccountID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountDescription");

                    b.Property<string>("BankAccountNumber");

                    b.Property<string>("BankName");

                    b.Property<int?>("CashDisbursementCheckNumber");

                    b.HasKey("CashAccountID");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.CashDisbursement", b =>
                {
                    b.Property<int>("CheckNumber")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CashAccountID");

                    b.Property<DateTime>("CashDisbursementDate");

                    b.Property<int>("EmployeeID");

                    b.Property<int>("VendorID");

                    b.HasKey("CheckNumber");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerAddress1")
                        .IsRequired();

                    b.Property<string>("CustomerAddress2");

                    b.Property<string>("CustomerCity")
                        .IsRequired();

                    b.Property<decimal>("CustomerCreditLimit");

                    b.Property<string>("CustomerName")
                        .IsRequired();

                    b.Property<string>("CustomerPrimaryContact");

                    b.Property<string>("CustomerState")
                        .IsRequired();

                    b.Property<string>("CustomerTelephone")
                        .IsRequired();

                    b.Property<string>("CustomerZipcode")
                        .IsRequired();

                    b.Property<int?>("SaleInvoiceID");

                    b.Property<int?>("SaleOrderSaleOrderID");

                    b.HasKey("CustomerID");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CashDisbursementCheckNumber");

                    b.Property<string>("EmployeeFirstName");

                    b.Property<string>("EmployeeLastName");

                    b.Property<int>("EmployeeTypeID");

                    b.Property<int?>("PurchaseReceivingReportID");

                    b.Property<int?>("SaleInvoiceID");

                    b.Property<int?>("SaleOrderSaleOrderID");

                    b.HasKey("EmployeeID");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.EmployeeType", b =>
                {
                    b.Property<int>("EmployeeTypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EmployeeEmployeeID");

                    b.Property<string>("EmployeeTypeName");

                    b.HasKey("EmployeeTypeID");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.Inventory", b =>
                {
                    b.Property<int>("InventoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InventoryCompositionID");

                    b.Property<string>("InventoryDescription")
                        .IsRequired();

                    b.Property<int>("InventoryDiameterID");

                    b.Property<string>("InventoryListPrice")
                        .IsRequired();

                    b.Property<int>("InventoryTypeID");

                    b.Property<int?>("OutFlow_SaleInventoryInvoiceID");

                    b.Property<int?>("Reservation_SaleOrderInventorySaleOrderID");

                    b.HasKey("InventoryID");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.InventoryComposition", b =>
                {
                    b.Property<int>("InventoryCompositionID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InventoryCompositionCode");

                    b.Property<string>("InventoryCompositionDescription");

                    b.HasKey("InventoryCompositionID");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.InventoryDiameter", b =>
                {
                    b.Property<int>("InventoryDiameterID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InventoryDiameterCode");

                    b.Property<string>("InventoryDiameterDescription");

                    b.HasKey("InventoryDiameterID");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.InventoryType", b =>
                {
                    b.Property<int>("InventoryTypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InventoryTypeCode");

                    b.Property<string>("InventoryTypeDescription");

                    b.HasKey("InventoryTypeID");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.OutFlow_SaleInventory", b =>
                {
                    b.Property<int>("InvoiceID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InventoryID");

                    b.Property<float>("InvoicePrive");

                    b.Property<int>("QuantitySold");

                    b.Property<int?>("SaleInvoiceID");

                    b.HasKey("InvoiceID");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.Purchase", b =>
                {
                    b.Property<int>("ReceivingReportID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeID");

                    b.Property<DateTime>("ReceivingReportDate");

                    b.Property<int>("ReceivingReportVendorInvoiceID");

                    b.Property<string>("VendorID");

                    b.Property<int?>("VendorVendorID");

                    b.HasKey("ReceivingReportID");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.Reservation_SaleOrderInventory", b =>
                {
                    b.Property<int>("SaleOrderID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InventoryID");

                    b.Property<int>("QuantityOrdered");

                    b.Property<float>("SOPrice");

                    b.Property<int?>("SaleOrderSaleOrderID");

                    b.HasKey("SaleOrderID");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.Sale", b =>
                {
                    b.Property<int>("InvoiceID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerID");

                    b.Property<int>("EmployeeID");

                    b.Property<int?>("OutFlow_SaleInventoryInvoiceID");

                    b.Property<int>("SaleAmount");

                    b.Property<int>("SaleOrderID");

                    b.Property<DateTime>("ShippingDate");

                    b.HasKey("InvoiceID");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.SaleOrder", b =>
                {
                    b.Property<int>("SaleOrderID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerID");

                    b.Property<string>("CustomerPO");

                    b.Property<int>("EmployeeID");

                    b.Property<int?>("Reservation_SaleOrderInventorySaleOrderID");

                    b.Property<float>("SaleOrderAmount");

                    b.Property<DateTime>("SaleOrderDate");

                    b.HasKey("SaleOrderID");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.Vendor", b =>
                {
                    b.Property<int>("VendorID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CashDisbursementCheckNumber");

                    b.Property<int?>("PurchaseReceivingReportID");

                    b.Property<string>("VendorName");

                    b.HasKey("VendorID");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MVCAccountantv2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MVCAccountantv2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("MVCAccountantv2.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.CashAccount", b =>
                {
                    b.HasOne("MVCAccountantv2.Models.CashDisbursement")
                        .WithMany()
                        .HasForeignKey("CashDisbursementCheckNumber");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.CashDisbursement", b =>
                {
                    b.HasOne("MVCAccountantv2.Models.CashAccount")
                        .WithMany()
                        .HasForeignKey("CashAccountID");

                    b.HasOne("MVCAccountantv2.Models.Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID");

                    b.HasOne("MVCAccountantv2.Models.Vendor")
                        .WithMany()
                        .HasForeignKey("VendorID");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.Customer", b =>
                {
                    b.HasOne("MVCAccountantv2.Models.Sale")
                        .WithMany()
                        .HasForeignKey("SaleInvoiceID");

                    b.HasOne("MVCAccountantv2.Models.SaleOrder")
                        .WithMany()
                        .HasForeignKey("SaleOrderSaleOrderID");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.Employee", b =>
                {
                    b.HasOne("MVCAccountantv2.Models.CashDisbursement")
                        .WithMany()
                        .HasForeignKey("CashDisbursementCheckNumber");

                    b.HasOne("MVCAccountantv2.Models.EmployeeType")
                        .WithMany()
                        .HasForeignKey("EmployeeTypeID");

                    b.HasOne("MVCAccountantv2.Models.Purchase")
                        .WithMany()
                        .HasForeignKey("PurchaseReceivingReportID");

                    b.HasOne("MVCAccountantv2.Models.Sale")
                        .WithMany()
                        .HasForeignKey("SaleInvoiceID");

                    b.HasOne("MVCAccountantv2.Models.SaleOrder")
                        .WithMany()
                        .HasForeignKey("SaleOrderSaleOrderID");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.EmployeeType", b =>
                {
                    b.HasOne("MVCAccountantv2.Models.Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeEmployeeID");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.Inventory", b =>
                {
                    b.HasOne("MVCAccountantv2.Models.InventoryComposition")
                        .WithMany()
                        .HasForeignKey("InventoryCompositionID");

                    b.HasOne("MVCAccountantv2.Models.InventoryDiameter")
                        .WithMany()
                        .HasForeignKey("InventoryDiameterID");

                    b.HasOne("MVCAccountantv2.Models.InventoryType")
                        .WithMany()
                        .HasForeignKey("InventoryTypeID");

                    b.HasOne("MVCAccountantv2.Models.OutFlow_SaleInventory")
                        .WithMany()
                        .HasForeignKey("OutFlow_SaleInventoryInvoiceID");

                    b.HasOne("MVCAccountantv2.Models.Reservation_SaleOrderInventory")
                        .WithMany()
                        .HasForeignKey("Reservation_SaleOrderInventorySaleOrderID");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.OutFlow_SaleInventory", b =>
                {
                    b.HasOne("MVCAccountantv2.Models.Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryID");

                    b.HasOne("MVCAccountantv2.Models.Sale")
                        .WithMany()
                        .HasForeignKey("SaleInvoiceID");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.Purchase", b =>
                {
                    b.HasOne("MVCAccountantv2.Models.Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID");

                    b.HasOne("MVCAccountantv2.Models.Vendor")
                        .WithMany()
                        .HasForeignKey("VendorVendorID");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.Reservation_SaleOrderInventory", b =>
                {
                    b.HasOne("MVCAccountantv2.Models.Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryID");

                    b.HasOne("MVCAccountantv2.Models.SaleOrder")
                        .WithMany()
                        .HasForeignKey("SaleOrderSaleOrderID");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.Sale", b =>
                {
                    b.HasOne("MVCAccountantv2.Models.Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID");

                    b.HasOne("MVCAccountantv2.Models.Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID");

                    b.HasOne("MVCAccountantv2.Models.OutFlow_SaleInventory")
                        .WithMany()
                        .HasForeignKey("OutFlow_SaleInventoryInvoiceID");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.SaleOrder", b =>
                {
                    b.HasOne("MVCAccountantv2.Models.Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID");

                    b.HasOne("MVCAccountantv2.Models.Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID");

                    b.HasOne("MVCAccountantv2.Models.Reservation_SaleOrderInventory")
                        .WithMany()
                        .HasForeignKey("Reservation_SaleOrderInventorySaleOrderID");
                });

            modelBuilder.Entity("MVCAccountantv2.Models.Vendor", b =>
                {
                    b.HasOne("MVCAccountantv2.Models.CashDisbursement")
                        .WithMany()
                        .HasForeignKey("CashDisbursementCheckNumber");

                    b.HasOne("MVCAccountantv2.Models.Purchase")
                        .WithMany()
                        .HasForeignKey("PurchaseReceivingReportID");
                });
        }
    }
}
