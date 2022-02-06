﻿using Antropov.TaskManager.Data.Models;

namespace Antropov.TaskManager.Data.Repositories;

public interface ITaskRepository
{
	void Get(int taskId);
	void Add(TaskObject task);
	void Update(int taskId, TaskObject task);
	void Remove(int taskId);
}