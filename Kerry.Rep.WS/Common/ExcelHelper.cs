using System;
using System.Collections.Generic;
using System.Linq;
using OfficeOpenXml;
using System.Data;
using System.IO;
using System.Reflection;
using OfficeOpenXml.Style;
using System.Drawing;

namespace Kerry.Rep.WS.Common
{
    public class ExcelHelper
    {

        public void DataTabletoExcel(System.Data.DataTable tmpDataTable, string strFileName)
        {

            using (ExcelPackage xlApp = new ExcelPackage())
            {
                var xlBook = xlApp.Workbook;
                xlApp.Workbook.Worksheets.Add("Sheet1");
                var xlSheet = xlApp.Workbook.Worksheets[1];
                xlSheet.Name = "Sheet1";
                try
                {
                    if (tmpDataTable == null)
                        return;
                    int rowNum = tmpDataTable.Rows.Count;
                    int columnNum = tmpDataTable.Columns.Count;
                    int rowIndex = 1;
                    int columnIndex = 0;

                    //xlApp.
                    //xlApp.DefaultFilePath = "";
                    //xlApp.DisplayAlerts = true;
                    //xlApp.SheetsInNewWorkbook = 1;
                    //xlBook = xlApp.Workbooks.Add(true);

                    //将DataTable的列名导入Excel表第一行
                    foreach (DataColumn dc in tmpDataTable.Columns)
                    {
                        columnIndex++;
                        xlSheet.Cells[rowIndex, columnIndex].Value = dc.ColumnName;
                    }

                    //将DataTable中的数据导入Excel中
                    for (int i = 0; i < rowNum; i++)
                    {
                        rowIndex++;
                        columnIndex = 0;
                        for (int j = 0; j < columnNum; j++)
                        {
                            columnIndex++;
                            xlSheet.Cells[rowIndex, columnIndex].Value = tmpDataTable.Rows[i][j].ToString();
                        }
                    }
                    //int FormatNum = 0;
                    ////var Version = xlApp.Version;
                    //if (Convert.ToDouble(Version) < 12)
                    //{
                    //    FormatNum = -4143;
                    //}
                    //else
                    //{
                    //    FormatNum = 56;
                    //}
                    //xlApp.SaveAs()
                    //xlBook.SaveAs(strFileName, FormatNum);


                    Byte[] bin = xlApp.GetAsByteArray();
                    File.WriteAllBytes(strFileName, bin);

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (xlBook != null)
                        xlApp.Dispose();
                }

            }
        }

        //public void ListToExcel(List<Job> jobs, string path)
        //{
        //    using (ExcelPackage xlApp = new ExcelPackage())
        //    {
        //        var xlBook = xlApp.Workbook;
        //        xlApp.Workbook.Worksheets.Add("Sheet1");
        //        var xlSheet = xlApp.Workbook.Worksheets[1];
        //        xlSheet.Name = "Sheet1";
        //        Type type = typeof(Job);
        //        try
        //        {
        //            if (jobs == null)
        //                return;
        //            int rowNum = jobs.Count;
        //            PropertyInfo[] props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //            int columnNum = props.Count();
        //            int rowIndex = 1;
        //            int columnIndex = 0;

        //            //xlApp.
        //            //xlApp.DefaultFilePath = "";
        //            //xlApp.DisplayAlerts = true;
        //            //xlApp.SheetsInNewWorkbook = 1;
        //            //xlBook = xlApp.Workbooks.Add(true);
        //            //var headerStyle = new ExcelStyle {
        //            //    font
        //            //};

        //            Color gray = System.Drawing.ColorTranslator.FromHtml("#808080");
        //            foreach (var p in props)
        //            {
        //                columnIndex++;
        //                xlSheet.Cells[rowIndex, columnIndex].Value = p.Name;
        //                xlSheet.Cells[rowIndex, columnIndex].Style.Font.Bold = true;
        //                xlSheet.Cells[rowIndex, columnIndex].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //                xlSheet.Cells[rowIndex, columnIndex].Style.Fill.BackgroundColor.SetColor(gray);
        //                xlSheet.Cells[rowIndex, columnIndex].Style.ShrinkToFit = true;
        //                xlSheet.Row(rowIndex).Height = 24;

        //            }

        //            for (int i = 0; i < rowNum; i++)
        //            {
        //                rowIndex++;

