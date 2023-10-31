using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JqueryCrud.Database
{
    public class Connection
    {
        public SqlConnection MyConnection()
        {
            SqlConnection Con = new SqlConnection(@"data source=LAPTOP-9QHC18NE;Initial catalog=MyDatatable;Integrated security=true");
            return Con;
        }
    }
}