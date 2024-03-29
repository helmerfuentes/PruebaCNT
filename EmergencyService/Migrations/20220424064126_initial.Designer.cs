﻿// <auto-generated />
using EmergencyService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmergencyService.Migrations
{
    [DbContext(typeof(CNTContext))]
    [Migration("20220424064126_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmergencyService.Models.Paciente", b =>
                {
                    b.Property<int>("PacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Dieta")
                        .HasColumnType("bit");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Documento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Edad")
                        .HasColumnType("bigint");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<long>("Estatura")
                        .HasColumnType("bigint");

                    b.Property<bool>("Fumador")
                        .HasColumnType("bit");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("PesoEstatura")
                        .HasColumnType("bigint");

                    b.Property<double>("Prioridad")
                        .HasColumnType("float");

                    b.Property<double>("Riesgo")
                        .HasColumnType("float");

                    b.Property<bool>("Sexo")
                        .HasColumnType("bit");

                    b.Property<long>("TiempoFumando")
                        .HasColumnType("bigint");

                    b.HasKey("PacienteId");

                    b.ToTable("Paciente");
                });
#pragma warning restore 612, 618
        }
    }
}
