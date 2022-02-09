using System.Collections.Generic;
using System.Threading.Tasks;

using Antropov.TaskManager.Data.Models;

namespace Antropov.TaskManager.Api.Services;

public interface ITaskService
{
	Task<List<TaskObject>> GetAsync();
	Task<TaskObject?> GetAsync(string id);
	Task CreateAsync(TaskObject task);
	Task UpdateAsync(string id, TaskObject task);
	Task RemoveAsync(string id);
}