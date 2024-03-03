using Microsoft.AspNetCore.Mvc;

using StaffsManagement.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffsManagement.Controllers
{
    public class StaffController : Controller
    {
        private static List<Staff> _staffList = new List<Staff>()
        {
            new Staff { StaffID = 1, StaffName = "Đông", StaffAge = 30, StaffAddress = "Cà Mau" },
            new Staff { StaffID = 2, StaffName = "Đông2", StaffAge = 25, StaffAddress = "Sài Gòn" },
            new Staff { StaffID = 3, StaffName = "Đông2", StaffAge = 34, StaffAddress = "Vũng Tàu" },
            new Staff { StaffID = 4, StaffName = "Đông3", StaffAge = 55, StaffAddress = "Sóc Trăng" },
            new Staff { StaffID = 5, StaffName = "Đông4", StaffAge = 90, StaffAddress = "Sa Đéc" },
            new Staff { StaffID = 6, StaffName = "Đông5", StaffAge = 12, StaffAddress = "Hà Nội" }
        };

        public IActionResult Index()
        {
            return View(_staffList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Staff staff)
        {
           
            int maxId = _staffList.Max(s => s.StaffID);
            staff.StaffID = maxId + 1;

            _staffList.Add(staff);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Staff staff = _staffList.FirstOrDefault(s => s.StaffID == id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        [HttpPost]
        public IActionResult Edit(Staff staff)
        {
            Staff existingStaff = _staffList.FirstOrDefault(s => s.StaffID == staff.StaffID);
            if (existingStaff != null)
            {
                existingStaff.StaffName = staff.StaffName;
                existingStaff.StaffAge = staff.StaffAge;
                existingStaff.StaffAddress = staff.StaffAddress;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Staff staff = _staffList.FirstOrDefault(s => s.StaffID == id);
            if (staff != null)
            {
                _staffList.Remove(staff);
            }
            return RedirectToAction("Index");
        }
    }
}
