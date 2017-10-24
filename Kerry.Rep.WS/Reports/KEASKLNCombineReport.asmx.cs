using System.Web.Services;
using Kerry.Rep.DB.Utility;
using Kerry.Rep.WS.Common;
using System.Data.Common;



namespace Kerry.Rep.WS.Reports
{
    /// <summary>
    /// Summary description for KEASKLNCombineReport
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class KEASKLNCombineReport : System.Web.Services.WebService
    {
        private DBFactory _db = new DBFactory();


        [WebMethod]
        public void KEASKLNCombineReportAir()
        {
            string sql = string.Format("",);
            DbCommand dc = _db.DB_K3.GetSqlStringCommond(sql);
            var dt = _db.DB_K3.ExecuteDataTable(dc);
            var excelHelper = new ExcelHelper();
            try
            {
                excelHelper.DataTabletoExcel(dt, "KEASKLNCombineReportAir");

            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }

        [WebMethod]
        public void KEASKLNCombineReportSea()
        {
            string sql = string.Format("",);
            DbCommand dc = _db.DB_K3.GetSqlStringCommond(sql);
            var dt = _db.DB_K3.ExecuteDataTable(dc);
            var excelHelper = new ExcelHelper();
            try
            {
                excelHelper.DataTabletoExcel(dt, "KEASKLNCombineReportSea");

            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}