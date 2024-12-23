﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saga.StateMachine.Orchestrator.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderState",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrentState = table.Column<string>(type: "text", nullable: true),
                    OrderTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CustomerEmail = table.Column<string>(type: "text", nullable: true),
                    PaymentIntentId = table.Column<string>(type: "text", nullable: true),
                    FailureReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderState", x => x.OrderId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderState");
        }
    }
}
