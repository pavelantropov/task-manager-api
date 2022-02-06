using System;
using System.Collections.Generic;

using Antropov.TaskManager.Data.Models;

namespace Antropov.TaskManager.Data;

// Replace with a database
public static class Data
{
	public static List<TaskObject>? Tasks { get; }

	static Data()
	{
		Tasks = new List<TaskObject>
		{
			new ()
			{
				TaskId = 1,
				Title = "Complete AZ-900 MS learning path",
				Description = "Complete the remaining modules. Start preparing for the exam for real",
				Deadline = new DateTime(2022, 02, 07),
			},
			new ()
			{
				TaskId = 2,
				Title = "Get rid of the intern status",
				Description = "Become a real Junior Software Engineer finally. Get a 3x raise",
				Deadline = new DateTime(2022, 02, 16),
			},
			new ()
			{
				TaskId = 3,
				Title = "Credit card payment",
				Description = "Find ₽110,000 and deposit to the Sberbank credit card",
				Deadline = new DateTime(2022, 02, 28),
			},
		};
	}
}