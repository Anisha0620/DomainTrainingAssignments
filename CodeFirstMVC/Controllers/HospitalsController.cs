using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class HospitalsController : Controller
{
	private readonly MyContext _context;

	public HospitalsController(MyContext context)
	{
		_context = context;
	}

	// GET: Hospitals
	public IActionResult Index()
	{
		return View(_context.Hospitals.ToList());
	}

	// GET: Hospitals/Details/5
	public IActionResult Details(int id)
	{
		var hospital = _context.Hospitals.Find(id);
		if (hospital == null) return NotFound();
		return View(hospital);
	}

	// GET: Hospitals/Create
	public IActionResult Create()
	{
		return View();
	}

	// POST: Hospitals/Create
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Create(Hospital hospital)
	{
		if (ModelState.IsValid)
		{
			_context.Hospitals.Add(hospital);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
		return View(hospital);
	}

	// GET: Hospitals/Edit/5
	public IActionResult Edit(int id)
	{
		var hospital = _context.Hospitals.Find(id);
		if (hospital == null) return NotFound();
		return View(hospital);
	}

	// POST: Hospitals/Edit/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Edit(int id, Hospital hospital)
	{
		if (id != hospital.Id) return NotFound();
		if (ModelState.IsValid)
		{
			_context.Update(hospital);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
		return View(hospital);
	}

	// GET: Hospitals/Delete/5
	public IActionResult Delete(int id)
	{
		var hospital = _context.Hospitals.Find(id);
		if (hospital == null) return NotFound();
		return View(hospital);
	}

	// POST: Hospitals/Delete/5
	[HttpPost, ActionName("Delete")]
	[ValidateAntiForgeryToken]
	public IActionResult DeleteConfirmed(int id)
	{
		var hospital = _context.Hospitals.Find(id);
		if (hospital != null)
		{
			_context.Hospitals.Remove(hospital);
			_context.SaveChanges();
		}
		return RedirectToAction(nameof(Index));
	}
}
