using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class AppointmentsController : Controller
{
	private readonly MyContext _context;

	public AppointmentsController(MyContext context)
	{
		_context = context;
	}

	// GET: Appointments
	public IActionResult Index()
	{
		return View(_context.Appointments.ToList());
	}

	// GET: Appointments/Details/5
	public IActionResult Details(int id)
	{
		var appointment = _context.Appointments.Find(id);
		if (appointment == null) return NotFound();
		return View(appointment);
	}

	// GET: Appointments/Create
	public IActionResult Create()
	{
		return View();
	}

	// POST: Appointments/Create
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Create(Appointment appointment)
	{
		if (ModelState.IsValid)
		{
			_context.Appointments.Add(appointment);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
		return View(appointment);
	}

	// GET: Appointments/Edit/5
	public IActionResult Edit(int id)
	{
		var appointment = _context.Appointments.Find(id);
		if (appointment == null) return NotFound();
		return View(appointment);
	}

	// POST: Appointments/Edit/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Edit(int id, Appointment appointment)
	{
		if (id != appointment.Id) return NotFound();
		if (ModelState.IsValid)
		{
			_context.Update(appointment);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
		return View(appointment);
	}

	// GET: Appointments/Delete/5
	public IActionResult Delete(int id)
	{
		var appointment = _context.Appointments.Find(id);
		if (appointment == null) return NotFound();
		return View(appointment);
	}

	// POST: Appointments/Delete/5
	[HttpPost, ActionName("Delete")]
	[ValidateAntiForgeryToken]
	public IActionResult DeleteConfirmed(int id)
	{
		var appointment = _context.Appointments.Find(id);
		if (appointment != null)
		{
			_context.Appointments.Remove(appointment);
			_context.SaveChanges();
		}
		return RedirectToAction(nameof(Index));
	}
}

