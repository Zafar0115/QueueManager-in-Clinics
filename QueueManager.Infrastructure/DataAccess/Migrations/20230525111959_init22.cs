using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueueManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_DoctorRatings_RatingId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_RatingId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "UserName",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Patients",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Patients",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Doctors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RatingId",
                table: "Doctors",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Doctors",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_RatingId",
                table: "Doctors",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_DoctorRatings_RatingId",
                table: "Doctors",
                column: "RatingId",
                principalTable: "DoctorRatings",
                principalColumn: "Id");
        }
    }
}
