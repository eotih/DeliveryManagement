using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManaDeli.Models;
using System.Data.Entity;
using ManaDeli.Controllers;


namespace ManaDeli.Models
{
    public class ManaDeli_DB
    { 
        private ManaDeliEntities abc = new ManaDeliEntities();
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public List<DONHANG> ListAll()
        {
            List<DONHANG> lst = new List<DONHANG>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SelectDonHang", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new DONHANG
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        mavandon = Convert.ToInt32(rdr["mavandon"]),
                        madonhang = Convert.ToInt32(rdr["madonhang"]),
                        cannang = Convert.ToInt32(rdr["cannang"]),
                        soluong = Convert.ToInt32(rdr["soluong"]),
                        giatri = Convert.ToInt32(rdr["giatri"]),
                        phiship = Convert.ToInt32(rdr["phiship"]),
                        cod = Convert.ToInt32(rdr["cod"]),
                        sdtnguoinhan = rdr["sdtnguoinhan"].ToString(),
                        tennguoigui = rdr["tennguoigui"].ToString(),
                        tennguoinhan = rdr["tennguoinhan"].ToString(),
                        dichvu = rdr["dichvu"].ToString(),
                        trangthai = rdr["trangthai"].ToString(),
                        diachinguoinhan = rdr["diachinguoinhan"].ToString(),
                        loaihang = rdr["loaihang"].ToString(),
                        ghichu = rdr["ghichu"].ToString(),
                        ngaytaodon = Convert.ToDateTime(rdr["ngaytaodon"]),
                        Shipper = rdr["Shipper"].ToString()
                    });
                }
                return lst;
            }
        }

        public int Update(DONHANG emp)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("UpdateDonHang", con);
                com.CommandType = CommandType.StoredProcedure;
                //com.Parameters.AddWithValue("@Id", emp.Id);
                com.Parameters.AddWithValue("@mavandon", emp.mavandon);
                com.Parameters.AddWithValue("@madonhang", emp.madonhang);
                com.Parameters.AddWithValue("@tennguoigui", emp.tennguoigui);
                com.Parameters.AddWithValue("@tennguoinhan", emp.tennguoinhan);
                com.Parameters.AddWithValue("@sdtnguoinhan", emp.sdtnguoinhan);
                com.Parameters.AddWithValue("@diachinguoinhan", emp.diachinguoinhan);
                com.Parameters.AddWithValue("@soluong", emp.soluong);
                com.Parameters.AddWithValue("@giatri", emp.giatri);
                com.Parameters.AddWithValue("@dichvu", emp.dichvu);
                com.Parameters.AddWithValue("@loaihang", emp.loaihang);
                com.Parameters.AddWithValue("@ghichu", emp.ghichu);
                com.Parameters.AddWithValue("@trangthai", emp.trangthai);
                com.Parameters.AddWithValue("@phiship", emp.phiship);
                com.Parameters.AddWithValue("@cod", emp.cod);
                com.Parameters.AddWithValue("@ngaytaodon", emp.ngaytaodon);
                com.Parameters.AddWithValue("@Action", "Update");
                i = com.ExecuteNonQuery();
            }
            return i;
        }
       
        //Method for Deleting an Employee
        public int Delete(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("DeleteDonHang", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", ID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
        public int DeleteTaiKhoan(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("DeleteTaiKhoan", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", ID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
        public List<TAIKHOAN> ListAllTaiKhoan()
        {
            List<TAIKHOAN> lst = new List<TAIKHOAN>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SelectTaiKhoan", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new TAIKHOAN
                    {
                        id = Convert.ToInt32(rdr["id"]),
                        phone = Convert.ToInt32(rdr["phone"]),
                        hoten = rdr["hoten"].ToString(),
                        email = rdr["email"].ToString(),
                        username = rdr["username"].ToString(),
                        pass = rdr["pass"].ToString(),
                        diachi = rdr["diachi"].ToString(),
                        quyen = rdr["quyen"].ToString(),
                    });
                }
                return lst;
            }
        }
        public List<TAIKHOAN> SelectByID(int ID)
        {
            List<TAIKHOAN> lst = new List<TAIKHOAN>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SelectByID", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new TAIKHOAN
                    {
                        id = Convert.ToInt32(rdr["id"]),
                        phone = Convert.ToInt32(rdr["phone"]),
                        hoten = rdr["hoten"].ToString(),
                        email = rdr["email"].ToString(),
                        username = rdr["username"].ToString(),
                        pass = rdr["pass"].ToString(),
                        diachi = rdr["diachi"].ToString(),
                        quyen = rdr["quyen"].ToString(),
                    });
                }
                return lst;
            }
        }
        public int UpdateProfile(TAIKHOAN emp)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("UpdateTaiKhoanAdmin", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", emp.id);
                com.Parameters.AddWithValue("@hoten", emp.hoten);
                com.Parameters.AddWithValue("@email", emp.email);
                com.Parameters.AddWithValue("@phone", emp.phone);
                com.Parameters.AddWithValue("@diachi", emp.diachi);
                com.Parameters.AddWithValue("@quyen", emp.quyen);
                com.Parameters.AddWithValue("@Action", "Update");
                i = com.ExecuteNonQuery();
            }
            return i;
        }
        //Method for Adding an Employee
        public int AddShipper(DONHANG emp)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("AddShipper", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", emp.Id);
                com.Parameters.AddWithValue("@Shipper", emp.Shipper);
                com.Parameters.AddWithValue("@Action", "Update");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

    }

}
