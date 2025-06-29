using Microsoft.AspNetCore.Mvc;
using MedicalDeviceTracking.Models;
using System.Collections.Generic;
using System.Linq;

namespace MedicalDeviceTracking.Controllers
{
    public class HospitalController : Controller
    {
        public IActionResult Index()
        {
            var groups = GetHospitalGroups();
            return View(groups);
        }

        // ✅ Cihaz Arama İşlemi
        [HttpGet]
        public IActionResult Search(string query)
        {
            var allHospitals = GetAllHospitals();

            // Örnek sabit cihaz talepleri (gerçek projede DB'den çekilir)
            var deviceRequests = new List<DeviceRequest>
            {
                new DeviceRequest { DeviceName = "Röntgen", HospitalId = 1 },
                new DeviceRequest { DeviceName = "Ultrason", HospitalId = 2 },
                new DeviceRequest { DeviceName = "Röntgen", HospitalId = 3 },
                new DeviceRequest { DeviceName = "EKG", HospitalId = 5 }
            };

            // Arama filtresi
            var filtered = deviceRequests
                .Where(d => !string.IsNullOrEmpty(query) && d.DeviceName.ToLower().Contains(query.ToLower()))
                .Select(d => new DeviceRequest
                {
                    DeviceName = d.DeviceName,
                    HospitalId = d.HospitalId,
                    Hospital = allHospitals.FirstOrDefault(h => h.Id == d.HospitalId)
                })
                .ToList();

            return View(filtered);
        }

        // Hastane grupları
        private List<HospitalGroup> GetHospitalGroups()
        {
            var allHospitals = GetAllHospitals();

            var groups = allHospitals
                .GroupBy(h => h.GroupCode)
                .Select(g => new HospitalGroup
                {
                    GroupCode = g.Key,
                    Hospitals = g.ToList()
                })
                .ToList();

            return groups;
        }

        // Tek bir yerde sabit hastaneler
        private List<Hospital> GetAllHospitals()
        {
            return new List<Hospital>
            {
                new Hospital { Id = 1, Name = "Sivas Numune Hastanesi", GroupCode = "A" },
                new Hospital { Id = 2, Name = "Sivas Devlet Hastanesi", GroupCode = "B" },
                new Hospital { Id = 3, Name = "Şarkışla Devlet Hastanesi", GroupCode = "B" },
                new Hospital { Id = 4, Name = "Suşehri Devlet Hastanesi", GroupCode = "B" },
                new Hospital { Id = 5, Name = "Yıldızeli Devlet Hastanesi", GroupCode = "C" },
                new Hospital { Id = 6, Name = "Divriği Devlet Hastanesi", GroupCode = "D" },
                new Hospital { Id = 7, Name = "Gemerek Devlet Hastanesi", GroupCode = "D" },
                new Hospital { Id = 8, Name = "Gürün Devlet Hastanesi", GroupCode = "D" },
                new Hospital { Id = 9, Name = "Kangal Devlet Hastanesi", GroupCode = "D" },
                new Hospital { Id = 10, Name = "Zara Devlet Hastanesi", GroupCode = "D" },
                new Hospital { Id = 11, Name = "Akıncılar İlçe Hastanesi", GroupCode = "E", ParentHospitalId = 3 },
                new Hospital { Id = 12, Name = "Altınyayla İlçe Hastanesi", GroupCode = "E", ParentHospitalId = 3 },
                new Hospital { Id = 13, Name = "Doğanşar İlçe Hastanesi", GroupCode = "E", ParentHospitalId = 10 },
                new Hospital { Id = 14, Name = "Gölova İlçe Hastanesi", GroupCode = "E", ParentHospitalId = 4 },
                new Hospital { Id = 15, Name = "Hafik İlçe Hastanesi", GroupCode = "E", ParentHospitalId = 10 },
                new Hospital { Id = 16, Name = "İmranlı İlçe Hastanesi", GroupCode = "E", ParentHospitalId = 10 },
                new Hospital { Id = 17, Name = "Koyulhisar İlçe Hastanesi", GroupCode = "E", ParentHospitalId = 4 },
                new Hospital { Id = 18, Name = "Ulaş İlçe Hastanesi", GroupCode = "E", ParentHospitalId = 2 },
                new Hospital { Id = 19, Name = "Sivas Ağız ve Diş Sağlığı Hastanesi", GroupCode = "ADSH" }
            };
        }
    }

    // ✅ Mini modeller (ayrı dosyada varsa oradan çek)
    public class DeviceRequest
    {
        public string? DeviceName { get; set; }
        public int HospitalId { get; set; }
        public Hospital? Hospital { get; set; }
    }
}
