using PLUMWEB.Contracts;
using PLUMWEB.Data;
using PLUMWEB.Repositories;

namespace PLUMWEB.Models.Repositories
{
    public class ProduceRepository : GenericRepository<Produce>, IProduceRepository
    {
        public ProduceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
