using System;
using System.Collections.Generic;

using Antropov.TaskManager.Data.Models;

namespace Antropov.TaskManager.Data.Repositories;

public class TaskRepository : ITaskRepository
{
	private List<TaskObject>? _tasks;

	public List<TaskObject>? Tasks
	{
		get
		{
			if (_tasks == null) return _tasks;

			var clone = new List<TaskObject>();
			clone.AddRange(_tasks);
			return clone;
		}
		set
		{
			_tasks = value;
		}
	}

	public TaskRepository()
	{
		_tasks = Data.Tasks;
	}

	public TaskObject? Get(int taskId)
	{
		return Tasks?.Find(o => o.TaskId == taskId);
	}

	public void Add(TaskObject task)
	{
		Tasks?.Add(task);
	}

	public void AddRange(List<TaskObject> tasks)
	{
		Tasks?.AddRange(tasks);
	}

	public void Update(int taskId, TaskObject task)
	{
		throw new NotImplementedException();
	}

	public void Remove(int taskId)
	{
		var task = Get(taskId);
		if (task != null)
			Tasks?.Remove(task);
	}
}