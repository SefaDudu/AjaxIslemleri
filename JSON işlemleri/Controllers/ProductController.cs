using JSON_işlemleri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JSON_işlemleri.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> products = new List<Product>()
        {
            new Product()
            {
                Id=1,
                ProductName="sefa"
            },
             new Product()
            {
                Id=2,
                ProductName="kaan"
            }
        };

        // GET: Product
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Add(Product product)
        {
            products.Add(product);
            return Json(true);
        }
        public JsonResult Delete(int id)
        {
            products.RemoveAll(x => x.Id == id);
            return Json(true,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update(int id,Product product)
        {
            products.FirstOrDefault(x => x.Id == id).ProductName = product.ProductName;


            return Json(true);
        }
        public JsonResult GetById(int id)
        {
            
            return Json(products.FirstOrDefault(x => x.Id == id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAll()
        {

            return Json(products, JsonRequestBehavior.AllowGet);
        }

    }
}