using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class userregister : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Travels_TravelId",
                table: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_Travels_TravelId",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "TravelId",
                table: "Travels");

            migrationBuilder.CreateTable(
                name: "UsersRegistered",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRegistered", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersRegistered");

            migrationBuilder.AddColumn<int>(
                name: "TravelId",
                table: "Travels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Travels_TravelId",
                table: "Travels",
                column: "TravelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Travels_TravelId",
                table: "Travels",
                column: "TravelId",
                principalTable: "Travels",
                principalColumn: "Id");
        }
    }
}
