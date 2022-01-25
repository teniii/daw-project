using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectAPI.Migrations.Movie
{
    public partial class MigrationWithAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fan_mail_addressid",
                table: "Participants",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    street = table.Column<string>(type: "TEXT", nullable: true),
                    number = table.Column<int>(type: "INTEGER", nullable: false),
                    apartment = table.Column<string>(type: "TEXT", nullable: true),
                    city = table.Column<string>(type: "TEXT", nullable: true),
                    county = table.Column<string>(type: "TEXT", nullable: true),
                    country = table.Column<string>(type: "TEXT", nullable: true),
                    postal_code = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_fan_mail_addressid",
                table: "Participants",
                column: "fan_mail_addressid");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Address_fan_mail_addressid",
                table: "Participants",
                column: "fan_mail_addressid",
                principalTable: "Address",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Address_fan_mail_addressid",
                table: "Participants");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Participants_fan_mail_addressid",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "fan_mail_addressid",
                table: "Participants");
        }
    }
}
