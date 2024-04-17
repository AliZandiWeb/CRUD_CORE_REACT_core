﻿// <auto-generated />
using ASPNetServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASPNetServer.Data.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("ASPNetServer.Data.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(100000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "This is post1 and it has some very interesting content.",
                            Title = "Post 1"
                        },
                        new
                        {
                            Id = 2,
                            Content = "This is post2 and it has some very interesting content.",
                            Title = "Post 2"
                        },
                        new
                        {
                            Id = 3,
                            Content = "This is post3 and it has some very interesting content.",
                            Title = "Post 3"
                        },
                        new
                        {
                            Id = 4,
                            Content = "This is post4 and it has some very interesting content.",
                            Title = "Post 4"
                        },
                        new
                        {
                            Id = 5,
                            Content = "This is post5 and it has some very interesting content.",
                            Title = "Post 5"
                        },
                        new
                        {
                            Id = 6,
                            Content = "This is post6 and it has some very interesting content.",
                            Title = "Post 6"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
