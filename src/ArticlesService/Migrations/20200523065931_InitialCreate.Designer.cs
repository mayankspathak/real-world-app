﻿// <auto-generated />
using System;
using ArticlesService.Persistence;
using ArticlesService.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ArticlesService.Migrations
{
    [DbContext(typeof(ArticlesDbContext))]
    [Migration("20200523065931_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ArticlesService.Domain.Entities.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnName("author_id")
                        .HasColumnType("text");

                    b.Property<string>("Body")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAtUtc")
                        .HasColumnName("created_at_utc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .HasColumnName("slug")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("UpdatedAtUtc")
                        .HasColumnName("updated_at_utc")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("articles");
                });

            modelBuilder.Entity("ArticlesService.Domain.Entities.ArticleFavorite", b =>
                {
                    b.Property<Guid>("ArticleId")
                        .HasColumnName("article_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("uuid");

                    b.HasKey("ArticleId", "UserId");

                    b.ToTable("article_favorites");
                });

            modelBuilder.Entity("ArticlesService.Domain.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ArticleId")
                        .HasColumnName("article_id")
                        .HasColumnType("uuid");

                    b.Property<string>("AuthorId")
                        .HasColumnName("author_id")
                        .HasColumnType("text");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnName("body")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAtUtc")
                        .HasColumnName("created_at_utc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("UpdatedAtUtc")
                        .HasColumnName("updated_at_utc")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("ArticlesService.Domain.Entities.ArticleFavorite", b =>
                {
                    b.HasOne("ArticlesService.Domain.Entities.Article", "Article")
                        .WithMany("Favorites")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ArticlesService.Domain.Entities.Comment", b =>
                {
                    b.HasOne("ArticlesService.Domain.Entities.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}