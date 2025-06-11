using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WsPayBillsInfraestructure.Migrations
{
    /// <inheritdoc />
    public partial class PRUEBA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnterpriseTypes",
                columns: table => new
                {
                    etyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    etyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterpriseTypes", x => x.etyId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    rolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.rolId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    staId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    staName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.staId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    usrId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usrName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usrLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usrAddres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usrEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usrCelPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rolId = table.Column<int>(type: "int", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.usrId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_rolId",
                        column: x => x.rolId,
                        principalTable: "Roles",
                        principalColumn: "rolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    bilId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bilName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bilDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bilNumber = table.Column<int>(type: "int", nullable: false),
                    bilContract = table.Column<int>(type: "int", nullable: false),
                    bilValuePay = table.Column<float>(type: "real", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.bilId);
                    table.ForeignKey(
                        name: "FK_Bills_Status_State",
                        column: x => x.State,
                        principalTable: "Status",
                        principalColumn: "staId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enterprises",
                columns: table => new
                {
                    entId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    entName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    etyId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enterprises", x => x.entId);
                    table.ForeignKey(
                        name: "FK_Enterprises_EnterpriseTypes_etyId",
                        column: x => x.etyId,
                        principalTable: "EnterpriseTypes",
                        principalColumn: "etyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enterprises_Status_State",
                        column: x => x.State,
                        principalTable: "Status",
                        principalColumn: "staId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    docId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usrId = table.Column<int>(type: "int", nullable: false),
                    bilId = table.Column<int>(type: "int", nullable: false),
                    docUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.docId);
                    table.ForeignKey(
                        name: "FK_Documents_Bills_bilId",
                        column: x => x.bilId,
                        principalTable: "Bills",
                        principalColumn: "bilId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_Users_usrId",
                        column: x => x.usrId,
                        principalTable: "Users",
                        principalColumn: "usrId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    trnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usrId = table.Column<int>(type: "int", nullable: false),
                    bilId = table.Column<int>(type: "int", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.trnId);
                    table.ForeignKey(
                        name: "FK_Transactions_Bills_bilId",
                        column: x => x.bilId,
                        principalTable: "Bills",
                        principalColumn: "bilId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_usrId",
                        column: x => x.usrId,
                        principalTable: "Users",
                        principalColumn: "usrId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_State",
                table: "Bills",
                column: "State");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_bilId",
                table: "Documents",
                column: "bilId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_usrId",
                table: "Documents",
                column: "usrId");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_etyId",
                table: "Enterprises",
                column: "etyId");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_State",
                table: "Enterprises",
                column: "State");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_bilId",
                table: "Transactions",
                column: "bilId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_usrId",
                table: "Transactions",
                column: "usrId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_rolId",
                table: "Users",
                column: "rolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Enterprises");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "EnterpriseTypes");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
