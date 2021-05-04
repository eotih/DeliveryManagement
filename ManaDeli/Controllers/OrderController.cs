﻿using ClosedXML.Excel;
using ManaDeli.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManaDeli.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        ManaDeliEntities db = new ManaDeliEntities();
        // GET: QuanLy
        public ActionResult Index()
        {
            if (Session["id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("../Account/Login");
            }

        }

        [HttpPost]
        public FileResult ExportToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[17] {
                                                     new DataColumn("Id"),
                                                     new DataColumn("mavandon"),
                                                     new DataColumn("madonhang"),
                                                     new DataColumn("tennguoigui"),
                                                     new DataColumn("tennguoinhan"),
                                                     new DataColumn("sdtnguoinhan"),
                                                     new DataColumn("diachinguoinhan"),
                                                     new DataColumn("soluong"),
                                                     new DataColumn("giatri"),
                                                     new DataColumn("dichvu"),
                                                     new DataColumn("loaihang"),
                                                     new DataColumn("cannang"),
                                                     new DataColumn("ghichu"),
                                                     new DataColumn("trangthai"),
                                                     new DataColumn("phiship"),
                                                     new DataColumn("cod"),
                                                     new DataColumn("ngaytaodon")});

            var a = from DONHANG in db.DONHANGs select DONHANG;

            foreach (var kac in a)
            {
                dt.Rows.Add(kac.Id, kac.mavandon, kac.madonhang, kac.tennguoigui, kac.tennguoinhan, kac.sdtnguoinhan, kac.diachinguoinhan, kac.soluong, kac.giatri, kac.dichvu, kac.loaihang, kac.cannang, kac.ghichu, kac.trangthai, kac.phiship, kac.cod, kac.ngaytaodon);
            }

            using (XLWorkbook wb = new XLWorkbook()) //Install ClosedXml from Nuget for XLWorkbook  
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream()) //using System.IO;  
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ExcelFile.xlsx");
                }
            }
        }

        [HttpPost]
        public ActionResult ImportFromExcel(HttpPostedFileBase postedFile)
        {
            if (ModelState.IsValid)
            {
                if (postedFile != null && postedFile.ContentLength > (1024 * 1024 * 50))  // 50MB limit  
                {
                    ModelState.AddModelError("postedFile", "Your file is to large. Maximum size allowed is 50MB !");
                }

                else
                {
                    string filePath = string.Empty;
                    string path = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    filePath = path + Path.GetFileName(postedFile.FileName);
                    string extension = Path.GetExtension(postedFile.FileName);
                    postedFile.SaveAs(filePath);

                    string conString = string.Empty;
                    switch (extension)
                    {
                        case ".xls": //For Excel 97-03.  
                            conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                            break;
                        case ".xlsx": //For Excel 07 and above.  
                            conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                            break;
                    }

                    try
                    {
                        DataTable dt = new DataTable();
                        conString = string.Format(conString, filePath);

                        using (OleDbConnection connExcel = new OleDbConnection(conString))
                        {
                            using (OleDbCommand cmdExcel = new OleDbCommand())
                            {
                                using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                                {
                                    cmdExcel.Connection = connExcel;

                                    //Get the name of First Sheet.  
                                    connExcel.Open();
                                    DataTable dtExcelSchema;
                                    dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                                    string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                                    connExcel.Close();

                                    //Read Data from First Sheet.  
                                    connExcel.Open();
                                    cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
                                    odaExcel.SelectCommand = cmdExcel;
                                    odaExcel.Fill(dt);
                                    connExcel.Close();
                                }
                            }
                        }

                        conString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(conString))
                        {
                            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                            {
                                //Set the database table name.  
                                sqlBulkCopy.DestinationTableName = "DONHANG";
                                con.Open();
                                sqlBulkCopy.WriteToServer(dt);
                                con.Close();
                                TempData["msg"] = "<script>alert('Tải đơn lên thành công!');</script>";
                                return Redirect("Index");
                                //return Redirect("../Dashboard/Index");
                            }
                        }
                    }

                    //catch (Exception ex)  
                    //{  
                    //    throw ex;  
                    //}  
                    catch (Exception e)
                    {
                        return Json("error" + e.Message);
                    }
                    //return RedirectToAction("Index");  
                }
            }
            //return View(postedFile);  
            return Json("no files were selected !");
        }

    }
}