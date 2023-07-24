using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainer.ConnectToDB
{
    public class Connect
    {
        public static string connString;
        public static void Conn()
        {
            connString = @"Data Source=KOHNYUSHA; Initial Catalog=TEST;Integrated Security=True";
        }
    }
}
