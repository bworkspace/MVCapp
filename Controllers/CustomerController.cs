using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCDemoApp.Models;


namespace MVCDemoApp.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDataAccessLayer objcust = new CustomerDataAccessLayer();

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Customer> lstEmployee = new List<Customer>();
            lstEmployee = objcust.GetAllCustomer().ToList();

            return View(lstEmployee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Customer employee)
        {
            if (ModelState.IsValid)
            {
                objcust.AddCustomer(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer cust = objcust.GetCustomerData(id);

            if (cust == null)
            {
                return NotFound();
            }
            return View(cust);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Customer employee)
        {
            if (id != employee.Accountno)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objcust.UpdateCustomer(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer employee = objcust.GetCustomerData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer employee = objcust.GetCustomerData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            objcust.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
}
