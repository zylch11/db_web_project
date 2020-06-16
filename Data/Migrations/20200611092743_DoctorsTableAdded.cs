using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace db_web_project.Data.Migrations
{
    public partial class DoctorsTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Qualification = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    CNIC = table.Column<int>(nullable: false),
                    HospitalId = table.Column<int>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
