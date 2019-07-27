using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Net.Http;
using Newtonsoft.Json;
using SinhVienClient.Models;

namespace SinhVienClient.Controllers
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
        public ActionResult Edit(string id)
        {
            SinhVien sv = new SinhVien();
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

        [HttpPost]
        public ActionResult Create(SinhVien sv)
        {
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri("http://sinhvien.azurewebsites.net/api/");
            HttpResponseMessage responseTask = http.PutAsJsonAsync("/Student/addStudent", sv).Result;
            return RedirectToAction("Index");
        }
    }
}
