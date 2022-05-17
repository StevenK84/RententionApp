using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RetentionApp
{
    class DbConn
    {
        string myConnectionString =  "server = 127.0.0.1; user id = root; password=7U6F7P2fd4;database=seniorproject";
        private void Form_Load(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection(myConnectionString);
            cnn.Open();
        }

    }
}
