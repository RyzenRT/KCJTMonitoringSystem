using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace SampleInventory
{
    class SQLLoad
    {
        public static SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DBKCJTMSBETA;Integrated Security=True");
    }
}
