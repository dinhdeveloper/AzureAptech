using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SinhVienService.Controllers
{
    public class StudentController : ApiController
    {
        StudentsDataContext st = new StudentsDataContext();

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
                           item.soDienThoai
                       };
            return Ok(list);
        }

        //get mot sinh vien
        [HttpGet]
        [ActionName("getOneStudent")]
        public IHttpActionResult getOneStudent(string maSV)
        {
            var list = from item in st.SinhViens
                       where item.maSV == maSV
                       select new
                       {
                           item.maSV,
                           item.hoTenSV,
                           item.diaChi,
                           item.soDienThoai
                       };
            return Ok(list);
        }

        // them sinh vien
        [HttpPost]
        [ActionName("addStudent")]
        public IHttpActionResult addStudent([FromBody] SinhVien sinhVien)
        {
            try
            {
                SinhVien sv = st.SinhViens.FirstOrDefault(x => x.maSV == sinhVien.maSV);
                if (sv.maSV == sinhVien.maSV)
                {
                    return Ok("Đã trùng Mã Sinh Viên");
                }
                if (string.IsNullOrEmpty(sinhVien.maSV))
                {
                    return Ok(new HttpResponseMessage(HttpStatusCode.NotModified));
                }
                //insert data
                st.SinhViens.InsertOnSubmit(sinhVien);
                st.SubmitChanges();

                return Ok(new HttpResponseMessage(HttpStatusCode.NotModified));
            }
            catch(Exception ex)
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
                if(sinhVien.maSV != null)
                {
                    sv.maSV = sinhVien.maSV;
                }
                if (sinhVien.hoTenSV != null)
                {
                    sv.hoTenSV = sinhVien.hoTenSV;
                }
                if (sinhVien.diaChi != null)
                {
                    sv.diaChi = sinhVien.diaChi;
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
        public IHttpActionResult deleteStudent(int id)
        {
            try
            {
                SinhVien sv = st.SinhViens.FirstOrDefault(x => x.id == id);
                if(sv == null)
                {
                    return NotFound();
                }

                st.SinhViens.DeleteOnSubmit(sv);
                st.SubmitChanges();

                return Ok(true);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
