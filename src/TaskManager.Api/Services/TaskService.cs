using System;
using System.Collections.Generic;

using Antropov.TaskManager.Api.Models;

namespace Antropov.TaskManager.Api.Services;

public class TaskService : ITaskService
{
	public List<TaskObject>? GetAllTasks()
	{
		throw new NotImplementedException();
	}

	public TaskObject? GetTask(int taskId)
	{
		throw new NotImplementedException();
	}

	public void CreateTask(TaskObject task)
	{
		throw new NotImplementedException();
	}
}