using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Antropov.TaskManager.Data.Models;

using Microsoft.Extensions.Options;

using MongoDB.Driver;

namespace Antropov.TaskManager.Api.Services;

public class TaskService : ITaskService
{
	private readonly IMongoCollection<TaskObject> _tasksCollection;

	public TaskService(IOptions<TaskManagerDbSettings> taskManagerDbSettings)
	{
		var mongoClient = new MongoClient(taskManagerDbSettings.Value.ConnectionString);
		var mongoDatabase = mongoClient.GetDatabase(taskManagerDbSettings.Value.DatabaseName);
		_tasksCollection = mongoDatabase.GetCollection<TaskObject>(taskManagerDbSettings.Value.TasksCollectionName);
	}

	async public Task<List<TaskObject>?> GetAsync() =>
		await _tasksCollection.Find(_ => true).ToListAsync();

	async public Task<TaskObject?> GetAsync(string id) => 
		await _tasksCollection.Find(t => t.TaskId == id).FirstOrDefaultAsync();

	async public Task CreateAsync(TaskObject newTask) =>
		await _tasksCollection.InsertOneAsync(newTask);

	async public Task UpdateAsync(string id, TaskObject updatedTask) =>
		await _tasksCollection.ReplaceOneAsync(t => t.TaskId == id, updatedTask);

	async public Task RemoveAsync(string id) =>
		await _tasksCollection.DeleteOneAsync(t => t.TaskId == id);
}