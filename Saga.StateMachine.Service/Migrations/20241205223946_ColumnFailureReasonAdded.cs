using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saga.StateMachine.Service.Migrations
{
    /// <inheritdoc />
    public partial class ColumnFailureReasonAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FailureReason",
                table: "OrderState",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FailureReason",
                table: "OrderState");
        }
    }
}
