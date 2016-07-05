using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace MVCAccountantv2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerAddress1 = table.Column<string>(nullable: false),
                    CustomerAddress2 = table.Column<string>(nullable: true),
                    CustomerCity = table.Column<string>(nullable: false),
                    CustomerCreditLimit = table.Column<decimal>(nullable: false),
                    CustomerName = table.Column<string>(nullable: false),
                    CustomerPrimaryContact = table.Column<string>(nullable: true),
                    CustomerState = table.Column<string>(nullable: false),
                    CustomerTelephone = table.Column<string>(nullable: false),
                    CustomerZipcode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                });
            migrationBuilder.CreateTable(
                name: "InventoryComposition",
                columns: table => new
                {
                    InventoryCompositionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InventoryCompositionCode = table.Column<string>(nullable: true),
                    InventoryCompositionDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryComposition", x => x.InventoryCompositionID);
                });
            migrationBuilder.CreateTable(
                name: "InventoryDiameter",
                columns: table => new
                {
                    InventoryDiameterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InventoryDiameterCode = table.Column<string>(nullable: true),
                    InventoryDiameterDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryDiameter", x => x.InventoryDiameterID);
                });
            migrationBuilder.CreateTable(
                name: "InventoryType",
                columns: table => new
                {
                    InventoryTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InventoryTypeCode = table.Column<string>(nullable: true),
                    InventoryTypeDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryType", x => x.InventoryTypeID);
                });
            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRoleClaim<string>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserClaim<string>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserLogin<string>", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole<string>", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InventoryCompositionID = table.Column<int>(nullable: false),
                    InventoryDescription = table.Column<string>(nullable: false),
                    InventoryDiameterID = table.Column<int>(nullable: false),
                    InventoryListPrice = table.Column<string>(nullable: false),
                    InventoryTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryID);
                    table.ForeignKey(
                        name: "FK_Inventory_InventoryComposition_InventoryCompositionID",
                        column: x => x.InventoryCompositionID,
                        principalTable: "InventoryComposition",
                        principalColumn: "InventoryCompositionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_InventoryDiameter_InventoryDiameterID",
                        column: x => x.InventoryDiameterID,
                        principalTable: "InventoryDiameter",
                        principalColumn: "InventoryDiameterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_InventoryType_InventoryTypeID",
                        column: x => x.InventoryTypeID,
                        principalTable: "InventoryType",
                        principalColumn: "InventoryTypeID",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "CashAccount",
                columns: table => new
                {
                    CashAccountID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountDescription = table.Column<string>(nullable: true),
                    BankAccountNumber = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    CashDisbursementCheckNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashAccount", x => x.CashAccountID);
                });
            migrationBuilder.CreateTable(
                name: "CashDisbursement",
                columns: table => new
                {
                    CheckNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CashAccountID = table.Column<int>(nullable: false),
                    CashDisbursementDate = table.Column<DateTime>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    VendorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashDisbursement", x => x.CheckNumber);
                    table.ForeignKey(
                        name: "FK_CashDisbursement_CashAccount_CashAccountID",
                        column: x => x.CashAccountID,
                        principalTable: "CashAccount",
                        principalColumn: "CashAccountID",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CashDisbursementCheckNumber = table.Column<int>(nullable: true),
                    EmployeeFirstName = table.Column<string>(nullable: true),
                    EmployeeLastName = table.Column<string>(nullable: true),
                    EmployeeTypeID = table.Column<int>(nullable: false),
                    PurchaseReceivingReportID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employee_CashDisbursement_CashDisbursementCheckNumber",
                        column: x => x.CashDisbursementCheckNumber,
                        principalTable: "CashDisbursement",
                        principalColumn: "CheckNumber",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "EmployeeType",
                columns: table => new
                {
                    EmployeeTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeEmployeeID = table.Column<int>(nullable: true),
                    EmployeeTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeType", x => x.EmployeeTypeID);
                    table.ForeignKey(
                        name: "FK_EmployeeType_Employee_EmployeeEmployeeID",
                        column: x => x.EmployeeEmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    ReceivingReportID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeID = table.Column<int>(nullable: false),
                    ReceivingReportDate = table.Column<DateTime>(nullable: false),
                    ReceivingReportVendorInvoiceID = table.Column<int>(nullable: false),
                    VendorID = table.Column<string>(nullable: true),
                    VendorVendorID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.ReceivingReportID);
                    table.ForeignKey(
                        name: "FK_Purchase_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    VendorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CashDisbursementCheckNumber = table.Column<int>(nullable: true),
                    PurchaseReceivingReportID = table.Column<int>(nullable: true),
                    VendorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.VendorID);
                    table.ForeignKey(
                        name: "FK_Vendor_CashDisbursement_CashDisbursementCheckNumber",
                        column: x => x.CashDisbursementCheckNumber,
                        principalTable: "CashDisbursement",
                        principalColumn: "CheckNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendor_Purchase_PurchaseReceivingReportID",
                        column: x => x.PurchaseReceivingReportID,
                        principalTable: "Purchase",
                        principalColumn: "ReceivingReportID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");
            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName");
            migrationBuilder.AddForeignKey(
                name: "FK_CashAccount_CashDisbursement_CashDisbursementCheckNumber",
                table: "CashAccount",
                column: "CashDisbursementCheckNumber",
                principalTable: "CashDisbursement",
                principalColumn: "CheckNumber",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_CashDisbursement_Employee_EmployeeID",
                table: "CashDisbursement",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_CashDisbursement_Vendor_VendorID",
                table: "CashDisbursement",
                column: "VendorID",
                principalTable: "Vendor",
                principalColumn: "VendorID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmployeeType_EmployeeTypeID",
                table: "Employee",
                column: "EmployeeTypeID",
                principalTable: "EmployeeType",
                principalColumn: "EmployeeTypeID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Purchase_PurchaseReceivingReportID",
                table: "Employee",
                column: "PurchaseReceivingReportID",
                principalTable: "Purchase",
                principalColumn: "ReceivingReportID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Vendor_VendorVendorID",
                table: "Purchase",
                column: "VendorVendorID",
                principalTable: "Vendor",
                principalColumn: "VendorID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_CashDisbursement_CashAccount_CashAccountID", table: "CashDisbursement");
            migrationBuilder.DropForeignKey(name: "FK_Employee_CashDisbursement_CashDisbursementCheckNumber", table: "Employee");
            migrationBuilder.DropForeignKey(name: "FK_Vendor_CashDisbursement_CashDisbursementCheckNumber", table: "Vendor");
            migrationBuilder.DropForeignKey(name: "FK_EmployeeType_Employee_EmployeeEmployeeID", table: "EmployeeType");
            migrationBuilder.DropForeignKey(name: "FK_Purchase_Employee_EmployeeID", table: "Purchase");
            migrationBuilder.DropForeignKey(name: "FK_Vendor_Purchase_PurchaseReceivingReportID", table: "Vendor");
            migrationBuilder.DropTable("AspNetRoleClaims");
            migrationBuilder.DropTable("AspNetUserClaims");
            migrationBuilder.DropTable("AspNetUserLogins");
            migrationBuilder.DropTable("AspNetUserRoles");
            migrationBuilder.DropTable("Customer");
            migrationBuilder.DropTable("Inventory");
            migrationBuilder.DropTable("AspNetRoles");
            migrationBuilder.DropTable("AspNetUsers");
            migrationBuilder.DropTable("InventoryComposition");
            migrationBuilder.DropTable("InventoryDiameter");
            migrationBuilder.DropTable("InventoryType");
            migrationBuilder.DropTable("CashAccount");
            migrationBuilder.DropTable("CashDisbursement");
            migrationBuilder.DropTable("Employee");
            migrationBuilder.DropTable("EmployeeType");
            migrationBuilder.DropTable("Purchase");
            migrationBuilder.DropTable("Vendor");
        }
    }
}
