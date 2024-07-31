using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaderBoard.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoB = table.Column<bool>(type: "date", nullable: false),
                    Gender = table.Column<int>(type: "bit", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table1 => new
                {
                    Id = table1.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table1.Column<string>(type: "nvarchar(max)", nullable: true),
                    Propreties = table1.Column<string>(type: "nvarchar(max)", nullable: true),
                    Point = table1.Column<int>(type: "int", nullable: false),
                    EmployeeId = table1.Column<int>(type: "int", nullable: false),
                },
                constraints: table1 =>
                {
                    table1.PrimaryKey("PK_Achievements", x => x.Id);
                    table1.ForeignKey(
            name: "FK_Achievements_Employees_EmployeeId",
            column: x => x.EmployeeId,
            principalTable: "Employees",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Achievements");

            migrationBuilder.DropTable(
                name: "Employees");

        }
    }
}
