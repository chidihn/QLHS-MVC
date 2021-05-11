using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Utility
{
    public class ConnectionString
    {
        private static string cName = "Data Source=DESKTOP-C7VD4KA;Initial Catalog=StudentManagermentMVC;User ID=sa;Password=sa123";

        public static string CName { get => cName; }
    }
}
