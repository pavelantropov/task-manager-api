using System;
using System.Collections.Generic;

namespace Antropov.TaskManager.Data.Models;

public class Project
{
	public int ProjectId { get; set; }
	public string? Title { get; set; }
	public string? Description { get; set; }
	public DateTime? Deadline { get; set; }

	public List<TaskObject>? Tasks { get; set; }
}