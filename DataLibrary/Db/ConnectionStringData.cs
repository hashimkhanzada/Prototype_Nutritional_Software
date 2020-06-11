using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Db
{
    public class ConnectionStringData //sql connection name. If the name needs to change, it can be done here.
    {
        public string SqlConnectionName { get; set; } = "Default"; //name of database connection in appsettings.json
    }
}
