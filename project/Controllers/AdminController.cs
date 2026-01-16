using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.Models;

namespace project.Controllers
{
    // هذا السطر يقوم بحماية الكلاس بالكامل
    // أي شخص ليس "Admin" سيتم طرده قبل الوصول لأي دالة هنا
    [SessionCheck("Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public AdminController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // --- لوحة التحكم (Dashboard) ---
        public IActionResult Dashboard()
        {
            var now = DateTime.Now;

            // ===== 1️⃣ جلب جميع الفعاليات وترتيبها (القادمة أولاً) =====
            var events = _dbContext.Events
                .AsEnumerable() // لأننا نستخدم Date + TimeSpan
                .OrderBy(e => (e.Date.Date + e.StartTime) < now) // القادمة أولاً
                .ThenBy(e => e.Date.Date + e.StartTime)
                .ToList();

            // ===== 2️⃣ إحصائيات عامة =====
            ViewBag.StudentCount = _dbContext.Users.Count(u => u.Role == "Student");

            // عدد الفعاليات القادمة فقط
            ViewBag.EventCount = events.Count(e => (e.Date.Date + e.StartTime) >= now);

            // الحجوزات النشطة للفعاليات القادمة فقط
            ViewBag.ActiveBookings = _dbContext.Rolls
    .Include(r => r.Event)
    .Count(r =>
        r.States == "active" &&
        (
            r.Event.Date > now.Date ||
            (r.Event.Date == now.Date && r.Event.StartTime >= now.TimeOfDay)
        )
    );

            // السعة الكلية للفعاليات القادمة
            ViewBag.TotalCapacity = events
                .Where(e => (e.Date.Date + e.StartTime) >= now)
                .Sum(e => e.Limit);

            // ===== 3️⃣ إحصائيات شهرية (للـ Charts) =====
            var monthlyEvents = events
                .Where(e => (e.Date.Date + e.StartTime) >= now)
                .GroupBy(e => e.Date.Month)
                .Select(g => new
                {
                    Month = g.Key,
                    Count = g.Count()
                })
                .OrderBy(x => x.Month)
                .ToList();

            ViewBag.MonthLabels = monthlyEvents
                .Select(x => System.Globalization.CultureInfo
                    .CurrentCulture.DateTimeFormat.GetMonthName(x.Month))
                .ToList();

            ViewBag.MonthCounts = monthlyEvents
                .Select(x => x.Count)
                .ToList();

            // ===== 4️⃣ إرسال الفعاليات للـ View =====
            return View(events);
        }


        // --- إضافة فعالية جديدة ---
        public IActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEvent(Event model)
        {
            // إزالة الـ Rolls من التحقق لأننا لا نرسلها عند الإنشاء
            ModelState.Remove("Rolls");

            if (ModelState.IsValid)
            {
                // منع إضافة تاريخ في الماضي
                if (model.Date < DateTime.Now)
                {
                    ModelState.AddModelError("Date", "لا يمكن إضافة فعالية بتاريخ قديم");
                    return View(model);
                }

                _dbContext.Events.Add(model);
                _dbContext.SaveChanges();
                TempData["msg"] = "تم إضافة الفعالية بنجاح";
                return RedirectToAction("Dashboard");
            }
            return View(model);
        }

        // --- تعديل فعالية ---
        public IActionResult EditEvent(int id)
        {
            var ev = _dbContext.Events.Find(id);
            if (ev == null) return NotFound();
            return View(ev);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditEvent(Event model)
        {
            ModelState.Remove("Rolls");

            if (ModelState.IsValid)
            {
                // يمكن إضافة شرط التاريخ هنا أيضاً إذا أردت منع تعديل التاريخ للماضي
                _dbContext.Events.Update(model);
                _dbContext.SaveChanges();
                TempData["msg"] = "تم تعديل الفعالية بنجاح";
                return RedirectToAction("Dashboard");
            }
            return View(model);
        }

        // --- حذف فعالية ---
        public IActionResult DeleteEvent(int id)
        {
            var ev = _dbContext.Events.Find(id);
            if (ev == null) return NotFound();
            return View(ev);
        }

        [HttpPost, ActionName("DeleteEvent")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var ev = _dbContext.Events.Find(id);
            if (ev != null)
            {
                _dbContext.Events.Remove(ev);
                _dbContext.SaveChanges();
                TempData["msg"] = "تم حذف الفعالية وحجوزاتها بنجاح";
            }
            return RedirectToAction("Dashboard");
        }

        // --- عرض الطلاب المسجلين في فعالية محددة ---
        public IActionResult ViewStudents(int id)
        {
            var ev = _dbContext.Events
                .Include(e => e.Rolls)
                .ThenInclude(r => r.User)
                .FirstOrDefault(e => e.Id == id);

            if (ev == null) return NotFound();

            // إرسال عدد الحضور الفعلي (Active) فقط للفيو ليظهر بجانب العنوان مثلاً
            ViewBag.ActiveCount = ev.Rolls.Count(r => r.States == "active");
            ViewBag.WaitingCount = ev.Rolls.Count(r => r.States == "waiting");
            ViewBag.CancelCount = ev.Rolls.Count(r => r.States == "cancelled");

            

            return View(ev);
        }
    }
}