﻿// <auto-generated />
using System;
using BookAndBorrower.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookAndBorrower.Context.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookAndBorrower.Model.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BookBorrowerCode")
                        .HasColumnType("int");

                    b.Property<byte[]>("BookImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BorrowedBooks")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfCopies")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookBorrowerCode");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookAndBorrower.Model.BookBorrower", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Code"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("BorrowerId")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.ToTable("BookBorrower");
                });

            modelBuilder.Entity("BookAndBorrower.Model.Borrower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BookBorrowerCode")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookBorrowerCode");

                    b.ToTable("Borrowers");
                });

            modelBuilder.Entity("BookAndBorrower.Model.Book", b =>
                {
                    b.HasOne("BookAndBorrower.Model.BookBorrower", null)
                        .WithMany("Books")
                        .HasForeignKey("BookBorrowerCode");
                });

            modelBuilder.Entity("BookAndBorrower.Model.Borrower", b =>
                {
                    b.HasOne("BookAndBorrower.Model.BookBorrower", null)
                        .WithMany("Borrowers")
                        .HasForeignKey("BookBorrowerCode");
                });

            modelBuilder.Entity("BookAndBorrower.Model.BookBorrower", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Borrowers");
                });
#pragma warning restore 612, 618
        }
    }
}
