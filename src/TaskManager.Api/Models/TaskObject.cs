﻿using System;

namespace Antropov.TaskManager.Api.Models;

public class TaskObject
{
	public string? Title { get; set; }
	public string? Description { get; set; }
	public DateTime? Deadline { get; set; }
}