using Skynet.Data.Internal;
using Skynet.Domain.Models;
using System.Collections.Generic;

namespace Skynet.Data.DataAccessRepositories
{
    interface IAirlineCompanyReporsitory : ICrudRepository<AirlineCompany>
    {
        /// <summary>
        /// ToDo: Make sure customer's role is Airline company
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        AirlineCompany GetAirlineByUserName(Customer customer);
        IEnumerable<AirlineCompany> GetAirlineByCountry(Country country);
    }

    public class AirlineRepository : IAirlineCompanyReporsitory
    {
        public void Add(AirlineCompany item)
        {
            throw new System.NotImplementedException();
        }

        public AirlineCompany Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<AirlineCompany> GetAirlineByCountry(Country country)
        {
            throw new System.NotImplementedException();
        }

        public AirlineCompany GetAirlineByUserName(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<AirlineCompany> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Remove()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
