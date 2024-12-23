﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Saga.StateMachine.Orchestrator.SagaDatabaseContext;

#nullable disable

namespace Saga.StateMachine.Orchestrator.Migrations
{
    [DbContext(typeof(OrderSagaDbContext))]
    partial class OrderSagaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Saga.StateMachine.Orchestrator.SagaStateMachine.OrderState", b =>
                {
                    b.Property<Guid>("CorrelationId")
                        .HasColumnType("uuid")
                        .HasColumnName("OrderId");

                    b.Property<string>("CurrentState")
                        .HasColumnType("text");

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("text");

                    b.Property<string>("FailureReason")
                        .HasColumnType("text");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("OrderTotal")
                        .HasColumnType("numeric");

                    b.Property<string>("PaymentIntentId")
                        .HasColumnType("text");

                    b.HasKey("CorrelationId");

                    b.ToTable("OrderState");
                });
#pragma warning restore 612, 618
        }
    }
}
