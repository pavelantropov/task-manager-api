using Antropov.TaskManager.Api.Models;

namespace Antropov.TaskManager.Api.Services;

public interface ITaskService
{
	void CreateTask(TaskObject task);
}