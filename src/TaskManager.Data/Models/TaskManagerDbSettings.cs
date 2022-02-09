namespace Antropov.TaskManager.Data.Models;

public class TaskManagerDbSettings
{
	public string ConnectionString { get; set; } = null!;

	public string DatabaseName { get; set; } = null!;

	public string TasksCollectionName { get; set; } = null!;
}