using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_1.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User_Master_Table_1",
                columns: table => new
                {
                    User_MasterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_MasterFName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_MasterSName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_MasterEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Master_MO_BO = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Master_Table_1s", x => x.User_MasterID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Master_Table_1");
        }
    }
}
