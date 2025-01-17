﻿// <auto-generated />
using System;
using LLPTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LLPTest.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LLPTest.Data.Blogs.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("LLPTest.Data.Blogs.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("LLPTest.Data.Blogs.BlogImage", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BlogImage");
                });

            modelBuilder.Entity("LLPTest.Data.Blogs.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("LLPTest.Data.Customers.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("LLPTest.Data.Customers.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("LLPTest.Data.Customers.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("LLPTest.Data.Customers.CustomerRetailerSite", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RetailerSiteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("CustomerId", "RetailerSiteId");

                    b.HasIndex("RetailerSiteId");

                    b.ToTable("CustomerRetailerSite");
                });

            modelBuilder.Entity("LLPTest.Data.Customers.Gender", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("LLPTest.Data.Retailers.Area", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("LLPTest.Data.Retailers.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("LLPTest.Data.Retailers.Market", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Market");
                });

            modelBuilder.Entity("LLPTest.Data.Retailers.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MarketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("MarketId");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("LLPTest.Data.Retailers.Retailer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AreaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid>("RetailerGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("RetailerGroupId");

                    b.ToTable("Retailer");
                });

            modelBuilder.Entity("LLPTest.Data.Retailers.RetailerCode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid>("RetailerSiteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RetailerSiteId");

                    b.ToTable("RetailerCode");
                });

            modelBuilder.Entity("LLPTest.Data.Retailers.RetailerGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("RetailerGroup");
                });

            modelBuilder.Entity("LLPTest.Data.Retailers.RetailerSite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid>("RetailerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("RetailerId");

                    b.ToTable("RetailerSite");
                });

            modelBuilder.Entity("LLPTest.Data.Blogs.Blog", b =>
                {
                    b.HasOne("LLPTest.Data.Blogs.Author", "Author")
                        .WithMany("Blogs")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("LLPTest.Data.Blogs.BlogImage", b =>
                {
                    b.HasOne("LLPTest.Data.Blogs.Blog", null)
                        .WithOne("BlogImage")
                        .HasForeignKey("LLPTest.Data.Blogs.BlogImage", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LLPTest.Data.Blogs.Post", b =>
                {
                    b.HasOne("LLPTest.Data.Blogs.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("LLPTest.Data.Customers.Address", b =>
                {
                    b.HasOne("LLPTest.Data.Customers.Customer", null)
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LLPTest.Data.Customers.Customer", b =>
                {
                    b.HasOne("LLPTest.Data.Customers.Country", "Country")
                        .WithMany("Customers")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("LLPTest.Data.Customers.ContactDetails", "ContactDetails", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasColumnName("Email");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customer");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("LLPTest.Data.Customers.Person", "Person", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasColumnName("FirstName");

                            b1.Property<Guid?>("GenderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("LastName")
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)")
                                .HasColumnName("LastName");

                            b1.HasKey("CustomerId");

                            b1.HasIndex("GenderId");

                            b1.ToTable("Customer");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");

                            b1.HasOne("LLPTest.Data.Customers.Gender", "Gender")
                                .WithMany()
                                .HasForeignKey("GenderId");

                            b1.Navigation("Gender");
                        });

                    b.Navigation("ContactDetails")
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Person")
                        .IsRequired();
                });

            modelBuilder.Entity("LLPTest.Data.Customers.CustomerRetailerSite", b =>
                {
                    b.HasOne("LLPTest.Data.Customers.Customer", "Customer")
                        .WithMany("CustomerRetailerSites")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("LLPTest.Data.Retailers.RetailerSite", "RetailerSite")
                        .WithMany()
                        .HasForeignKey("RetailerSiteId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("RetailerSite");
                });

            modelBuilder.Entity("LLPTest.Data.Retailers.Area", b =>
                {
                    b.HasOne("LLPTest.Data.Retailers.Region", "Region")
                        .WithMany("Areas")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("LLPTest.Data.Retailers.Region", b =>
                {
                    b.HasOne("LLPTest.Data.Retailers.Market", "Market")
                        .WithMany("Regions")
                        .HasForeignKey("MarketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Market");
                });

            modelBuilder.Entity("LLPTest.Data.Retailers.Retailer", b =>
                {
                    b.HasOne("LLPTest.Data.Retailers.Area", "Area")
                        .WithMany("Retailers")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LLPTest.Data.Retailers.RetailerGroup", "RetailerGroup")
                        .WithMany("Retailers")
                        .HasForeignKey("RetailerGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("RetailerGroup");
                });

            modelBuilder.Entity("LLPTest.Data.Retailers.RetailerCode", b =>
                {
                    b.HasOne("LLPTest.Data.Retailers.RetailerSite", "RetailerSite")
                        .WithMany("RetailerCodes")
                        .HasForeignKey("RetailerSiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RetailerSite");
                });

            modelBuilder.Entity("LLPTest.Data.Retailers.RetailerSite", b =>
                {
                    b.HasOne("LLPTest.Data.Retailers.Brand", "Brand")
                        .WithMany("RetailerSites")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LLPTest.Data.Retailers.Retailer", "Retailer")
                        .WithMany("RetailerSites")
                        .HasForeignKey("RetailerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Retailer");
                });

            modelBuilder.Entity("LLPTest.Data.Blogs.Author", b =>
                {
                    b.Navigation("Blogs");
                });

            modelBuilder.Entity("LLPTest.Data.Blogs.Blog", b =>
                {
                    b.Navigation("BlogImage")
                        .IsRequired();

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("LLPTest.Data.Customers.Country", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("LLPTest.Data.Customers.Customer", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("CustomerRetailerSites");
                });

            modelBuilder.Entity("LLPTest.Data.Retailers.Area", b =>
                {
                    b.Navigation("Retailers");
                });

            modelBuilder.Entity("LLPTest.Data.Retailers.Brand", b =>
                {
                    b.Navigation("RetailerSites");
                });

            modelBuilder.Entity("LLPTest.Data.Retailers.Market", b =>
                {
                    b.Navigation("Regions");
                });

            modelBuilder.Entity("LLPTest.Data.Retailers.Region", b =>
                {
                    b.Navigation("Areas");
                });

            modelBuilder.Entity("LLPTest.Data.Retailers.Retailer", b =>
                {
                    b.Navigation("RetailerSites");
                });

            modelBuilder.Entity("LLPTest.Data.Retailers.RetailerGroup", b =>
                {
                    b.Navigation("Retailers");
                });

            modelBuilder.Entity("LLPTest.Data.Retailers.RetailerSite", b =>
                {
                    b.Navigation("RetailerCodes");
                });
#pragma warning restore 612, 618
        }
    }
}
