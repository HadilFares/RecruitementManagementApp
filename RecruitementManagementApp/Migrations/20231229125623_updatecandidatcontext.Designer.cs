﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecruitementManagementApp.Models;

#nullable disable

namespace RecruitementManagementApp.Migrations
{
    [DbContext(typeof(RecruitementDbContext))]
    [Migration("20231229125623_updatecandidatcontext")]
    partial class updatecandidatcontext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("recruitement")
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RecruitementManagementApp.Models.Candidat", b =>
                {
                    b.Property<int>("IdCandidat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCandidat"));

                    b.Property<DateTime>("DateNaiss")
                        .HasMaxLength(20)
                        .HasColumnType("datetime2")
                        .HasColumnName("DateNaiss");

                    b.Property<string>("Frameworks")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Frameworks");

                    b.Property<string>("Githuburl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Langage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stagesexpercience")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("StagesExpercience");

                    b.Property<string>("University")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("University");

                    b.HasKey("IdCandidat");

                    b.ToTable("TCandidat", "recruitement");
                });

            modelBuilder.Entity("RecruitementManagementApp.Models.CandidatOffre", b =>
                {
                    b.Property<int>("IdCandidat")
                        .HasColumnType("int");

                    b.Property<int>("codeOffre")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("IdCandidat", "codeOffre");

                    b.HasIndex("codeOffre");

                    b.ToTable("candidatOffres", "recruitement");
                });

            modelBuilder.Entity("RecruitementManagementApp.Models.Offre", b =>
                {
                    b.Property<int>("codeOffre")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codeOffre"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("archived")
                        .HasColumnType("bit");

                    b.Property<int>("nameRh")
                        .HasColumnType("int");

                    b.Property<bool>("published")
                        .HasColumnType("bit");

                    b.HasKey("codeOffre");

                    b.HasIndex("nameRh");

                    b.ToTable("TOffre", "recruitement");
                });

            modelBuilder.Entity("RecruitementManagementApp.Models.Rh", b =>
                {
                    b.Property<int>("IdRh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRh"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRh");

                    b.ToTable("TRh", "recruitement");
                });

            modelBuilder.Entity("RecruitementManagementApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("EmailUser");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("LastName");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("NomUser");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)")
                        .HasColumnName("NumeroUser");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("PasswordUser");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("profilecompleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Users", "recruitement");
                });

            modelBuilder.Entity("RecruitementManagementApp.Models.CandidatOffre", b =>
                {
                    b.HasOne("RecruitementManagementApp.Models.Candidat", "Candidat")
                        .WithMany("candidatOffres")
                        .HasForeignKey("IdCandidat")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecruitementManagementApp.Models.Offre", "Offre")
                        .WithMany("candidatOffres")
                        .HasForeignKey("codeOffre")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidat");

                    b.Navigation("Offre");
                });

            modelBuilder.Entity("RecruitementManagementApp.Models.Offre", b =>
                {
                    b.HasOne("RecruitementManagementApp.Models.Rh", "LeRh")
                        .WithMany("Offres")
                        .HasForeignKey("nameRh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LeRh");
                });

            modelBuilder.Entity("RecruitementManagementApp.Models.Candidat", b =>
                {
                    b.Navigation("candidatOffres");
                });

            modelBuilder.Entity("RecruitementManagementApp.Models.Offre", b =>
                {
                    b.Navigation("candidatOffres");
                });

            modelBuilder.Entity("RecruitementManagementApp.Models.Rh", b =>
                {
                    b.Navigation("Offres");
                });
#pragma warning restore 612, 618
        }
    }
}
