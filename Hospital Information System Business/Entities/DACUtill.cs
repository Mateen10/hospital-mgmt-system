using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Information_System_Business.Entities
{
    internal class DACUtill
    {
        public static SqlConnection getConnection()
        {
            return new SqlConnection("Data Source=.;Initial Catalog=HIS;user id=sa;password=123");
        }
    }
}
