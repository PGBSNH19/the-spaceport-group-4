using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePort.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Ticket_TicketID",
                table: "Receipt");

            migrationBuilder.DropIndex(
                name: "IX_Receipt_TicketID",
                table: "Receipt");

            migrationBuilder.DropColumn(
                name: "TicketID",
                table: "Receipt");

            migrationBuilder.AddColumn<int>(
                name: "TicketRef",
                table: "Receipt",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_TicketRef",
                table: "Receipt",
                column: "TicketRef",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Ticket_TicketRef",
                table: "Receipt",
                column: "TicketRef",
                principalTable: "Ticket",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Ticket_TicketRef",
                table: "Receipt");

            migrationBuilder.DropIndex(
                name: "IX_Receipt_TicketRef",
                table: "Receipt");

            migrationBuilder.DropColumn(
                name: "TicketRef",
                table: "Receipt");

            migrationBuilder.AddColumn<int>(
                name: "TicketID",
                table: "Receipt",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_TicketID",
                table: "Receipt",
                column: "TicketID",
                unique: true);

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
