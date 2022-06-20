using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AuctionContext context;

        public CustomerController(AuctionContext context)
        {
            this.context = context;
        }
        public IActionResult Index(int pg = 1)
        {
            const int pageSize = 10;
            if(pg < 1) { pg = 1; }
            int recsCount = context.Items.Count();
            var pager  = new Pager(recsCount,pg,pageSize);
            int recSkip = (pg - 1) * pageSize;
            List<Item> items = context.Items.Skip(recSkip).Take(pager.PageSize).ToList();

            //List<Item> items = context.Items.ToList();
            this.ViewBag.Pager = pager;
            return View(items);
           // return View();
        }
        public IActionResult IndexAjax(int pg = 1)
        {
            const int pageSize = 10;
            if (pg < 1) { pg = 1; }
            int recsCount = context.Items.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            List<Item> items = context.Items.Skip(recSkip).Take(pager.PageSize).ToList();

            //List<Item> items = context.Items.ToList();
            this.ViewBag.Pager = pager;
            return View(items);
            // return View();
        }

        public IActionResult Details(int  Id)
        {
            var items = context.Items.Where(x => x.Id == Id).FirstOrDefault();

            return View(items);
        }

        [HttpGet]
        public ActionResult Edit (int Id)
        {
            var items = context.Items.Where (x => x.Id == Id).FirstOrDefault();
            if (items != null) { return View(items); }
            return View(null);
        }
        [HttpPost]
        public ActionResult Edit (Item item)
        {
            if (item == null) { return View(null); }
            context.Attach(item);
            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return View(item);
        }
        [HttpGet]
        public IActionResult Delete (int Id)
        {
            var item = context.Items.Where(x => x.Id == Id).FirstOrDefault();
            if(item != null) { return View(item); }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete (Item item)
        {
            if(item == null) { return View(null); }
            context.Attach(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet] 
        public IActionResult Create ()
        {
            return View();
        }
        [HttpPost] 
        public IActionResult Create (Item item )
        {
            if( item == null) { return View(null); }
            context.Attach(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            context.SaveChanges();
            return RedirectToAction ("Index");
        }
    }
}
