using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;
using AsyncContactMvc.Models;
using System.Diagnostics.Eventing.Reader;

namespace AsyncContactMvc.Repository
{
    public class ContactRepository : IContactRepository
    {
        private ContactContext db = new ContactContext();

        public async Task<List<Contact>> GetAllAsync()
        {
            return await db.Contacts.ToListAsync();
        }

        public async Task CreateAsync(Contact contact)
        {
            db.Contacts.Add(contact);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var contact=await db.Contacts.FindAsync(id);
            if(contact!=null)
            {
                db.Contacts.Remove(contact);
                await db.SaveChangesAsync();
            }
        }
    }
}