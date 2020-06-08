using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Image = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Image = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Whatsapp = table.Column<string>(nullable: false),
                    Latitude = table.Column<decimal>(nullable: false),
                    Longitude = table.Column<decimal>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Uf = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Point_Item",
                columns: table => new
                {
                    Point_Id = table.Column<int>(nullable: false),
                    Item_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Point_Item", x => new { x.Point_Id, x.Item_Id });
                    table.ForeignKey(
                        name: "FK_Point_Item_Items_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Point_Item_Points_Point_Id",
                        column: x => x.Point_Id,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Image", "Title" },
                values: new object[] { 1, "lampadas.svg", "Lâmpadas" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Image", "Title" },
                values: new object[] { 2, "baterias.svg", "Pilhas e Baterias" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Image", "Title" },
                values: new object[] { 3, "papeis-papelao.svg", "Papéis e Papelão" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Image", "Title" },
                values: new object[] { 4, "eletronicos.svg", "Resíduos Eletrônicos" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Image", "Title" },
                values: new object[] { 5, "organicos.svg", "Resíduos Orgânicos" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Image", "Title" },
                values: new object[] { 6, "oleo.svg", "Óleo de Cozinha" });

            migrationBuilder.CreateIndex(
                name: "IX_Point_Item_Item_Id",
                table: "Point_Item",
                column: "Item_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Point_Item");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Points");
        }
    }
}
