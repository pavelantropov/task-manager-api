using Antropov.TaskManager.Api.ApiModels;
using Antropov.TaskManager.Api.Models;
using Antropov.TaskManager.Api.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Antropov.TaskManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class TasksController
{
	private readonly ITaskService _service;

	public TasksController(ITaskService service)
	{
		_service = service;
	}
}