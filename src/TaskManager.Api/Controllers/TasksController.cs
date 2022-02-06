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
	public IActionResult GetAllTasks()
	{
		var tasks = _service.GetAllTasks();

		return tasks == null ? BadRequest() : Ok(tasks);
	}

	[HttpGet("/{taskId}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult GetTask(int taskId)
	{
		var task = _service.GetTask(taskId);

		return task == null ? NotFound() : Ok(task);
	}

	[HttpPost("/")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public IActionResult CreateTask([FromBody] CreateTaskInput input)
	{
		var task = new TaskObject
		{
			Title = input.Title,
			Description = input.Description,
			Deadline = input.Deadline,
		};
		_service.CreateTask(task);
		return Ok(input);
	}
}