using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GreetingCardGenerator.Data.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    ADMIN_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADMIN_NAME = table.Column<string>(nullable: false),
                    EMAIL = table.Column<string>(nullable: false),
                    PASSWORD_HASH = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.ADMIN_ID);
                });

            migrationBuilder.CreateTable(
                name: "Greetings",
                columns: table => new
                {
                    GREETING_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LETTER = table.Column<string>(nullable: false),
                    GREETING = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Greetings", x => x.GREETING_ID);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    USER_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_NAME = table.Column<string>(maxLength: 15, nullable: false),
                    EMAIL = table.Column<string>(nullable: false),
                    PASSWORD_HASH = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.USER_ID);
                });

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    TEMPLATE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IMAGE = table.Column<string>(nullable: false),
                    OCCASSION = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.TEMPLATE_ID);
                });

            migrationBuilder.CreateTable(
                name: "GreetingDrafts",
                columns: table => new
                {
                    G_DRAFT_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GREETING_TEXT = table.Column<string>(nullable: false),
                    NAME_INITS = table.Column<string>(nullable: false),
                    D_DATE = table.Column<DateTime>(nullable: false),
                    CUSTOMER_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GreetingDrafts", x => x.G_DRAFT_ID);
                    table.ForeignKey(
                        name: "FK_GreetingDrafts_Members_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "Members",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SALES_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_ID = table.Column<int>(nullable: false),
                    TEMPLATE_ID = table.Column<int>(nullable: false),
                    NAME_INITS = table.Column<string>(nullable: false),
                    GREETING_TEXT = table.Column<string>(nullable: false),
                    CARD_IMAGE = table.Column<string>(nullable: false),
                    AMOUNT = table.Column<int>(nullable: false),
                    T_DATE = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SALES_ID);
                    table.ForeignKey(
                        name: "FK_Sales_Members_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "Members",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Templates_TEMPLATE_ID",
                        column: x => x.TEMPLATE_ID,
                        principalTable: "Templates",
                        principalColumn: "TEMPLATE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Template_Drafts",
                columns: table => new
                {
                    T_DRAFT_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GREETING_TEXT = table.Column<string>(nullable: false),
                    NAME_INITS = table.Column<string>(nullable: false),
                    D_DATE = table.Column<DateTime>(nullable: false),
                    TEMPLATE_ID = table.Column<int>(nullable: false),
                    CUSTOMER_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Template_Drafts", x => x.T_DRAFT_ID);
                    table.ForeignKey(
                        name: "FK_Template_Drafts_Members_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "Members",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Template_Drafts_Templates_TEMPLATE_ID",
                        column: x => x.TEMPLATE_ID,
                        principalTable: "Templates",
                        principalColumn: "TEMPLATE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GreetingDrafts_CUSTOMER_ID",
                table: "GreetingDrafts",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CUSTOMER_ID",
                table: "Sales",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_TEMPLATE_ID",
                table: "Sales",
                column: "TEMPLATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Template_Drafts_CUSTOMER_ID",
                table: "Template_Drafts",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Template_Drafts_TEMPLATE_ID",
                table: "Template_Drafts",
                column: "TEMPLATE_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "GreetingDrafts");

            migrationBuilder.DropTable(
                name: "Greetings");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Template_Drafts");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Templates");
        }
    }
}
