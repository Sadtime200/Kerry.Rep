namespace Kerry.Rep.DB.Constants
{
    public static class SysConstants
    {
        public static string K3_DB_CONNECTION = System.Configuration.ConfigurationManager.ConnectionStrings["K3EntitiesADO"].ToString();
        //public static string K35_DB_CONNECTION = System.Configuration.ConfigurationManager.ConnectionStrings["K35EntitiesADO"].ToString();


        public static string ORACE_PROVIDER = System.Configuration.ConfigurationManager.AppSettings["OracleProvider"] as string;
        //public static string MYSQL_PROVIDER = System.Configuration.ConfigurationManager.AppSettings["MysqlProvider"] as string;
    }
}
