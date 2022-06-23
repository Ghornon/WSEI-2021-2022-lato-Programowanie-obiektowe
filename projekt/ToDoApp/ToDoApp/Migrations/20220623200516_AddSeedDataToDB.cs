using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoApp.Migrations
{
    public partial class AddSeedDataToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Statuses (Name) VALUES ('To do');");
            migrationBuilder.Sql("INSERT INTO Statuses (Name) VALUES ('In Progress');");
            migrationBuilder.Sql("INSERT INTO Statuses (Name) VALUES ('Done');");

            migrationBuilder.Sql("INSERT INTO Users (Login, Password, Name, Email) VALUES ('admin', 'admin', 'Admin', 'admin@gmail.com');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
