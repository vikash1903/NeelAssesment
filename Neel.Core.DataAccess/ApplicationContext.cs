using Neel.Core.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neel.Core.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("EmployeeDB") { }
        public DbSet<EmployeeModel> employee { get; set; }
    }
}
