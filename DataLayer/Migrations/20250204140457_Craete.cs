using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Craete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Book",
                columns: table => new
                {
                    BookNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Book", x => x.BookNumber);
                });

            migrationBuilder.CreateTable(
                name: "T_Member",
                columns: table => new
                {
                    MemberNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<bool>(type: "bit", nullable: false),
                    Addess = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Member", x => x.MemberNumber);
                });

            migrationBuilder.CreateTable(
                name: "T_Copy",
                columns: table => new
                {
                    CopyNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookNumber = table.Column<int>(type: "int", nullable: false),
                    SequenceNumber = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Copy", x => x.CopyNumber);
                    table.ForeignKey(
                        name: "FK_T_Copy_T_Book_BookNumber",
                        column: x => x.BookNumber,
                        principalTable: "T_Book",
                        principalColumn: "BookNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_Circulated",
                columns: table => new
                {
                    CirculatedID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberNumber = table.Column<int>(type: "int", nullable: false),
                    CopyNumber = table.Column<int>(type: "int", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FineAmount = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Circulated", x => x.CirculatedID);
                    table.ForeignKey(
                        name: "FK_T_Circulated_T_Copy_CopyNumber",
                        column: x => x.CopyNumber,
                        principalTable: "T_Copy",
                        principalColumn: "CopyNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_Circulated_T_Member_MemberNumber",
                        column: x => x.MemberNumber,
                        principalTable: "T_Member",
                        principalColumn: "MemberNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_Reservation",
                columns: table => new
                {
                    ReservationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberNumber = table.Column<int>(type: "int", nullable: false),
                    CopyNumber = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Reservation", x => x.ReservationID);
                    table.ForeignKey(
                        name: "FK_T_Reservation_T_Copy_CopyNumber",
                        column: x => x.CopyNumber,
                        principalTable: "T_Copy",
                        principalColumn: "CopyNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_Reservation_T_Member_MemberNumber",
                        column: x => x.MemberNumber,
                        principalTable: "T_Member",
                        principalColumn: "MemberNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Circulated_CopyNumber",
                table: "T_Circulated",
                column: "CopyNumber");

            migrationBuilder.CreateIndex(
                name: "IX_T_Circulated_MemberNumber",
                table: "T_Circulated",
                column: "MemberNumber");

            migrationBuilder.CreateIndex(
                name: "IX_T_Copy_BookNumber",
                table: "T_Copy",
                column: "BookNumber");

            migrationBuilder.CreateIndex(
                name: "IX_T_Reservation_CopyNumber",
                table: "T_Reservation",
                column: "CopyNumber");

            migrationBuilder.CreateIndex(
                name: "IX_T_Reservation_MemberNumber",
                table: "T_Reservation",
                column: "MemberNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Circulated");

            migrationBuilder.DropTable(
                name: "T_Reservation");

            migrationBuilder.DropTable(
                name: "T_Copy");

            migrationBuilder.DropTable(
                name: "T_Member");

            migrationBuilder.DropTable(
                name: "T_Book");
        }
    }
}
