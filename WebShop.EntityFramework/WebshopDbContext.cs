using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebShop
{
    public partial class Entities
    {
        private void PreSaveProcess()
        {
            var entities =
                ChangeTracker.Entries()
                    .Where(
                        x => x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted);

            foreach (var entity in entities)
            {
                // Logs auditable information
                var auditable = entity.Entity as IAuditable;
                if (auditable != null && entity.State != EntityState.Deleted)
                {
                    if (entity.State == EntityState.Added)
                    {
                        auditable.CreateDate = DateTime.Now;
                    }
                    auditable.UpdateDate = DateTime.Now;
                }
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            PreSaveProcess();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync()
        {
            PreSaveProcess();
            return base.SaveChangesAsync();
        }

        public override int SaveChanges()
        {
            PreSaveProcess();
            return base.SaveChanges();
        }
    }
}
