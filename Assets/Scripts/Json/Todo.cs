using Newtonsoft.Json;

public class Todo
{
    [JsonProperty("userId")]
    public int UserId { get; set; }
    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("title")]
    public string Title { get; set; }
    [JsonProperty("completed")]
    public bool Completed { get; set; }

    public Todo(int userId, int id, string title, bool completed)
    {
        UserId = userId;
        Id = id;
        Title = title;
        Completed = completed;
    }
}