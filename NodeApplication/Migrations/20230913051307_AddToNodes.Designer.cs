﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodeApplication.Data;

#nullable disable

namespace NodeApplication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230913051307_AddToNodes")]
    partial class AddToNodes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("NodeApplication.Models.Node", b =>
                {
                    b.Property<int>("NodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("NodeId1")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NodeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ParentNodeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("NodeId");

                    b.HasIndex("NodeId1");

                    b.ToTable("nodes");
                });

            modelBuilder.Entity("NodeApplication.Models.Node", b =>
                {
                    b.HasOne("NodeApplication.Models.Node", null)
                        .WithMany("Children")
                        .HasForeignKey("NodeId1");
                });

            modelBuilder.Entity("NodeApplication.Models.Node", b =>
                {
                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}