using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoApp.Migrations
{
    public partial class AddStatusSeedDataToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Statuses (Name) VALUES ('To do');");
            migrationBuilder.Sql("INSERT INTO Statuses (Name) VALUES ('In Progress');");
            migrationBuilder.Sql("INSERT INTO Statuses (Name) VALUES ('Done');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
