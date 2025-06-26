using Microsoft.AspNetCore.Mvc;
using MedicalDeviceTracking.Data;
using MedicalDeviceTracking.Models;
using System.Linq;

namespace MedicalDeviceTracking.Controllers
{
    public class CentralRequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CentralRequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int hospitalId)
        {
            var requests = _context.CentralRequests
                                   .Where(r => r.HospitalId == hospitalId)
                                   .ToList();
            return View(requests);
        }
    }
}
