using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Antropov.TaskManager.Api.ApiModels;
using Antropov.TaskManager.Api.Controllers;
using Antropov.TaskManager.Api.Services;
using Antropov.TaskManager.Data.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

using Moq;

using Newtonsoft.Json;

using NUnit.Framework;

namespace Antropov.TaskManager.Api.Tests
{
	[TestFixture]
	public class TaskControllerTests
	{
		private HttpClient _client;
		private readonly WebApplicationFactory<Program> _factory;

		private TasksController? _controller;
		private Mock<ITaskService>? _serviceMock;

		public TaskControllerTests()
		{
			_factory = new WebApplicationFactory<Program>();
			_client = _factory.CreateClient();
		}

		#region POST
		[Test]
		public async Task MockCreateTask_NoExceptionsThrown_ReturnsOk()
		{
			_serviceMock = new Mock<ITaskService>();
			_controller = new TasksController(_serviceMock.Object);
			var input = new TaskInput
			{
				Title = "test",
				Description = "test",
				Deadline = new DateTime(),
			};
			_serviceMock.Setup(s => s.CreateAsync(It.IsAny<TaskObject>()));

			var result = await _controller.Create(input);
			var createdResult = result as CreatedAtActionResult;

			Assert.IsNotNull(createdResult);
			Assert.AreEqual(201, createdResult?.StatusCode);
		}

		[Test]
		public async Task CreateTask_TaskAdded_ReturnsSuccess()
		{
			_serviceMock = new Mock<ITaskService>();
			_serviceMock.Setup(s => s.CreateAsync(It.IsAny<TaskObject>()));
			_client = _factory.WithWebHostBuilder(builder =>
					builder.ConfigureTestServices(services =>
						services.AddScoped(_ => _serviceMock.Object)))
				.CreateClient();
			const string url = @"api/tasks";
			var data = new
			{
				Title = "test",
				Description = "test",
				Deadline = new DateTime(),
			};
			var content = JsonConvert.SerializeObject(data);
			var buffer = System.Text.Encoding.UTF8.GetBytes(content);
			var byteContent = new ByteArrayContent(buffer);
			byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			var response = await _client.PostAsync(url, byteContent);

			response.EnsureSuccessStatusCode();
			Assert.Null(response.Headers.Location?.OriginalString);
		}

		[Test]
		public async Task CreateTask_TaskNotAdded_ReturnsErrorCode()
		{
			_serviceMock = new Mock<ITaskService>();
			_serviceMock.Setup(s => s.CreateAsync(It.IsAny<TaskObject>())).Throws<Exception>();
			_client = _factory.WithWebHostBuilder(builder =>
					builder.ConfigureTestServices(services =>
					{
						services.AddScoped(_ => _serviceMock.Object);
					}))
				.CreateClient();
			const string url = @"api/tasks";
			var data = new
			{
				Title = "test",
				Description = "test",
				Deadline = new DateTime(),
			};
			var content = JsonConvert.SerializeObject(data);
			var buffer = System.Text.Encoding.UTF8.GetBytes(content);
			var byteContent = new ByteArrayContent(buffer);
			byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			var response = await _client.PostAsync(url, byteContent);

			Assert.AreEqual(false, response.IsSuccessStatusCode);
			Assert.Null(response.Headers.Location?.OriginalString);
		}
		#endregion
	}
}