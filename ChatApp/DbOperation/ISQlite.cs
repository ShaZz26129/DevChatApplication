using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.DbOperation
{
    /// <summary>
    /// Interface ISQlite
    /// </summary>
    public interface ISQlite
    {
        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns>SQLite.SQLiteConnection.</returns>
        SQLite.SQLiteConnection GetConnection();
    }
}
