using System.Collections.Generic;

using Antropov.TaskManager.Data.Models;

namespace Antropov.TaskManager.Api.Services;

public interface ITaskService
{
	List<TaskObject>? GetAllTasks();
	TaskObject? GetTask(int taskId);
	void CreateTask(TaskObject task);
}