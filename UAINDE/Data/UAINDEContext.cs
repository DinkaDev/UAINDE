using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UAINDE.Models;

namespace UAINDE.Data
{
    public class UAINDEContext : DbContext
    {
        public UAINDEContext (DbContextOptions<UAINDEContext> options)
            : base(options)
        {
        }

        public DbSet<UAINDE.Models.SearchingCategories> SearchingCategories { get; set; } = default!;
    }
}
