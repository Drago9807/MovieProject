using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MovieProjectDB
{
    class MyConfiguration : DbConfiguration
    {
        public MyConfiguration()
        {
            SetDefaultConnectionFactory(new LocalDbConnectionFactory("MSSQLLocalDB"));
        }
    }
}
