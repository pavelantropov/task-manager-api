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
	async public Task<IActionResult> Get()
	{
		var tasks = await _service.GetAsync();

		return Ok(tasks);
	}

	[HttpGet("/{id:length(24)}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	async public Task<IActionResult> Get(string id)
	{
		var task = await _service.GetAsync(id);

		return task == null ? NotFound() : Ok(task);
	}

	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	async public Task<IActionResult> Create([FromBody] TaskInput input)
	{
		var newTask = new TaskObject
		{
			Title = input.Title,
			Description = input.Description,
			Deadline = input.Deadline,
			Labels = input.Labels,
		};
		await _service.CreateAsync(newTask);
		return CreatedAtAction(nameof(Get), new { id = newTask.TaskId }, newTask);
	}


	[HttpPut("{id:length(24)}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Update(string id, TaskInput input)
	{
		var task = await _service.GetAsync(id);

		if (task is null)
		{
			return NotFound();
		}

		var updatedTask = new TaskObject
		{
			TaskId = task.TaskId,
			Title = input.Title,
			Description = input.Description,
			Deadline = input.Deadline,
			Labels = input.Labels,
		};

		await _service.UpdateAsync(id, updatedTask);

		return Ok();
	}

	[HttpDelete("{id:length(24)}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Delete(string id)
	{
		var task = await _service.GetAsync(id);

		if (task is null)
		{
			return NotFound();
		}

		await _service.RemoveAsync(id);

		return Ok();
	}
}