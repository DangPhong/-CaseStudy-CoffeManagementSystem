using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QLCafe.WEB.Models.BillDetail;
using QLCafe.WEB.Models.Bills;
using QLCafe.WEB.Models.Products;

namespace QLCafe.WEB.Controllers
{
    public class BillDetailController : Controller
    {
        private static int tableCoffeeId = 0;
        private static int billId = 0 ;
        #region LẤY DANH SÁCH CÁC MÓN ĐÃ GỌI TRONG BÀN
        public IActionResult BillDetailsGetByIdTable(int id)
        {
            var billDetails = new List<BillDetails>();
            var url = "https://localhost:44354/api/billdetail/get/" + id;
            // gọi qua đường dẫn tạo 1 request với đường dẫn
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream responseStream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(responseStream);
                    try
                    {
                        responseData = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)responseStream).Dispose();
                }
                billDetails = JsonConvert.DeserializeObject<List<BillDetails>>(responseData);
            }
            return View(billDetails);
        }
        #endregion

        #region HIỂN THỊ HÓA ĐƠN BÁN HÀNG
        public IActionResult BillDetailsViewAll(int Id)
        {
            tableCoffeeId = Id;
            var billDetailsViewAll = new List<BillDetailsViewAll>();
            var url = "https://localhost:44354/api/billdetail/billdetailView/" + Id;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream responseStream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(responseStream);
                    try
                    {
                        responseData = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)responseStream)?.Dispose();
                }

                billDetailsViewAll = JsonConvert.DeserializeObject<List<BillDetailsViewAll>>(responseData);
            }
            ViewBag.NameTable = ListTableCoffee().Where(t => t.ID == Id).FirstOrDefault().Name;
            return View(billDetailsViewAll);
        }
        #endregion

        #region XÓA MÓN ĐÃ GỌI
        public IActionResult BillDetailDelete(int id)
        {
            var result = 0;
            var url = "https://localhost:44354/api/billdetail/delete/" + id;
            // gọi qua đường dẫn tạo 1 request với đường dẫn
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "DELETE";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream responseStream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(responseStream);
                    try
                    {
                        responseData = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)responseStream).Dispose();
                }
                result = JsonConvert.DeserializeObject<int>(responseData);
            }
            if (result > 0)
            {
                return RedirectToAction("BillDetailsViewAll", "BillDetail", new { Id = tableCoffeeId });
            }
            else
            {
                return RedirectToAction("Index", "TableCoffees");
            }
        }
        #endregion
        #region TÌM KIẾM MÓN
        public IActionResult ProductsSearch(ProductsSearch model, int Id)
        {
            billId = Id;
            var products = new List<Products>();
            var url = "https://localhost:44354/api/products/search";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(model);
                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                products = JsonConvert.DeserializeObject<List<Products>>(result);
            }
            return View(products);
        }
        #endregion

        #region GỌI MÓN
        [HttpGet]
        public IActionResult BillDetailAdd(BillDetailAdd model, int Id)
        {
            var result = false;
            model.BillID = billId;
            model.ProductID = Id;
            var url = "https://localhost:44354/api/billdetail/add";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(model);
                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var resResult = streamReader.ReadToEnd();
                result = bool.Parse(resResult);
            }
            return RedirectToAction("ProductsSearch", "BillDetail", new { Id = billId});
        }
        #endregion

        #region THANH TOÁN HÓA ĐƠN
        [HttpGet]
        public IActionResult Pay(int Id)
        {
            var updateResult = false;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44354/api/billdetail/pay/" + Id);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(Id);

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                updateResult = bool.Parse(result);
            }
            if (updateResult)
            {
                TempData["Message"] = "User has been update successfully";
            }
            return RedirectToAction("Index", "TableCoffees");
        }
        #endregion

        #region LIST BÀN COFFEE ĐỂ DÙNG VIEW BAG
        private List<TableCoffee> ListTableCoffee()
        {
            var tableCoffees = new List<TableCoffee>();
            var url = "https://localhost:44354/api/TableCoffees/getall";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream responseStream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(responseStream);
                    try
                    {
                        responseData = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)responseStream)?.Dispose();
                }

                tableCoffees = JsonConvert.DeserializeObject<List<TableCoffee>>(responseData);
            }
            return tableCoffees;
        }
        #endregion
    }
}