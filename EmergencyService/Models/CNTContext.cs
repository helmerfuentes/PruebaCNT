using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EmergencyService.Models
{
    public partial class CNTContext : DbContext
    {
        public CNTContext()
        {
        }

        public CNTContext(DbContextOptions<CNTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Paciente> Paciente { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>().HasQueryFilter(x => x.Estado== EstadoPacienteEnum.Pendiente);
        }
    }
}
