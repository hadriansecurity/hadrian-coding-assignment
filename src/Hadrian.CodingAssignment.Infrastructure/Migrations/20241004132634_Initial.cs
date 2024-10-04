using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hadrian.CodingAssignment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "risks",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    risk_severity = table.Column<string>(type: "text", nullable: false),
                    risk_status = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    vulnerability_id = table.Column<string>(type: "text", nullable: true),
                    organization_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_risks", x => x.id);
                    table.ForeignKey(
                        name: "fk_risks_organizations_organization_id",
                        column: x => x.organization_id,
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    organization_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_organizations_organization_id",
                        column: x => x.organization_id,
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "organizations",
                columns: new[] { "id", "name" },
                values: new object[] { new Guid("19161394-fc07-4086-a581-5727cc8bfee8"), "Hadrian" });

            migrationBuilder.InsertData(
                table: "risks",
                columns: new[] { "id", "created", "organization_id", "risk_severity", "risk_status", "title", "vulnerability_id" },
                values: new object[,]
                {
                    { new Guid("2d590ae4-36e9-485e-9bc8-f42a29123f4d"), new DateTimeOffset(new DateTime(2024, 10, 4, 13, 26, 34, 47, DateTimeKind.Unspecified).AddTicks(3677), new TimeSpan(0, 0, 0, 0, 0)), new Guid("19161394-fc07-4086-a581-5727cc8bfee8"), "Low", "New", "Low severity initial risk", null },
                    { new Guid("5de2e659-4b83-4cef-b5f0-b621cf3812de"), new DateTimeOffset(new DateTime(2024, 10, 4, 13, 26, 34, 47, DateTimeKind.Unspecified).AddTicks(3683), new TimeSpan(0, 0, 0, 0, 0)), new Guid("19161394-fc07-4086-a581-5727cc8bfee8"), "Medium", "New", "Medium severity initial risk", null },
                    { new Guid("747b90aa-1013-4f19-9c0a-e567d2ff0c35"), new DateTimeOffset(new DateTime(2024, 10, 4, 13, 26, 34, 47, DateTimeKind.Unspecified).AddTicks(3685), new TimeSpan(0, 0, 0, 0, 0)), new Guid("19161394-fc07-4086-a581-5727cc8bfee8"), "High", "New", "High severity initial risk", null }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "organization_id", "password_hash", "username" },
                values: new object[] { new Guid("076dc2f8-e6dd-471b-9aa1-36418e5f7f2a"), new Guid("19161394-fc07-4086-a581-5727cc8bfee8"), "TAC1U1saMwgrjoG2", "Hadrian" });

            migrationBuilder.CreateIndex(
                name: "ix_risks_organization_id",
                table: "risks",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_organization_id",
                table: "users",
                column: "organization_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "risks");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "organizations");
        }
    }
}
