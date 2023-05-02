using CelilCavus.Entitys;
using CelilCavus.Models.Contexts;
using CelilCavus.Repository;
using Microsoft.EntityFrameworkCore;

namespace CelilCavus.Services
{
    public class CustomerServices : GenericRepository<Customer>
    {
        public CustomerServices(DbContext context) : base(context)
        {
        }
    }
}