using System;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Antropov.TaskManager.Data.Models;

public class TaskObject
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string? TaskId { get; set; }


	public string? Title { get; set; }
	public string? Description { get; set; }
	public DateTime? Deadline { get; set; }

	public Project? Project { get; set; }
}