using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace WpfDoctolib.Tools
{
    class DataBase
    {
        private static string chaine = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\Allan\Documents\WPF Doctolib\WpfDoctolib\WpfDoctolib\Tools\Database1.mdf';Integrated Security=True";
        public static SqlConnection Connection = new SqlConnection(chaine);
    }
}
