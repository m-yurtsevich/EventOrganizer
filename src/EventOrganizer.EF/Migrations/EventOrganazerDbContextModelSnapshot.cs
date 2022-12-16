﻿// <auto-generated />
using System;
using EventOrganizer.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventOrganizer.EF.Migrations
{
    [DbContext(typeof(EventOrganazerDbContext))]
    partial class EventOrganazerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EventOrganizer.Domain.Models.DialogueMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("SenderId");

                    b.ToTable("DialogueMessages");
                });

            modelBuilder.Entity("EventOrganizer.Domain.Models.EventInvolvement", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("JoiningDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("LeavingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("EventId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("EventInvolvement", (string)null);
                });

            modelBuilder.Entity("EventOrganizer.Domain.Models.EventModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2(0)");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time(0)");

                    b.Property<bool>("IsMessagingAllowed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("RecurrenceType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2(0)");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time(0)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("EventModels");

                    b.HasDiscriminator<string>("Discriminator").HasValue("EventModel");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EventOrganizer.Domain.Models.EventResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("EventResults");
                });

            modelBuilder.Entity("EventOrganizer.Domain.Models.EventTag", b =>
                {
                    b.Property<string>("Keyword")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Keyword");

                    b.ToTable("EventTags");
                });

            modelBuilder.Entity("EventOrganizer.Domain.Models.TagToEvent", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Keyword")
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("EventId", "Keyword");

                    b.HasIndex("Keyword");

                    b.ToTable("TagToEvent", (string)null);
                });

            modelBuilder.Entity("EventOrganizer.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EventOrganizer.Domain.Models.OfflineEvent", b =>
                {
                    b.HasBaseType("EventOrganizer.Domain.Models.EventModel");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("OfflineEvent");
                });

            modelBuilder.Entity("EventOrganizer.Domain.Models.OnlineEvent", b =>
                {
                    b.HasBaseType("EventOrganizer.Domain.Models.EventModel");

                    b.Property<string>("MeetingLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("OnlineEvent");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Mastery completion and presentation of the final product",
                            EndDate = new DateTime(2023, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new TimeSpan(0, 19, 0, 0, 0),
                            IsMessagingAllowed = false,
                            RecurrenceType = 0,
                            StartDate = new DateTime(2023, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new TimeSpan(0, 18, 0, 0, 0),
                            Title = "Event organizer presentation"
                        });
                });

            modelBuilder.Entity("EventOrganizer.Domain.Models.DialogueMessage", b =>
                {
                    b.HasOne("EventOrganizer.Domain.Models.EventModel", "Event")
                        .WithMany("DialogueMessages")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventOrganizer.Domain.Models.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("EventOrganizer.Domain.Models.EventInvolvement", b =>
                {
                    b.HasOne("EventOrganizer.Domain.Models.EventModel", "EventModel")
                        .WithMany("EventInvolvements")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventOrganizer.Domain.Models.User", "User")
                        .WithMany("EventInvolvements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventModel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventOrganizer.Domain.Models.EventModel", b =>
                {
                    b.HasOne("EventOrganizer.Domain.Models.User", "Owner")
                        .WithMany("CreatedEvents")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("EventOrganizer.Domain.Models.EventResult", b =>
                {
                    b.HasOne("EventOrganizer.Domain.Models.EventModel", "Event")
                        .WithMany("EventResults")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("EventOrganizer.Domain.Models.TagToEvent", b =>
                {
                    b.HasOne("EventOrganizer.Domain.Models.EventModel", "EventModel")
                        .WithMany("TagToEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventOrganizer.Domain.Models.EventTag", "EventTag")
                        .WithMany("TagToEvents")
                        .HasForeignKey("Keyword")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventModel");

                    b.Navigation("EventTag");
                });

            modelBuilder.Entity("EventOrganizer.Domain.Models.EventModel", b =>
                {
                    b.Navigation("DialogueMessages");

                    b.Navigation("EventInvolvements");

                    b.Navigation("EventResults");

                    b.Navigation("TagToEvents");
                });

            modelBuilder.Entity("EventOrganizer.Domain.Models.EventTag", b =>
                {
                    b.Navigation("TagToEvents");
                });

            modelBuilder.Entity("EventOrganizer.Domain.Models.User", b =>
                {
                    b.Navigation("CreatedEvents");

                    b.Navigation("EventInvolvements");
                });
#pragma warning restore 612, 618
        }
    }
}
