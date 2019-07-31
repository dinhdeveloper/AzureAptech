    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Net.Http;
using WebApplication1.Models;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<SinhVien> Listsv = new List<SinhVien>();
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri("http://sinhvien.azurewebsites.net/api/");
            var respone = http.GetAsync("student/getAllStudent");
            respone.Wait();
            var result = respone.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<SinhVien>>();
                readTask.Wait();
                Listsv = readTask.Result;
            }
            else { }
            return View(Listsv);
        }
        public ActionResult Edit(int id)
        {
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri("http://sinhvien.azurewebsites.net/api/");
            HttpResponseMessage responseTask = http.GetAsync("student/getOneStudent?maSV=" + id.ToString()).Result;
            if (responseTask.IsSuccessStatusCode)
            {
                var sinhVienJSON = responseTask.Content.ReadAsStringAsync().Result;
                var lstSinhVien = JsonConvert.DeserializeObject<List<SinhVien>>(sinhVienJSON);
                return View(lstSinhVien[0]);
            }
            else
            {
                return null;
            }

        }
        [HttpPost]
        public ActionResult Edit(SinhVien sv)
        {
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri("http://sinhvien.azurewebsites.net/api/");
            HttpResponseMessage responseTask = http.PutAsJsonAsync("student/EditStudent", sv).Result;

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }
        //them sinh vien
        [HttpPost]
        public ActionResult Create(SinhVien sv)
        {
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri("http://sinhvien.azurewebsites.net/api/");
            HttpResponseMessage respone = http.PostAsJsonAsync("Student/addStudent", sv).Result;
            if (respone.IsSuccessStatusCode)
            {
                sv = respone.Content.ReadAsAsync<SinhVien>().Result;
                return RedirectToAction("Index");
            }
            else
            {
                return null;
            }
        }

        //xoa sinh vien
        public ActionResult Delete(int id)
        {

            SinhVien sv = new SinhVien();
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri("http://sinhvien.azurewebsites.net/api/");
            HttpResponseMessage responseTask = http.DeleteAsync("Student/deleteStudent?maSV=" + id.ToString()).Result;
            if (responseTask.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return null;
            }
        }

        //public ActionResult Search(SinhVien sv)
        //{
        //    return View(sv);
        //}

        public ActionResult Search(string keysw)
        {
            List<SinhVien> Listsv = new List<SinhVien>();
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri("http://sinhvien.azurewebsites.net/api/");
            HttpResponseMessage responseTask = http.GetAsync("Student/Search?search=" + keysw.ToString()).Result;
            if (responseTask.IsSuccessStatusCode)
            {
                Listsv = responseTask.Content.ReadAsAsync<List<SinhVien>>().Result;
                foreach (SinhVien sv in Listsv)
                {
                    if (string.IsNullOrEmpty(keysw))
                    {
                        return View(Listsv);
                    }
                }
                return View(Listsv);
            }
            else
            {
                return null;
            }
        }
    }
}
