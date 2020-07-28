using Microsoft.EntityFrameworkCore.Migrations;

namespace Commander.Database.Migrations
{
  public partial class InitialMigration : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "commands",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false),
            HowTo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            Platform = table.Column<string>(type: "nvarchar(max)", nullable: false),
            Line = table.Column<string>(type: "nvarchar(max)", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_commands", x => x.Id);
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "commands");
    }
  }
}
