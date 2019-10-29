﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QLCafe.WEB.Context;
using QLCafe.WEB.Models.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace QLCafe.WEB.Controllers
{
    public class ProductsController : Controller
    {
        public static string datamax;
        UnitController unit = new UnitController();
        ProductTypesController productType = new ProductTypesController();
        public IActionResult Index(ProductsSearch model)
        {
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
        public IActionResult Details(int id)
        {
            var products = new ProductsDetail();
            var url = "https://localhost:44354/api/Products/detail/" + id;
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

                products = JsonConvert.DeserializeObject<ProductsDetail>(responseData);
            }
            return View(products);
        }
        public IActionResult Create()
        {
            TempData["Success"] = null;
            ViewBag.units = unit.GetUnits();
            ViewBag.ProductTypes = productType.GetProductTypes();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductsCreate model)
        {
            var files = HttpContext.Request.Form.Files;
            foreach (var Image in files)
            {
                if (Image != null && Image.Length > 0)
                {
                    var file = Image;
                    using (ProductDBContext dbContext = new ProductDBContext())
                    {
                        MemoryStream ms = new MemoryStream();
                        file.OpenReadStream().CopyTo(ms);

                        //System.Drawing.Image image = System.Drawing.Image.FromStream(ms);

                        Models.Products.ProductsCreate imageEntity = new Models.Products.ProductsCreate()
                        {
                            Data = Convert.ToBase64String(ms.ToArray()),
                        };
                        datamax = imageEntity.Data;
                    }
                }
            }
            model.Data = datamax;
            var createResult = false;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44354/api/Products/add");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(model);

                streamWriter.Write(json);
            }

            if (ModelState.IsValid)
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    createResult = bool.Parse(result);
                }
                if (createResult)
                {
                    TempData["Message"] = model.Name + " đã được thêm";
                }
                ViewBag.units = unit.GetUnits();
                ViewBag.ProductTypes = productType.GetProductTypes();
                ModelState.Clear();
                return View(new ProductsCreate() { });
            }

            TempData["Success"] = null;
            ViewBag.units = unit.GetUnits();
            ViewBag.ProductTypes = productType.GetProductTypes();
            return View();
        }
        public IActionResult Delete(int id)
        {
            var deleteResult = false;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44354/api/Products/delete/" + id);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "DELETE";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(id);

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                deleteResult = bool.Parse(result);
            }

            return RedirectToAction("Index", "Products");
        }
        public IActionResult Edit(int id)
        {
            var productsUpdate = new ProductsUpdate();
            var url = "https://localhost:44354/api/Products/get/" + id;
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
                productsUpdate = JsonConvert.DeserializeObject<ProductsUpdate>(responseData);
            }
            ViewBag.units = unit.GetUnits();
            ViewBag.ProductTypes = productType.GetProductTypes();
            return View(productsUpdate);
        }

        [HttpPost]
        public IActionResult Edit(ProductsUpdate model)
        {
            var files = HttpContext.Request.Form.Files;
            foreach (var Image in files)
            {
                if (Image != null && Image.Length > 0)
                {
                    var file = Image;
                    using (ProductDBContext dbContext = new ProductDBContext())
                    {
                        MemoryStream ms = new MemoryStream();
                        file.OpenReadStream().CopyTo(ms);


                        Models.Products.ProductsCreate imageEntity = new Models.Products.ProductsCreate()
                        {
                            Data = Convert.ToBase64String(ms.ToArray()),
                        };
                        datamax = imageEntity.Data;
                    }
                }
            }
            model.Data = datamax;
            var updateResult = false;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44354/api/Products/update");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(model);

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
            ViewBag.units = unit.GetUnits();
            ViewBag.ProductTypes = productType.GetProductTypes();
            return RedirectToAction("Index", "Products");
        }
        #region Ajax
        public IActionResult Products()
        {
            return View();
        }
        public JsonResult ProductsGetAlll()
        {
            var products = new List<Products>();
            var url = "https://localhost:44354/api/Products/gets";
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

                products = JsonConvert.DeserializeObject<List<Products>>(responseData);
            }
            return Json(new
            {
                data = products
            });
        }
        #endregion
    }
}