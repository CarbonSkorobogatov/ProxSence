using System.Data.Entity;
using ProxSence.Library.ProxSenceModels;

namespace ProxSence.Library.ProxSenceModels
{
    public class EFDbContext : DbContext
    {
        public DbSet<PortfolioList> PList { get; set; }
    }
}
