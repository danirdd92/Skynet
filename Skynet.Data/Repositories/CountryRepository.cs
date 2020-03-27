using Skynet.Domain;

namespace Skynet.Data.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private readonly SkynetContext _context;

        public CountryRepository(SkynetContext context) : base(context)
        {
            _context = context;
        }
    }

    public interface ICountryRepository : IRepository<Country> { }

}
