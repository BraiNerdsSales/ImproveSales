namespace ImproveSales.Database
{
    using ImproveSales.Database.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ImproveSalesDbContext : IdentityDbContext<User, Role, string>
    {
        public ImproveSalesDbContext(DbContextOptions<ImproveSalesDbContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var table = entityType.GetTableName();
                if (table.StartsWith("AspNet"))
                {
                    entityType.SetTableName(table.Substring(6));
                }
            };
        }
    }
}
