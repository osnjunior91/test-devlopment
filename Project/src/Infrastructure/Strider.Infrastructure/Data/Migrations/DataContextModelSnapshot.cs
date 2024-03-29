﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Strider.Infrastructure.Data.Context;

namespace Strider.Infrastructure.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Strider.Infrastructure.Data.Model.Followers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FollowerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FollowerId");

                    b.HasIndex("UserId");

                    b.ToTable("Followers");
                });

            modelBuilder.Entity("Strider.Infrastructure.Data.Model.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<Guid?>("RepostedFromId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RepostedFromId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Strider.Infrastructure.Data.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Joined")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7a045dcd-1381-4b7f-8007-e30c096ec1a7"),
                            CreatedAt = new DateTime(2022, 4, 17, 11, 2, 58, 275, DateTimeKind.Local).AddTicks(871),
                            IsDelete = false,
                            Joined = new DateTime(2022, 4, 17, 11, 2, 58, 276, DateTimeKind.Local).AddTicks(2374),
                            Username = "User01"
                        },
                        new
                        {
                            Id = new Guid("f15c54ee-0343-4cec-a751-70b97359c442"),
                            CreatedAt = new DateTime(2022, 4, 17, 11, 2, 58, 276, DateTimeKind.Local).AddTicks(2776),
                            IsDelete = false,
                            Joined = new DateTime(2022, 4, 17, 11, 2, 58, 276, DateTimeKind.Local).AddTicks(2781),
                            Username = "User02"
                        },
                        new
                        {
                            Id = new Guid("257863a5-c106-44dd-ab19-5a82ba4974b0"),
                            CreatedAt = new DateTime(2022, 4, 17, 11, 2, 58, 276, DateTimeKind.Local).AddTicks(2784),
                            IsDelete = false,
                            Joined = new DateTime(2022, 4, 17, 11, 2, 58, 276, DateTimeKind.Local).AddTicks(2785),
                            Username = "User03"
                        });
                });

            modelBuilder.Entity("Strider.Infrastructure.Data.Model.Followers", b =>
                {
                    b.HasOne("Strider.Infrastructure.Data.Model.User", "Follower")
                        .WithMany()
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Strider.Infrastructure.Data.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Follower");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Strider.Infrastructure.Data.Model.Post", b =>
                {
                    b.HasOne("Strider.Infrastructure.Data.Model.Post", "RepostedFrom")
                        .WithMany()
                        .HasForeignKey("RepostedFromId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Strider.Infrastructure.Data.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RepostedFrom");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
