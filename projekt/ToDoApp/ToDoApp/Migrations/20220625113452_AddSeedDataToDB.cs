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

            migrationBuilder.Sql("INSERT INTO tasks (Name, Date, StatusId, UserId) VALUES ('My first task', '2021-06-25', 1, 1);");
            migrationBuilder.Sql("INSERT INTO tasks (Name, Date, StatusId, UserId) VALUES ('My task', '2021-06-23', 2, 1);");

            migrationBuilder.Sql("INSERT INTO Tags (Name, UserId) VALUES ('Work', 1);");
            migrationBuilder.Sql("INSERT INTO Tags (Name, UserId) VALUES ('Home', 1);");

            migrationBuilder.Sql("INSERT INTO TaggedTasks (TaskId, TagId) VALUES (1, 1);");
            migrationBuilder.Sql("INSERT INTO TaggedTasks (TaskId, TagId) VALUES (1, 2);");
            migrationBuilder.Sql("INSERT INTO TaggedTasks (TaskId, TagId) VALUES (2, 2);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
