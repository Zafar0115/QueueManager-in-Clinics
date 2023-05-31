using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueueManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorRatings_Doctors_DoctorId",
                table: "DoctorRatings");

            migrationBuilder.DropIndex(
                name: "IX_DoctorRatings_DoctorId",
                table: "DoctorRatings");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "DoctorRatings");

            migrationBuilder.AddColumn<Guid>(
                name: "RatingIdId",
                table: "Doctors",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_RatingIdId",
                table: "Doctors",
                column: "RatingIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_DoctorRatings_RatingIdId",
                table: "Doctors",
                column: "RatingIdId",
                principalTable: "DoctorRatings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_DoctorRatings_RatingIdId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_RatingIdId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "RatingIdId",
                table: "Doctors");

            migrationBuilder.AddColumn<Guid>(
                name: "DoctorId",
                table: "DoctorRatings",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorRatings_DoctorId",
                table: "DoctorRatings",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorRatings_Doctors_DoctorId",
                table: "DoctorRatings",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId");
        }
    }
}
