using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using AsyncContactMvc.Models;
using AsyncContactMvc.Repository;

namespace AsyncContactMvc.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        IContactRepository repo = new ContactRepository();

        public async Task<ActionResult> Index()
        {
            var contacts =await repo.GetAllAsync();
            return View(contacts);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Contact contact)
        {
            if(ModelState.IsValid)
            {
                await repo.CreateAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        public async Task<ActionResult> Delete(long id)
        {
           
            var list= await repo.GetAllAsync();
            var contact=list.Find(c=>c.Id==id);
            return View(contact);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            await repo.DeleteAsync(id);
            return RedirectToAction("Index");
        }


    }
}