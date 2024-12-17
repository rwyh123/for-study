using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taxi_4._0.Migrations
{
    /// <inheritdoc />
    public partial class newMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Locations_EndLocationId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Locations_StartLocationId",
                table: "Orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegDate",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<double>(
                name: "RideTime_FinalTime",
                table: "Orders",
                type: "double",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Locations_EndLocationId",
                table: "Orders",
                column: "EndLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Locations_StartLocationId",
                table: "Orders",
                column: "StartLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Locations_EndLocationId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Locations_StartLocationId",
                table: "Orders");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "RegDate",
                table: "Users",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RideTime_FinalTime",
                table: "Orders",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Locations_EndLocationId",
                table: "Orders",
                column: "EndLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Locations_StartLocationId",
                table: "Orders",
                column: "StartLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
