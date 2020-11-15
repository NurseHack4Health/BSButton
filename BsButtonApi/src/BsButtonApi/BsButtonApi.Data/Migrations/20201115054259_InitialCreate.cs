using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BsButtonApi.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "BsReasonCode",
                schema: "dbo",
                columns: table => new
                {
                    ReasonCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReasonCodeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonCodeText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BsReasonCode", x => x.ReasonCodeId);
                });

            migrationBuilder.CreateTable(
                name: "BsSocialMediaSource",
                schema: "dbo",
                columns: table => new
                {
                    SourceCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceCodeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SourceCodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceCodeBaseUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BsSocialMediaSource", x => x.SourceCodeId);
                });

            migrationBuilder.CreateTable(
                name: "BsReason",
                schema: "dbo",
                columns: table => new
                {
                    ReasonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReasonGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReasonCodeId = table.Column<int>(type: "int", nullable: false),
                    ReasonText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BsReason", x => x.ReasonId);
                    table.ForeignKey(
                        name: "FK_BsReason_BsReasonCode_ReasonCodeId",
                        column: x => x.ReasonCodeId,
                        principalSchema: "dbo",
                        principalTable: "BsReasonCode",
                        principalColumn: "ReasonCodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BsSource",
                schema: "dbo",
                columns: table => new
                {
                    SourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SourceUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMediaSourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BsSource", x => x.SourceId);
                    table.ForeignKey(
                        name: "FK_BsSource_BsSocialMediaSource_SocialMediaSourceId",
                        column: x => x.SocialMediaSourceId,
                        principalSchema: "dbo",
                        principalTable: "BsSocialMediaSource",
                        principalColumn: "SourceCodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BsUnconfirmedReport",
                schema: "dbo",
                columns: table => new
                {
                    UnconfirmedReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReporterUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceId = table.Column<int>(type: "int", nullable: false),
                    ReportedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReasonId = table.Column<int>(type: "int", nullable: false),
                    ReportReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportedNameOfPoster = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BsUnconfirmedReport", x => x.UnconfirmedReportId);
                    table.ForeignKey(
                        name: "FK_BsUnconfirmedReport_BsReason_ReasonId",
                        column: x => x.ReasonId,
                        principalSchema: "dbo",
                        principalTable: "BsReason",
                        principalColumn: "ReasonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BsUnconfirmedReport_BsSource_SourceId",
                        column: x => x.SourceId,
                        principalSchema: "dbo",
                        principalTable: "BsSource",
                        principalColumn: "SourceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BsReason_ReasonCodeId",
                schema: "dbo",
                table: "BsReason",
                column: "ReasonCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_BsSource_SocialMediaSourceId",
                schema: "dbo",
                table: "BsSource",
                column: "SocialMediaSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_BsUnconfirmedReport_ReasonId",
                schema: "dbo",
                table: "BsUnconfirmedReport",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_BsUnconfirmedReport_SourceId",
                schema: "dbo",
                table: "BsUnconfirmedReport",
                column: "SourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BsUnconfirmedReport",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BsReason",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BsSource",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BsReasonCode",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BsSocialMediaSource",
                schema: "dbo");
        }
    }
}
