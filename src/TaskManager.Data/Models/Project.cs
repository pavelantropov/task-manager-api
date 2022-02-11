using System;
using System.Collections.Generic;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Antropov.TaskManager.Data.Models;

public class Project
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string ProjectId { get; set; } = null!;

	public string Title { get; set; } = null!;
	public string? Description { get; set; }
	public DateTime? Deadline { get; set; }

	public List<TaskObject>? Tasks { get; set; }
}