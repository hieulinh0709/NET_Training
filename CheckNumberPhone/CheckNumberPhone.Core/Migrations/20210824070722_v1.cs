using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckNumberPhone.Core.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "varchar(10)", nullable: true),
                    Network = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Network", "Number" },
                values: new object[,]
                {
                    { 1, "Viettel", "0861975619" },
                    { 2, "Viettel", "0975375619" },
                    { 3, "Mobi", "0894375619" },
                    { 4, "VinaPhone", "0917775619" },
                    { 5, "Viettel", "0337578949" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phones");
        }
    }
}
