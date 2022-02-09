using System.Threading.Tasks;

using Antropov.TaskManager.Api.ApiModels;
using Antropov.TaskManager.Api.Services;
using Antropov.TaskManager.Data.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Antropov.TaskManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class TasksController : Controller
{
	private readonly ITaskService _service;

	public TasksController(ITaskService service)
	{
		_service = service;
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	async public Task<IActionResult> GetAllTasks()
	{
		var tasks = await _service.GetAsync();

		return Ok(tasks);
	}

	[HttpGet("/{taskId}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	async public Task<IActionResult> GetTask(string taskId)
	{
		var task = await _service.GetAsync(taskId);

		return task == null ? NotFound() : Ok(task);
	}

	[HttpPost]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	async public Task<IActionResult> CreateTask([FromBody] CreateTaskInput input)
	{
		var task = new TaskObject
		{
			Title = input.Title,
			Description = input.Description,
			Deadline = input.Deadline,
			Labels = input.Labels,
		};
		await _service.CreateAsync(task);
		return Ok(input);
	}
}