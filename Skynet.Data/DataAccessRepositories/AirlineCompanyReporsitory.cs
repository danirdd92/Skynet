using Microsoft.Extensions.Configuration;
using Skynet.Data.Internal;
using Skynet.Domain.Models;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Dapper.Contrib;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;

namespace Skynet.Data.DataAccessRepositories
{
    public class AirlineCompanyRepository : Repository<AirlineCompany>, IAirlineCompanyRepository
    {
        public AirlineCompanyRepository(IConfiguration config, IDbConnection connection) : base(config, connection)
        {

        }
        public IEnumerable<AirlineCompany> GetAirlineByCountry(Country country)
        {
            throw new System.NotImplementedException();
        }

        public AirlineCompany GetAirlineByUserName(Customer customer)
        {
            throw new System.NotImplementedException();
        }
    }


    public interface IAirlineCompanyRepository : IRepository<AirlineCompany>
    {

        AirlineCompany GetAirlineByUserName(Customer customer);
        IEnumerable<AirlineCompany> GetAirlineByCountry(Country country);
    }

}
