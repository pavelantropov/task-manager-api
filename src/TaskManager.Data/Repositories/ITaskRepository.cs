using System.Collections.Generic;

using Antropov.TaskManager.Data.Models;

namespace Antropov.TaskManager.Data.Repositories;

public interface ITaskRepository
{
	TaskObject? Get(int taskId);
	void Add(TaskObject task);
	void AddRange(List<TaskObject> tasks);
	void Update(int taskId, TaskObject task);
	void Remove(int taskId);
}