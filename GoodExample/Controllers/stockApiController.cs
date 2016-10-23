using EasySale.Core;
using EasySale.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EasySale.Controllers
{
    public class stockApiController : ApiController
    {
        // GET api/<controller>
        private AppDbContext db = new AppDbContext();

        [Route("api/stockApi/getCategory")]
        [HttpGet]
        public IEnumerable<catagory_tb> getCategory()
        {
            var List = db.categories.AsEnumerable();
            return List;
        }

        public IEnumerable<stock_tb> Get()
        {
            var stockList = db.stocks.Include("prices").AsEnumerable();
            return stockList;
        }

        //public stock_tb getProductById(string Id)
        //{
        //    int no = Convert.ToInt32(Id);
        //    var list = db.stocks.Include("prices").Where(x => x.stock_id == no).FirstOrDefault();
        //    return list;
        //}
        [Route("api/stockApi/update")]
        [HttpPost]
        public string update(stock_tb stock)
        {
            if (stock != null)
            {
                int no = Convert.ToInt32(stock.stock_id);
                var singleData = db.stocks.Include("prices").Where(x => x.stock_id == no).FirstOrDefault();
                singleData.barCode = stock.barCode;
                singleData.item_code = stock.item_code;
                singleData.catagory = stock.catagory;
                singleData.product_des = stock.product_des;
                singleData.qty_left = stock.qty_left;
                singleData.vendor = stock.vendor;
                singleData.prices.cost_price = stock.prices.cost_price;
                singleData.prices.selling_price = stock.prices.selling_price;
                singleData.prices.margin = stock.prices.margin;
                db.SaveChanges();
                return "Product Updated";
            }
            else
            {
                return "Invalid Employee";
            }
        }

        [Route("api/stockApi/add")]
        [HttpPost]
        public HttpResponseMessage Post(stock_tb stock)
        {
                if (stock != null)
                {
                    var checkBarcode = db.stocks.Where(x => x.barCode == stock.barCode).Count();
                    var checkItemCode = db.stocks.Where(x => x.item_code == stock.item_code).Count();
                    if (checkBarcode > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "The product with this barcode is already exist!");
                    }
                    else if (checkItemCode > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "The product with this Item Code is already exist!");
                    }
                    else
                    {
                        db.stocks.Add(stock);
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, "Product Added!");
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Invalid Product");
                }
        }


        [Route("api/stockApi/delete/{id}")]
        [HttpPost]
        public string deleteProduct(stock_tb stock)
        {
            if (stock != null)
            {
                int no = Convert.ToInt32(stock.stock_id);
                var list = db.stocks.Include("prices").Where(x => x.stock_id == no).FirstOrDefault();
                db.stocks.Remove(list);
                db.SaveChanges();
                return "Product Deleted";
            }
            else
            {
                return "Invalid Product";
            }
        }
    }
}
