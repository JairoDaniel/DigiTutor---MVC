﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DigiTutor.Constants
{
    public class DBConnection
    {
        public static SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection("Data Source = JAIRODANIEL\\SQLSERVER; Initial Catalog = DigiTutor; Integrated Security = true;");
            return connection;
        }
    }
}