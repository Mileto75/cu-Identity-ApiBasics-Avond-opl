using Microsoft.EntityFrameworkCore.Migrations;

namespace cu.ApiBasics.Lesvoorbeeld.Avond.Infrastructure.Migrations
{
    public partial class AddNewUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "88a593fb-9a41-413e-a0fe-ed7d3ff369ba");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "347e3848-1e9d-407b-8a33-db4d4086aa93", "AQAAAAEAACcQAAAAEKTLRUNV4IpcjfoKQoSZkIuQDTQYkEQdo1VO6Tpz3WHEpRQ5I75Zxoa3oLYHz1r61A==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2", 0, null, "58fb9f25-8c02-47ec-a521-d803dec6bf19", "jimi.hendrix@howest.be", true, false, null, "JIMMY.HENDRIX@HOWEST.BE", "JIMMY", "AQAAAAEAACcQAAAAEJ/WYBF17g+ct+qn+9s1vdCB9mKdPVjZC/n1G3ehObz8IpH121d5RHuso18D6QWjWw==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINA", false, "jimmy" });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1, "module", "Pri", "2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "5057ed82-b366-409d-bb7b-3ceec42f8228");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b391e8cd-4f32-415f-b61b-826896939276", "AQAAAAEAACcQAAAAEJfh/KML47/VqXnui7zZy0yOx1H26Yz9R2btDoF0vpFAjvq/P6J9C13VKCLhHEn/sQ==" });
        }
    }
}
