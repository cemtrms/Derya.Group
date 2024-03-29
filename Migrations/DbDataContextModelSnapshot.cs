﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebsiteManagerPanel.Data.Context;

namespace WebsiteManagerPanel.Migrations
{
    [DbContext(typeof(DbDataContext))]
    partial class DbDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("WebsiteManagerPanel.Data.Entities.Definition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("CreateUserId")
                        .HasColumnType("int")
                        .HasColumnName("CreatedBy");

                    b.Property<string>("Description")
                        .HasMaxLength(8000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifyUserId")
                        .HasColumnType("int")
                        .HasColumnName("ModifiedBy");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("SiteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreateUserId");

                    b.HasIndex("ModifyUserId");

                    b.HasIndex("SiteId");

                    b.ToTable("Definitions");
                });

            modelBuilder.Entity("WebsiteManagerPanel.Data.Entities.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("CreateUserId")
                        .HasColumnType("int")
                        .HasColumnName("CreatedBy");

                    b.Property<int>("DefinitionId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(8000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifyUserId")
                        .HasColumnType("int")
                        .HasColumnName("ModifiedBy");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreateUserId");

                    b.HasIndex("DefinitionId");

                    b.HasIndex("ModifyUserId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("WebsiteManagerPanel.Data.Entities.FieldItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserId")
                        .HasColumnType("int");

                    b.Property<int>("FieldValueId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifyUserId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreateUserId");

                    b.HasIndex("FieldValueId");

                    b.HasIndex("ModifyUserId");

                    b.ToTable("FieldItem");
                });

            modelBuilder.Entity("WebsiteManagerPanel.Data.Entities.FieldValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserId")
                        .HasColumnType("int");

                    b.Property<int>("FieldId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifyUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreateUserId");

                    b.HasIndex("FieldId");

                    b.HasIndex("ModifyUserId");

                    b.ToTable("FieldValue");
                });

            modelBuilder.Entity("WebsiteManagerPanel.Data.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<long?>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("WebsiteManagerPanel.Data.Entities.RoleGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("RoleGroup");
                });

            modelBuilder.Entity("WebsiteManagerPanel.Data.Entities.Site", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("CreateUserId")
                        .HasColumnType("int")
                        .HasColumnName("CreatedBy");

                    b.Property<string>("Description")
                        .HasMaxLength(8000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifyUserId")
                        .HasColumnType("int")
                        .HasColumnName("ModifiedBy");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreateUserId");

                    b.HasIndex("ModifyUserId");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("WebsiteManagerPanel.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebsiteManagerPanel.Data.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("RoleGroupId")
                        .HasColumnType("int");

                    b.Property<long?>("Roles")
                        .HasColumnType("bigint");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleGroupId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("WebsiteManagerPanel.Data.Entities.Definition", b =>
                {
                    b.HasOne("WebsiteManagerPanel.Data.Entities.User", "CreateUser")
                        .WithMany()
                        .HasForeignKey("CreateUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebsiteManagerPanel.Data.Entities.User", "ModifyUser")
                        .WithMany()
                        .HasForeignKey("ModifyUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebsiteManagerPanel.Data.Entities.Site", "Site")
                        .WithMany("Definitions")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreateUser");

                    b.Navigation("ModifyUser");

                    b.Navigation("Site");
                });

            modelBuilder.Entity("WebsiteManagerPanel.Data.Entities.Field", b =>
                {
                    b.HasOne("WebsiteManagerPanel.Data.Entities.User", "CreateUser")
                        .WithMany()
                        .HasForeignKey("CreateUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebsiteManagerPanel.Data.Entities.Definition", "Definition")
                        .WithMany("Fields")
                        .HasForeignKey("DefinitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebsiteManagerPanel.Data.Entities.User", "ModifyUser")
                        .WithMany()
                        .HasForeignKey("ModifyUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CreateUser");

                    b.Navigation("Definition");

                    b.Navigation("ModifyUser");
                });

            modelBuilder.Entity("WebsiteManagerPanel.Data.Entities.FieldItem", b =>
                {
                    b.HasOne("WebsiteManagerPanel.Data.Entities.User", "CreateUser")
                        .WithMany()
                        .HasForeignKey("CreateUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebsiteManagerPanel.Data.Entities.FieldValue", "FieldValue")
                        .WithMany("Items")
                        .HasForeignKey("FieldValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebsiteManagerPanel.Data.Entities.User", "ModifyUser")
                        .WithMany()
                        .HasForeignKey("ModifyUserId");

                    b.Navigation("CreateUser");

                    b.Navigation("FieldValue");

                    b.Navigation("ModifyUser");
                });

            modelBuilder.Entity("WebsiteManagerPanel.Data.Entities.FieldValue", b =>
                {
                    b.HasOne("WebsiteManagerPanel.Data.Entities.User", "CreateUser")
                        .WithMany()
                        .HasForeignKey("CreateUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebsiteManagerPanel.Data.Entities.Field", "Field")
                        .WithMany("FieldValues")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebsiteManagerPanel.Data.Entities.User", "ModifyUser")
                        .WithMany()
                        .HasForeignKey("ModifyUserId");

                    b.Navigation("CreateUser");

                    b.Navigation("Field");

                    b.Navigation("ModifyUser");
                });

            modelBuilder.Entity("WebsiteManagerPanel.Data.Entities.Role", b =>
                {
                    b.HasOne("WebsiteManagerPanel.Data.Entities.RoleGroup", "Group")
                        .WithMany("Roles")
                        .HasForeignKey("GroupId");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("WebsiteManagerPanel.Data.Entities.Site", b =>
                {
                    b.HasOne("WebsiteManagerPanel.Data.Entities.User", "CreateUser")
                        .WithMany()
                        .HasForeignKey("CreateUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebsiteManagerPanel.Data.Entities.User", "ModifyUser")
                        .WithMany()
                        .HasForeignKey("ModifyUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CreateUser");

                    b.Navigation("ModifyUser");
                });

            modelBuilder.Entity("WebsiteManagerPanel.Data.Entities.UserRole", b =>
                {
                    b.HasOne("WebsiteManagerPanel.Data.Entities.RoleGroup", "RoleGroup")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebsiteManagerPanel.Data.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId");

                    b.Navigation("RoleGroup");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebsiteManagerPanel.Data.Entities.Definition", b =>
                {
                    b.Navigation("Fields");
                });

            modelBuilder.Entity("WebsiteManagerPanel.Data.Entities.Field", b =>
                {
                    b.Navigation("FieldValues");
                });

            modelBuilder.Entity("WebsiteManagerPanel.Data.Entities.FieldValue", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("WebsiteManagerPanel.Data.Entities.RoleGroup", b =>
                {
                    b.Navigation("Roles");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("WebsiteManagerPanel.Data.Entities.Site", b =>
                {
                    b.Navigation("Definitions");
                });

            modelBuilder.Entity("WebsiteManagerPanel.Data.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
