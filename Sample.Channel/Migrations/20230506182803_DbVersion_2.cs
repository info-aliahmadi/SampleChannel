using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sample.Channel.Migrations
{
    /// <inheritdoc />
    public partial class DbVersion_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Org",
                schema: "Notification",
                table: "Org");

            migrationBuilder.EnsureSchema(
                name: "Org");

            migrationBuilder.RenameTable(
                name: "Org",
                schema: "Notification",
                newName: "Notification",
                newSchema: "Org");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notification",
                schema: "Org",
                table: "Notification",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Notification",
                schema: "Org",
                table: "Notification");

            migrationBuilder.EnsureSchema(
                name: "Notification");

            migrationBuilder.RenameTable(
                name: "Notification",
                schema: "Org",
                newName: "Org",
                newSchema: "Notification");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Org",
                schema: "Notification",
                table: "Org",
                column: "Id");
        }
    }
}
