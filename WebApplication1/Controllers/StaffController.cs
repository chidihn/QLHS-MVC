using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StaffController : Controller
    {
        StaffDataAccessLayer StaffDataAccessLayer = null;
        public StaffController()
        { 
            StaffDataAccessLayer = new StaffDataAccessLayer();
        }

        // GET: Staff
        public ActionResult Index()
        {
            IEnumerable<Staff> Staffs = StaffDataAccessLayer.GetAllStaff();
            return View(Staffs);
        }

        // GET: Staff/Details/5
        public ActionResult Details(int? id)
        {
            Staff Staff = StaffDataAccessLayer.GetStaffData(id);
            return View(Staff);

        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Staff Staff)
        {
            try
            {
                // TODO: Add insert logic here
                StaffDataAccessLayer.AddStaff(Staff);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int? id)
        {
            Staff Staff = StaffDataAccessLayer.GetStaffData(id);
            return View(Staff);
        }

        // POST: Staff/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Staff Staff)
        {
            try
            {
                // TODO: Add update logic here
                StaffDataAccessLayer.UpdateStaff(Staff);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(int? id)
        {
            Staff Staff = StaffDataAccessLayer.GetStaffData(id);
            return View(Staff);
        }

        // POST: Staff/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Staff Staff)
        {
            try
            {
                // TODO: Add delete logic here
                StaffDataAccessLayer.DeleteStaff(Staff.ID);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
