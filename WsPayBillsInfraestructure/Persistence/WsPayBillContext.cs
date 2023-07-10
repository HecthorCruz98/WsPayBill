using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using WsPayBillsDomain.Common;
using WsPayBillsDomain;

namespace WsPayBillsInfraestructure.Persistence
{
    public class WsPayBillContext : DbContext
    {
        public WsPayBillContext(DbContextOptions options) : base(options)
        {
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.createDate = DateTime.Now;
                        entry.Entity.createUser = "Systema";
                        break;
                    case EntityState.Modified:
                        entry.Entity.modifyDate = DateTime.Now;
                        entry.Entity.modifyUser = "Systema";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Registros creados por defecto en la base de datos
            List<Rol> RolInit = new List<Rol>();
            RolInit.Add(new Rol
            {
                rolId = 1,
                rolName = "Administrador",
                createDate = DateTime.Now,
                createUser = "Hector Cruz",
            });

            
            #endregion
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<EnterpriseType> EnterpriseTypes { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<State> Status{ get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
}