        //                columnIndex++;
        //                xlSheet.Cells[rowIndex, 1].Value = jobs[i].ID.ToString();
        //                xlSheet.Cells[rowIndex, 2].Value = jobs[i].JobNo;
        //                xlSheet.Cells[rowIndex, 3].Value = jobs[i].ShpType;
        //                xlSheet.Cells[rowIndex, 4].Value = jobs[i].IsKLN;
        //                xlSheet.Cells[rowIndex, 5].Value = jobs[i].BizType;
        //                xlSheet.Cells[rowIndex, 6].Value = jobs[i].BookingNo;
        //                xlSheet.Cells[rowIndex, 7].Value = jobs[i].ShipmentNo;
        //                xlSheet.Cells[rowIndex, 8].Value = jobs[i].HouseNo;
        //                xlSheet.Cells[rowIndex, 9].Value = jobs[i].MasterNo;
        //                //xlSheet.Cells[rowIndex, 10].Value = jobs[i].JobDate;
        //                xlSheet.Cells[rowIndex, 10].Value = jobs[i].OwnerID;
        //                xlSheet.Cells[rowIndex, 11].Value = jobs[i].isActive;
        //                xlSheet.Cells[rowIndex, 12].Value = jobs[i].CreateDate;
        //                xlSheet.Cells[rowIndex, 13].Value = jobs[i].UpdateDate;
        //            }



        //            Byte[] bin = xlApp.GetAsByteArray();

        //            //Stream stream = File.Open(rootPath, FileMode.Open);
        //            //OpenAndAddToSpreadsheetStream(stream);
        //            //stream.Close();

        //            File.WriteAllBytes(path, bin);



        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //        finally
        //        {
        //            if (xlBook != null)
        //                xlApp.Dispose();
        //        }

        //    }
        //}

        //public void ListToExcel(List<Revenue> revenues, string path)
        //{
        //    using (ExcelPackage xlApp = new ExcelPackage())
        //    {
        //        var xlBook = xlApp.Workbook;
        //        xlApp.Workbook.Worksheets.Add("Sheet1");
        //        var xlSheet = xlApp.Workbook.Worksheets[1];
        //        xlSheet.Name = "Sheet1";
        //        Type type = typeof(Revenue);
        //        try
        //        {
        //            if (revenues == null)
        //                return;
        //            int rowNum = revenues.Count;
        //            PropertyInfo[] props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //            int columnNum = props.Count();
        //            int rowIndex = 1;
        //            int columnIndex = 0;

        //            //xlApp.
        //            //xlApp.DefaultFilePath = "";
        //            //xlApp.DisplayAlerts = true;
        //            //xlApp.SheetsInNewWorkbook = 1;
        //            //xlBook = xlApp.Workbooks.Add(true);
        //            //var headerStyle = new ExcelStyle {
        //            //    font
        //            //};

        //            Color gray = System.Drawing.ColorTranslator.FromHtml("#808080");
        //            foreach (var p in props)
        //            {
        //                columnIndex++;
        //                xlSheet.Cells[rowIndex, columnIndex].Value = p.Name;
        //                xlSheet.Cells[rowIndex, columnIndex].Style.Font.Bold = true;
        //                xlSheet.Cells[rowIndex, columnIndex].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //                xlSheet.Cells[rowIndex, columnIndex].Style.Fill.BackgroundColor.SetColor(gray);
        //                xlSheet.Cells[rowIndex, columnIndex].Style.ShrinkToFit = true;
        //                xlSheet.Row(rowIndex).Height = 24;

        //            }

        //            for (int i = 0; i < rowNum; i++)
        //            {
        //                rowIndex++;

        //                columnIndex++;
        //                xlSheet.Cells[rowIndex, 1].Value = revenues[i].ID.ToString();
        //                xlSheet.Cells[rowIndex, 2].Value = revenues[i].ShpType;
        //                xlSheet.Cells[rowIndex, 3].Value = revenues[i].IsKLN;
        //                xlSheet.Cells[rowIndex, 4].Value = revenues[i].BizType;
        //                xlSheet.Cells[rowIndex, 5].Value = revenues[i].LocalAmount;
        //                xlSheet.Cells[rowIndex, 6].Value = revenues[i].ShipmentNo;
        //                //xlSheet.Cells[rowIndex, 9].Value = revenues[i].MasterNo;
        //                //xlSheet.Cells[rowIndex, 10].Value = jobs[i].JobDate;
        //                xlSheet.Cells[rowIndex, 7].Value = revenues[i].DocNo;
        //                xlSheet.Cells[rowIndex, 8].Value = revenues[i].OwnerID;
        //                xlSheet.Cells[rowIndex, 9].Value = revenues[i].Status;
        //                //xlSheet.Cells[rowIndex, 11].Value = revenues[i].isActive;
        //                xlSheet.Cells[rowIndex, 10].Value = revenues[i].CreateDate;
        //                xlSheet.Cells[rowIndex, 11].Value = revenues[i].UpdateDate;
        //            }



        //            Byte[] bin = xlApp.GetAsByteArray();

        //            //Stream stream = File.Open(rootPath, FileMode.Open);
        //            //OpenAndAddToSpreadsheetStream(stream);
        //            //stream.Close();

        //            File.WriteAllBytes(path, bin);



        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //        finally
        //        {
        //            if (xlBook != null)
        //                xlApp.Dispose();
        //        }

        //    }
        //}


    }
}