using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.Repositories.EFCore.DataContext
{
    class OpheliaContextFactory :
        IDesignTimeDbContextFactory<OpheliaContext>
    {
        public OpheliaContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<OpheliaContext> OptionBuilder = new DbContextOptionsBuilder<OpheliaContext>();
            OptionBuilder.UseSqlServer("Server=localhost;database=OpheliaDB;Integrated Security=True;");
            return new OpheliaContext(OptionBuilder.Options);
        }
    }
}
