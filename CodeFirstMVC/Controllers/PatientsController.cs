using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class PatientsController : Controller
{
	private readonly MyContext _context;

	public PatientsController(MyContext context)
	{
		_context = context;
	}

	// GET: Patients
	public IActionResult Index()
	{
		return View(_context.Patients.ToList());
	}

	// GET: Patients/Details/5
	public IActionResult Details(int id)
	{
		var patient = _context.Patients.Find(id);
		if (patient == null) return NotFound();
		return View(patient);
	}

	// GET: Patients/Create
	public IActionResult Create()
	{
		return View();
	}

	// POST: Patients/Create
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Create(Patient patient)
	{
		if (ModelState.IsValid)
		{
			_context.Patients.Add(patient);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
		return View(patient);
	}

	// GET: Patients/Edit/5
	public IActionResult Edit(int id)
	{
		var patient = _context.Patients.Find(id);
		if (patient == null) return NotFound();
		return View(patient);
	}

	// POST: Patients/Edit/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Edit(int id, Patient patient)
	{
		if (id != patient.Id) return NotFound();
		if (ModelState.IsValid)
		{
			_context.Update(patient);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
		return View(patient);
	}

	// GET: Patients/Delete/5
	public IActionResult Delete(int id)
	{
		var patient = _context.Patients.Find(id);
		if (patient == null) return NotFound();
		return View(patient);
	}

	// POST: Patients/Delete/5
	[HttpPost, ActionName("Delete")]
	[ValidateAntiForgeryToken]
	public IActionResult DeleteConfirmed(int id)
	{
		var patient = _context.Patients.Find(id);
		if (patient != null)
		{
			_context.Patients.Remove(patient);
			_context.SaveChanges();
		}
		return RedirectToAction(nameof(Index));
	}
}

