using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Church.Data;

namespace Church.DataAccess.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ChurchContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChurchContext"/> class.
        /// </summary>
        public ChurchContext()
            : base(new SQLiteConnection("Data Source=:memory:;Version=3;New=True;"), true)
        {
        }

        /// <summary>
        /// Gets or sets the user audit.
        /// </summary>
        public DbSet<UserAudit> UserAudit { get; set; }
    }
}
