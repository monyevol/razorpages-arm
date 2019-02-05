using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApartmentsRentalManagement1.Models;

namespace ApartmentsRentalManagement1.Models
{
    public class ApartmentsRentalManagement1Context : DbContext
    {
        public ApartmentsRentalManagement1Context (DbContextOptions<ApartmentsRentalManagement1Context> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Apartment> Apartment { get; set; }

        public DbSet<RentalContract> RentalContract { get; set; }

        public DbSet<Payment> Payment { get; set; }
    }
}
