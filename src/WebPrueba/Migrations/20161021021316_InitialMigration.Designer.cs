using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebPrueba.Models;

namespace WebPrueba.Migrations
{
    [DbContext(typeof(PersonContext))]
    [Migration("20161021021316_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebPrueba.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apellidos");

                    b.Property<string>("Cedula");

                    b.Property<string>("Direccion");

                    b.Property<string>("Email");

                    b.Property<string>("Nombres");

                    b.Property<string>("Telefono");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });
        }
    }
}
