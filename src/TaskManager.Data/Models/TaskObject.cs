using System;
using System.Collections.Generic;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Antropov.TaskManager.Data.Models;

public class TaskObject
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string TaskId { get; set; } = null!;

	public string Title { get; set; } = null!;
	public string? Description { get; set; }
	public DateTime? Deadline { get; set; }
	public List<string>? Labels { get; set; }

	// public Project? Project { get; set; }
}