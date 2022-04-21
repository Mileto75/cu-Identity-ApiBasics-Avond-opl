using Microsoft.EntityFrameworkCore.Migrations;

namespace cu.ApiBasics.Lesvoorbeeld.Avond.Infrastructure.Migrations
{
    public partial class removeCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c3c4b851-2282-49fd-b26a-0205c3599f06");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "34bce657-c179-4d43-9869-ca30871725a2", "AQAAAAEAACcQAAAAEJ62g2GsZJscP8qNkW4gKhPoMJaQAynmHJyrXtPEh2rXSC2onqa02TfpcrbA55pAfw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e48bbe1b-f3d5-4161-b54f-ee03de24acd6", "AQAAAAEAACcQAAAAEI1ebiEdWUQVODBHckwZIgjNi35pVUIQPTiHOHZBKnaGeRF6gyox+gygGAgAPAqsDA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "58fb9f25-8c02-47ec-a521-d803dec6bf19", "AQAAAAEAACcQAAAAEJ/WYBF17g+ct+qn+9s1vdCB9mKdPVjZC/n1G3ehObz8IpH121d5RHuso18D6QWjWw==" });
        }
    }
}
