using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InlandMarinaData.Migrations
{
    /// <inheritdoc />
    public partial class AddLeaseDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LeaseDate",
                table: "Lease",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Lease",
                keyColumn: "ID",
                keyValue: 1,
                column: "LeaseDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Lease",
                keyColumn: "ID",
                keyValue: 2,
                column: "LeaseDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Lease",
                keyColumn: "ID",
                keyValue: 3,
                column: "LeaseDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeaseDate",
                table: "Lease");
        }
    }
}
