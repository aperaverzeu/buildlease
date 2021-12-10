using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Buildlease.Migrations
{
    public partial class OrderDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FinishDate",
                table: "Order",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Order",
                type: "timestamp without time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinishDate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Order");
        }
    }
}
