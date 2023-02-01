﻿// <auto-generated />
using System;
using Exchange.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Exchange.Api.Migrations
{
    [DbContext(typeof(ExchangeDb))]
    [Migration("20230201083125_user add sms,email,push allaw")]
    partial class useraddsmsemailpushallaw
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Exchange.Api.Models.Entities.Coin", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Coins");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedDate = new DateTime(2023, 2, 1, 11, 31, 24, 494, DateTimeKind.Local).AddTicks(6690),
                            IsActive = true,
                            Name = "Bitcoin",
                            Price = 500000m,
                            ShortName = "btc"
                        });
                });

            modelBuilder.Entity("Exchange.Api.Models.Entities.NotificationTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("NotificationTemplates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 2, 1, 11, 31, 24, 494, DateTimeKind.Local).AddTicks(9860),
                            Description = "Talimat işlemi tamamlanınca gönderilir",
                            IsActive = true,
                            Name = "InstructionCompleteEmail",
                            TemplateText = "Sayın {0} <br> {1} nolu talimatınız alınmıştır.",
                            TemplateTitle = "Talimatınız alındı",
                            Type = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 2, 1, 11, 31, 24, 494, DateTimeKind.Local).AddTicks(9960),
                            Description = "Talimat işlemi tamamlanınca gönderilir",
                            IsActive = true,
                            Name = "InstructionCompleteSms",
                            TemplateText = "Sayın {0} <br> {1} nolu talimatınız alınmıştır.",
                            TemplateTitle = "Talimatınız alındı",
                            Type = 2
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 2, 1, 11, 31, 24, 494, DateTimeKind.Local).AddTicks(9980),
                            Description = "Talimat işlemi tamamlanınca gönderilir",
                            IsActive = true,
                            Name = "InstructionCompletePush",
                            TemplateText = "Sayın {0} <br> {1} nolu talimatınız alınmıştır.",
                            TemplateTitle = "Talimatınız alındı",
                            Type = 3
                        });
                });

            modelBuilder.Entity("Exchange.Api.Models.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeviceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("EmailAllow")
                        .HasColumnType("bit");

                    b.Property<int>("EndOfInstructionDay")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal>("MaxInstructionAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MinInstructionAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NameSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("PushAllow")
                        .HasColumnType("bit");

                    b.Property<bool?>("SmsAllow")
                        .HasColumnType("bit");

                    b.Property<int>("StartOfInstructionDay")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedDate = new DateTime(2023, 2, 1, 11, 31, 24, 494, DateTimeKind.Local).AddTicks(8950),
                            DeviceId = "26FB1AB0CA8483866",
                            Email = "ksksertac@gmail.com",
                            EmailAllow = true,
                            EndOfInstructionDay = 28,
                            IsActive = true,
                            MaxInstructionAmount = 20000m,
                            MinInstructionAmount = 100m,
                            NameSurname = "Test User",
                            Password = "26FB1AB0CA8483866F03CA66E2018B0685F3E1E84CACA77B3F5643AE799D9EB4",
                            Phone = "5079144614",
                            PushAllow = true,
                            SmsAllow = false,
                            StartOfInstructionDay = 1
                        });
                });

            modelBuilder.Entity("Exchange.Api.Models.Instruction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("CoinId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("EmailAllow")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("EmailDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("PushAllow")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("PushDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PushMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("SmsAllow")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("SmsDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SmsMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CoinId");

                    b.HasIndex("UserId");

                    b.ToTable("Instructions");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Amount = 500m,
                            CoinId = 1L,
                            CreatedDate = new DateTime(2023, 2, 1, 11, 31, 24, 495, DateTimeKind.Local).AddTicks(340),
                            EmailAllow = true,
                            PushAllow = true,
                            SmsAllow = true,
                            Status = 2,
                            UserId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            Amount = 200m,
                            CoinId = 1L,
                            CreatedDate = new DateTime(2023, 2, 1, 11, 31, 24, 495, DateTimeKind.Local).AddTicks(740),
                            EmailAllow = true,
                            PushAllow = true,
                            SmsAllow = true,
                            Status = 2,
                            UserId = 1L
                        });
                });

            modelBuilder.Entity("Exchange.Api.Models.Instruction", b =>
                {
                    b.HasOne("Exchange.Api.Models.Entities.Coin", "Coin")
                        .WithMany()
                        .HasForeignKey("CoinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Exchange.Api.Models.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coin");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
