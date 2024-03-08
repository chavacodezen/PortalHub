using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalHub.Migrations
{
    /// <inheritdoc />
    public partial class CreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IND_LOG",
                columns: table => new
                {
                    ID_LOG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_IND1 = table.Column<int>(type: "int", nullable: false),
                    DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QUANTITY = table.Column<int>(type: "int", nullable: false),
                    EMPLOYEE_NO = table.Column<int>(type: "int", nullable: false),
                    IND_DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IND_LOG", x => x.ID_LOG);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMAIL = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    EMAIL_CONFIRMED = table.Column<bool>(type: "bit", nullable: true),
                    PASSWORD_HASH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SECURITY_STAMP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PHONE_NUMBER = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PHONE_NUMBER_CONFIRMED = table.Column<bool>(type: "bit", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true),
                    EMPLOYEE_NO = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    USER_NAME = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    COMPANY_KEY = table.Column<int>(type: "int", nullable: true),
                    DEPARTMENT_NO = table.Column<int>(type: "int", nullable: true),
                    POSITION_KEY = table.Column<int>(type: "int", nullable: true),
                    PICTURE_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IND_LOG");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
