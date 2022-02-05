using System;

namespace Antropov.TaskManager.Api.ApiModels;

public class CreateTaskInput
{
	public string? Title { get; set; }
	public string? Description { get; set; }
	public DateTime? Deadline { get; set; }
}