using Kerry.Rep.DB.Utility;
using Kerry.Rep.DB.Constants;

namespace Kerry.Rep.WS.Common
{
    public class DBFactory
    {
        public DBFactory()
        {
            this.DB_K3 = new DbHelper(SysConstants.K3_DB_CONNECTION, SysConstants.ORACE_PROVIDER);
            //this.DB_K35 = new DbHelper(SysConstants.K35_DB_CONNECTION, SysConstants.MYSQL_PROVIDER);
        }
        public DbHelper DB_K3 { get; set; }
        //public DbHelper DB_K35 { get; set; }
    }
}