using MySql.Data.MySqlClient;
using System;

namespace ECManager
{
    internal class connect
    {
        public static string GetConnectionString()
        {
            return "server=localhost;user=root;password=;database=ecm;";
        }

        public bool TestConnection(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(GetConnectionString()))
                {
                    conn.Open();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
