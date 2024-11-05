using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class DoctorsController : Controller
{
	private readonly MyContext _context;

	public DoctorsController(MyContext context)
	{
		_context = context;
	}

	// GET: Doctors
	public IActionResult Index()
	{
		return View(_context.Doctors.ToList()); // List all doctors
	}

	// GET: Doctors/Details/5
	public IActionResult Details(int id)
	{
		var doctor = _context.Doctors.Find(id);
		if (doctor == null) return NotFound();
		return View(doctor);
	}

	// GET: Doctors/Create
	public IActionResult Create()
	{
		return View();
	}

	// POST: Doctors/Create
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Create(Doctor doctor)
	{
		if (ModelState.IsValid)
		{
			_context.Doctors.Add(doctor);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
		return View(doctor);
	}

	// GET: Doctors/Edit/5
	public IActionResult Edit(int id)
	{
		var doctor = _context.Doctors.Find(id);
		if (doctor == null) return NotFound();
		return View(doctor);
	}

	// POST: Doctors/Edit/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Edit(int id, Doctor doctor)
	{
		if (id != doctor.Id) return NotFound();
		if (ModelState.IsValid)
		{
			_context.Update(doctor);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
		return View(doctor);
	}

	// GET: Doctors/Delete/5
	public IActionResult Delete(int id)
	{
		var doctor = _context.Doctors.Find(id);
		if (doctor == null) return NotFound();
		return View(doctor);
	}

	// POST: Doctors/Delete/5
	[HttpPost, ActionName("Delete")]
	[ValidateAntiForgeryToken]
	public IActionResult DeleteConfirmed(int id)
	{
		var doctor = _context.Doctors.Find(id);
		if (doctor != null)
		{
			_context.Doctors.Remove(doctor);
			_context.SaveChanges();
		}
		return RedirectToAction(nameof(Index));
	}
}

