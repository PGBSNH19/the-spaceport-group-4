using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePort.Migrations
{
    public partial class UpdatePropertiesName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Ticket_TicketID",
                table: "Receipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Receipt");

            migrationBuilder.AddColumn<int>(
                name: "TicketID",
                table: "Ticket",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ReceiptID",
                table: "Receipt",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "TicketID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt",
                column: "ReceiptID");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Ticket_TicketID",
                table: "Receipt",
                column: "TicketID",
                principalTable: "Ticket",
                principalColumn: "TicketID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Ticket_TicketID",
                table: "Receipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt");

            migrationBuilder.DropColumn(
                name: "TicketID",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "ReceiptID",
                table: "Receipt");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Receipt",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Ticket_TicketID",
                table: "Receipt",
                column: "TicketID",
                principalTable: "Ticket",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
