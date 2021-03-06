﻿using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace TV_App.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class FixNotificationConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Emissions_emission_id",
                table: "Notifications");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Emissions_emission_id",
                table: "Notifications",
                column: "emission_id",
                principalTable: "Emissions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Emissions_emission_id",
                table: "Notifications");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Emissions_emission_id",
                table: "Notifications",
                column: "emission_id",
                principalTable: "Emissions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
