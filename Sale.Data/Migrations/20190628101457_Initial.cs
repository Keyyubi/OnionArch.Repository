using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sale.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseEntity",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 6, 28, 13, 14, 57, 222, DateTimeKind.Local).AddTicks(9440)),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 6, 28, 13, 14, 57, 224, DateTimeKind.Local).AddTicks(4885)),
                    AddedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    UserId = table.Column<long>(nullable: true),
                    SaleId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Stock = table.Column<int>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    CategoryId = table.Column<long>(nullable: true),
                    Sale_UserId = table.Column<int>(nullable: true),
                    UserFullname = table.Column<string>(nullable: true),
                    TotalPrice = table.Column<decimal>(nullable: true),
                    PaymentType = table.Column<int>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Fullname = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    IsAuthenticate = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartProducts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CartId = table.Column<long>(nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    OnCartAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProducts", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_CategoryId",
                table: "BaseEntity",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseEntity");

            migrationBuilder.DropTable(
                name: "CartProducts");
        }
    }
}
