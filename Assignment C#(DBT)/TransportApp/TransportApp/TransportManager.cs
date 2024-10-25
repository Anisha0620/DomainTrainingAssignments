using System;
using System.Collections.Generic;
using System.Linq;

public class TransportManager
{
	private List<TransportSchedule> schedules;

	public TransportManager()
	{
		schedules = new List<TransportSchedule>();
	}

	public void AddSchedule(TransportSchedule schedule)
	{
		schedules.Add(schedule);
	}

	
	public IEnumerable<TransportSchedule> Search(string transportType = null, string route = null, DateTime? departureTime = null)
	{
		var query = schedules.AsQueryable();

		if (!string.IsNullOrEmpty(transportType))
			query = query.Where(s => s.TransportType.Equals(transportType, StringComparison.OrdinalIgnoreCase));

		if (!string.IsNullOrEmpty(route))
			query = query.Where(s => s.Route.Equals(route, StringComparison.OrdinalIgnoreCase));

		if (departureTime.HasValue)
			query = query.Where(s => s.DepartureTime.Date == departureTime.Value.Date);

		return query.ToList();
	}

	
	public IEnumerable<IGrouping<string, TransportSchedule>> GroupByTransportType()
	{
		return schedules.GroupBy(s => s.TransportType);
	}

	
	public IEnumerable<TransportSchedule> OrderBy(string orderBy)
	{
		return orderBy.ToLower() switch
		{
			"departuretime" => schedules.OrderBy(s => s.DepartureTime),
			"price" => schedules.OrderBy(s => s.Price),
			"seatsavailable" => schedules.OrderBy(s => s.SeatsAvailable),
			_ => schedules
		};
	}

	
	public IEnumerable<TransportSchedule> Filter(DateTime startTime, DateTime endTime, int minimumSeats)
	{
		return schedules.Where(s => s.SeatsAvailable >= minimumSeats && s.DepartureTime >= startTime && s.DepartureTime <= endTime).ToList();
	}

	
	public (int totalSeats, decimal averagePrice) Aggregate()
	{
		int totalSeats = schedules.Sum(s => s.SeatsAvailable);
		decimal averagePrice = schedules.Any() ? schedules.Average(s => s.Price) : 0;
		return (totalSeats, averagePrice);
	}

	
	public IEnumerable<(string Route, DateTime DepartureTime)> SelectRoutesAndTimes()
	{
		return schedules.Select(s => (s.Route, s.DepartureTime)).ToList();
	}
}
