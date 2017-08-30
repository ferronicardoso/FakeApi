using FakeApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeApi.Infrastructure.Repositories
{
    public class RestMockRepository : GenericRepository<RestMock>
    {
        public RestMockRepository(string connectionString) 
            : base(connectionString)
        {

        }
    }
}
