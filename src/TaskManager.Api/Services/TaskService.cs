using System;
using System.Collections.Generic;

using Antropov.TaskManager.Data.Models;
using Antropov.TaskManager.Data.Repositories;

namespace Antropov.TaskManager.Api.Services;

public class TaskService : ITaskService
{
	private readonly ITaskRepository _repository;

	public TaskService(ITaskRepository repository)
	{
		_repository = repository;
	}

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