using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Service.Controllers
{
    public class StudentController : ApiController
    {
        StudentDataContext st = new StudentDataContext();

        //Lay tat ca sinh vien
        [HttpGet]
        [ActionName("getAllStudent")]
        public IHttpActionResult getAllStudent()
        {
            var list = from item in st.SinhViens
                       select new
                       {
                           item.maSV,
                           item.hoTenSV,
                           item.diaChi,
                           item.email,
                           item.soDienThoai
                       };
            return Ok(list);
        }

        //get mot sinh vien
        [HttpGet]
        [ActionName("getOneStudent")]
        public IHttpActionResult getOneStudent(int maSV)
        {
            var list = from item in st.SinhViens
                       where item.maSV == maSV
                       select new
                       {
                           item.maSV,
                           item.hoTenSV,
                           item.diaChi,
                           item.email,
                           item.soDienThoai
                       };
            return Ok(list);
        }

        // them sinh vien
        [HttpPost]
        [ActionName("addStudent")]
        public IHttpActionResult addStudent([FromBody] SinhVien sinhVien)
        {
            StudentDataContext st = new StudentDataContext();
            try
            {
                //SinhVien sv = st.SinhViens.FirstOrDefault(x => x.maSV == sinhVien.maSV);
                //if (sv.maSV == sinhVien.maSV)
                //{
                //    return Ok("Đã trùng Mã Sinh Viên");
                //}
                //if (string.IsNullOrEmpty(sinhVien.maSV))
                //{
                //    return Ok(new HttpResponseMessage(HttpStatusCode.NotModified));
                //}
                //insert data
                st.SinhViens.InsertOnSubmit(sinhVien);
                st.SubmitChanges();

                return Ok(new HttpResponseMessage(HttpStatusCode.NotModified));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //sua sinh vien
        [HttpPut]
        [ActionName("editStudent")]
        public IHttpActionResult editStudent([FromBody] SinhVien sinhVien)
        {
            try
            {
                SinhVien sv = st.SinhViens.FirstOrDefault(x => x.maSV == sinhVien.maSV);
                if (sv == null)
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
                if (sinhVien.hoTenSV != null)
                {
                    sv.hoTenSV = sinhVien.hoTenSV;
                }
                if (sinhVien.diaChi != null)
                {
                    sv.diaChi = sinhVien.diaChi;
                }
                if (sinhVien.email != null)
                {
                    sv.email = sinhVien.email;
                }
                if (sinhVien.soDienThoai != null)
                {
                    sv.soDienThoai = sinhVien.soDienThoai;
                }

                st.SubmitChanges();
                return Ok(sv);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //xoa sinh vien
        [HttpGet]
        [ActionName("deleteStudent")]
        public IHttpActionResult deleteStudent(int maSV)
        {
            try
            {
                SinhVien sv = st.SinhViens.FirstOrDefault(x => x.maSV == maSV);
                if (sv == null)
                {
                    return NotFound();
                }

                st.SinhViens.DeleteOnSubmit(sv);
                st.SubmitChanges();

                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //search
        [HttpGet]
        [ActionName("Search")]
        public IHttpActionResult Search(string search)
        {
            var result = (from c in st.SinhViens
                          where (c.maSV == Convert.ToInt32(search) ||
                          c.hoTenSV.Contains(search) || c.diaChi.Contains(search) ||
                          c.soDienThoai.Contains(search) || c.email.Contains(search))
                          select new
                          {
                              c.maSV,
                              c.hoTenSV,
                              c.diaChi,
                              c.email,
                              c.soDienThoai
                          });

            return Ok(result);
        }
    }
}
