using Ardalis.EFCore.Extensions;
using EjemploMVCCursosOnline.Helpers;
using EjemploMVCCursosOnline.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EjemploMVCCursosOnline.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly IServicioUsuarioActual servicioUsuarioActual;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IServicioUsuarioActual servicioUsuarioActual)
            : base(options)
        {
            this.servicioUsuarioActual = servicioUsuarioActual;
        }


        public DbSet<Curso> Curso { get; set; }
        public DbSet<Precio> Precio { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Instructor> Instructor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();

            // alternately this is built-in to EF Core 2.2
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            GuardarCambiosConAuditoria();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void GuardarCambiosConAuditoria()
        {

            string[] propiedades = new[]{
                "FechaCreacion",
                "UsuarioCreacion",
                "FechaModificacion",
                "UsuarioModificacion",
                "EstaBorrado"
            };

            var Entries = ChangeTracker.Entries()
                .Where(e => (e.State == EntityState.Added
                || e.State == EntityState.Modified
                || e.State == EntityState.Deleted)
                && e.Properties.Any(p => propiedades.Contains(p.Metadata.Name))
                );

            foreach (var entry in Entries)
            {
                var today = DateTime.UtcNow;
                //var today = _dateTimeManager.Today;
                var currentUser = servicioUsuarioActual.ObtenerNombreUsuarioActual();
                //var currentUser = _contextData.CurrentUser;


                entry.Property("FechaModificacion").CurrentValue = today;
                entry.Property("UsuarioModificacion").CurrentValue = currentUser;
                if (entry.State == EntityState.Added)
                {
                    entry.Property("FechaCreacion").CurrentValue = today;
                    entry.Property("UsuarioCreacion").CurrentValue = currentUser;
                }

                //if (entry.State == EntityState.Modified)
                //{
                //    entry.Property("FechaCreacion").IsModified = false;
                //    entry.Property("UsuarioCreacion").IsModified = false;
                //}

                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Property("EstaBorrado").CurrentValue = true;
                }

            }

        }


    }
}
