using System;

namespace Antropov.TaskManager.Data.Models;

public class TaskObject
{
	public int TaskId { get; set; }
	public string? Title { get; set; }
	public string? Description { get; set; }
	public DateTime? Deadline { get; set; }

	public Project? Project { get; set; }
}