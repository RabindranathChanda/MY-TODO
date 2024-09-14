using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTodos.Migrations
{
    /// <inheritdoc />
    public partial class FirstAttempttoMigrateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Todo",
                columns: table => new
                {
                    TodoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TodoName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    TodoDesc = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    TodoCreateDate = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    TodoTargetDate = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todo", x => x.TodoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todo");
        }
    }
}
