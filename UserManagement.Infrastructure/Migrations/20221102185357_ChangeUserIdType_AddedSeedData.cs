using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Infrastructure.Migrations
{
    public partial class ChangeUserIdType_AddedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserId",
                table: "Users");
            
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                    name: "Id",
                    table: "Users",
                    type: "int",
                    nullable: false,
                    defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserId",
                table: "Users",
                column: "Id");
            
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastModified", "LastName", "MiddleName" },
                values: new object[] { 1, null, "Billy", new DateTime(2022, 11, 2, 11, 53, 57, 545, DateTimeKind.Local).AddTicks(5464), "Joe", "Bob" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
