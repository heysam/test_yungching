using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using prjsam_sample.Models;
namespace prjsam_sample.Controllers
{
    public class tCustomerController : ApiController
    {
        dbCustomerEntities1 db = new dbCustomerEntities1();
        [Authorize]
        // GET: api/tCustomer
        public IEnumerable<tCustomer> Get()
        {
            return db.tCustomer.ToList();
        }

        [Authorize]
        // GET: api/tCustomer/5
        public tCustomer Get(string fCustId)
        {
            var customer = db.tCustomer
                .Where(m => m.fCustId == fCustId).FirstOrDefault();
            return customer;
        }

        [Authorize]
        // POST: api/tCustomer
        public int Post(tCustomer cust)
        {
            int num = 0;
            try
            {
                tCustomer customer = new tCustomer();
                customer.fCustId = cust.fCustId;
                customer.fName = cust.fName;
                customer.fPhone = cust.fPhone;
                customer.fAddress = cust.fAddress;
                db.tCustomer.Add(customer);
                num = db.SaveChanges();
            }
            catch (Exception ex)
            {
                num = 0;
            }
            return num;
        }

        [Authorize]
        // PUT: api/tCustomer/5
        public int Put(tCustomer cust)
        {
            int num = 0;
            try
            {
                var customer = db.tCustomer
                    .Where(m => m.fCustId == cust.fCustId).FirstOrDefault();
                customer.fName = cust.fName;
                customer.fPhone = cust.fPhone;
                customer.fAddress = cust.fAddress;
                num = db.SaveChanges();
            }
            catch (Exception ex)
            {
                num = 0;
            }
            return num;

        }

        [Authorize]
        // DELETE: api/tCustomer/5
        public int Delete(string fCustId)
        {
            int num = 0;
            try
            {
                var customer = db.tCustomer
                   .Where(m => m.fCustId == fCustId).FirstOrDefault();
                db.tCustomer.Remove(customer);
                num = db.SaveChanges();
            }
            catch (Exception ex)
            {
                num = 0;
            }
            return num;
        }
    }
}
