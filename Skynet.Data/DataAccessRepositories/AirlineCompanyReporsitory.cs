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
    public class AirlineCompanyReporsitory : Repository<AirlineCompany>, IAirlineCompanyReporsitory
    {
        public AirlineCompanyReporsitory(IConfiguration config, IDbConnection connection) : base(config, connection)
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


    public interface IAirlineCompanyReporsitory : IRepository<AirlineCompany>
    {

        AirlineCompany GetAirlineByUserName(Customer customer);
        IEnumerable<AirlineCompany> GetAirlineByCountry(Country country);
    }

}
