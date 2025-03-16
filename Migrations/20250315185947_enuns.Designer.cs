﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaudeIA.Data;

#nullable disable

namespace SaudeIA.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20250315185947_enuns")]
    partial class enuns
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("SaudeIA.Models.BodyModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<double>("Altura")
                        .HasColumnType("double");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("IMC")
                        .HasColumnType("double");

                    b.Property<double>("Peso")
                        .HasColumnType("double");

                    b.Property<Guid>("UserModelId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserModelId");

                    b.ToTable("Body");
                });

            modelBuilder.Entity("SaudeIA.Models.MetasModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<int>("Hour")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserModelId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserModelId");

                    b.ToTable("Metas");
                });

            modelBuilder.Entity("SaudeIA.Models.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SaudeIA.Models.BodyModel", b =>
                {
                    b.HasOne("SaudeIA.Models.UserModel", null)
                        .WithMany("Body")
                        .HasForeignKey("UserModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SaudeIA.Models.MetasModel", b =>
                {
                    b.HasOne("SaudeIA.Models.UserModel", null)
                        .WithMany("Metas")
                        .HasForeignKey("UserModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SaudeIA.Models.UserModel", b =>
                {
                    b.Navigation("Body");

                    b.Navigation("Metas");
                });
#pragma warning restore 612, 618
        }
    }
}
