using EntityFrameWorkDemo1.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameWorkDemo1.Controllers
{
	public class StaffController : Controller
	{
		public IActionResult Index()
		{
			DoctorDb2Context db = new DoctorDb2Context();
			List<Staff> staff=db.Staff.ToList();
			return View(staff);
		}

		[HttpGet]
		public IActionResult Create()
		{
			Staff staff=new Staff();
			return View(staff);
		}
		[HttpPost]
		public IActionResult Create(Staff staff)
		{
			DoctorDb2Context db=new DoctorDb2Context();
			db.Staff.Add(staff);
			db.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Update(int id) 
		{
			DoctorDb2Context db = new DoctorDb2Context();
			var staff = db.Staff.FirstOrDefault(x => x.Id == id);
			db.SaveChanges();

			return View(staff);
		}

		[HttpPost]
		public IActionResult Update(Staff staff) 
		{
			DoctorDb2Context db= new DoctorDb2Context();
			var staffToUpdate=db.Staff.FirstOrDefault(x=>x.Id==staff.Id);
			staffToUpdate.Name=staff.Name;
			staffToUpdate.Work=staff.Work;
			db.SaveChanges();
			
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
		{
			DoctorDb2Context db= new DoctorDb2Context();
			var staff=db.Staff.FirstOrDefault(x => x.Id == id);
			db.Staff.Remove(staff);
			db.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}
