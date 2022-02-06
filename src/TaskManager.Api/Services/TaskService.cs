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
		return _repository.Tasks;
	}

	public TaskObject? GetTask(int taskId)
	{
		return _repository.Get(taskId);
	}

	public void CreateTask(TaskObject task)
	{
		_repository.Add(task);
	}
}