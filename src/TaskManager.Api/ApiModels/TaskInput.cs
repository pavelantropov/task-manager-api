using System;
using System.Collections.Generic;

namespace Antropov.TaskManager.Api.ApiModels;

public class TaskInput
{
	public string? Title { get; set; }
	public string? Description { get; set; }
	public DateTime? Deadline { get; set; }
	public List<string>? Labels { get; set; }
}