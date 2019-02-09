using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Evaluacion_Final2.Models;

namespace Evaluacion_Final2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<IdentityRole> IdentityRole { get; set; }
        public DbSet<Evaluacion_Final2.Models.Disco> Disco { get; set; }
        public DbSet<Evaluacion_Final2.Models.Informacion> Informacion { get; set; }
        public DbSet<Evaluacion_Final2.Models.Ubicacion> Ubicacion { get; set; }
    }
}
