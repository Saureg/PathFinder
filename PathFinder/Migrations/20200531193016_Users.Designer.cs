﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PathFinder.Data;

namespace PathFinder.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200531193016_Users")]
    partial class Users
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("PathFinder.Data.Models.Alignment.Alignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Alignments");
                });

            modelBuilder.Entity("PathFinder.Data.Models.CharClass.CharClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("HitDice")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CharClasses");
                });

            modelBuilder.Entity("PathFinder.Data.Models.CharClass.ClassAlignment", b =>
                {
                    b.Property<int>("CharClassId")
                        .HasColumnType("integer");

                    b.Property<int>("AlignmentId")
                        .HasColumnType("integer");

                    b.HasKey("CharClassId", "AlignmentId");

                    b.HasIndex("AlignmentId");

                    b.ToTable("ClassAlignment");
                });

            modelBuilder.Entity("PathFinder.Data.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<int>("Cha")
                        .HasColumnType("integer");

                    b.Property<int>("ChaMod")
                        .HasColumnType("integer");

                    b.Property<int>("CharClassId")
                        .HasColumnType("integer");

                    b.Property<int>("Con")
                        .HasColumnType("integer");

                    b.Property<int>("ConMod")
                        .HasColumnType("integer");

                    b.Property<int>("Dex")
                        .HasColumnType("integer");

                    b.Property<int>("DexMod")
                        .HasColumnType("integer");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Int")
                        .HasColumnType("integer");

                    b.Property<int>("IntMod")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<int>("RaceId")
                        .HasColumnType("integer");

                    b.Property<int>("Str")
                        .HasColumnType("integer");

                    b.Property<int>("StrMod")
                        .HasColumnType("integer");

                    b.Property<int>("Wis")
                        .HasColumnType("integer");

                    b.Property<int>("WisMod")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CharClassId");

                    b.HasIndex("RaceId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("PathFinder.Data.Models.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AnyTrait")
                        .HasColumnType("integer");

                    b.Property<int>("ChaTrait")
                        .HasColumnType("integer");

                    b.Property<int>("ConTrait")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("DexTrait")
                        .HasColumnType("integer");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<int>("IntTrait")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<int>("StrTrait")
                        .HasColumnType("integer");

                    b.Property<int>("WisTrait")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("PathFinder.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PathFinder.Data.Models.CharClass.ClassAlignment", b =>
                {
                    b.HasOne("PathFinder.Data.Models.Alignment.Alignment", "Alignment")
                        .WithMany("ClassAlignments")
                        .HasForeignKey("AlignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PathFinder.Data.Models.CharClass.CharClass", "CharClass")
                        .WithMany("ClassAlignments")
                        .HasForeignKey("CharClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PathFinder.Data.Models.Character", b =>
                {
                    b.HasOne("PathFinder.Data.Models.CharClass.CharClass", "CharClass")
                        .WithMany()
                        .HasForeignKey("CharClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PathFinder.Data.Models.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
