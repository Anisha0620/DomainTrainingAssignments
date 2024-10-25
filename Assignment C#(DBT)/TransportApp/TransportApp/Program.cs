using System;

public class Program
{
	public static void Main(string[] args)
	{
		TransportManager manager = new TransportManager();

		manager.AddSchedule(new TransportSchedule("bus", "Chennai to Coimbatore", new DateTime(2024, 10, 30, 9, 0, 0), new DateTime(2024, 10, 30, 12, 0, 0), 20.5m, 30));
		manager.AddSchedule(new TransportSchedule("flight", "Coimbatore to Trichy", new DateTime(2024, 10, 31, 14, 30, 0), new DateTime(2024, 10, 31, 16, 0, 0), 150.0m, 50));
		manager.AddSchedule(new TransportSchedule("bus", "Chennai to Pondicherry", new DateTime(2024, 10, 30, 11, 0, 0), new DateTime(2024, 10, 30, 13, 30, 0), 25.0m, 20));

		var flights = manager.Search(transportType: "flight");
		Console.WriteLine("Flights:");
		foreach (var flight in flights)
		{
			Console.WriteLine($"{flight.Route}, {flight.DepartureTime}, {flight.Price}");
		}

		// Group by transport type
		var grouped = manager.GroupByTransportType();
		Console.WriteLine("\nGrouped by Transport Type:");
		foreach (var group in grouped)
		{
			Console.WriteLine($"Type: {group.Key}");
			foreach (var schedule in group)
			{
				Console.WriteLine($"  {schedule.Route}");
			}
		}

		// Order by price
		var orderedSchedules = manager.OrderBy("price");
		Console.WriteLine("\nOrdered by Price:");
		foreach (var schedule in orderedSchedules)
		{
			Console.WriteLine($"{schedule.Route}, {schedule.Price}");
		}

		// Aggregate data
		var aggregateData = manager.Aggregate();
		Console.WriteLine($"\nTotal Seats Available: {aggregateData.totalSeats}, Average Price: {aggregateData.averagePrice}");

		// routes and departure times
		var routesAndTimes = manager.SelectRoutesAndTimes();
		Console.WriteLine("\nRoutes and Departure Times:");
		foreach (var item in routesAndTimes)
		{
			Console.WriteLine($"{item.Route}, {item.DepartureTime}");
		}
	}
}

