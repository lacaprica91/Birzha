﻿// <auto-generated />
using BirzhaApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BirzhaApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171227173704_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BirzhaApp.Models.Company", b =>
                {
                    b.Property<int>("CompanyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("City");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("Name");

                    b.Property<int>("OwnerId");

                    b.Property<string>("Phone");

                    b.Property<string>("Postcode");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("CompanyID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("BirzhaApp.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyId");

                    b.Property<string>("JobDescription");

                    b.Property<string>("JobIndustry");

                    b.Property<string>("JobLocation");

                    b.Property<string>("JobTitle");

                    b.Property<int>("JobTypeId");

                    b.HasKey("JobId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("BirzhaApp.Models.JobType", b =>
                {
                    b.Property<int>("JobTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("JobTypeName");

                    b.HasKey("JobTypeId");

                    b.ToTable("JobTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
