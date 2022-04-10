using Newtonsoft.Json;

public class Album
{
    [JsonProperty("userId")] 
    public int UserId { get; set; }
    [JsonProperty("id")] 
    public int Id { get; set; }
    [JsonProperty("title")] 
    public string Title { get; set; }
   
    public Album(int userId, int id, string title)
    {
        UserId = userId;
        Id = id;
        Title = title;
    }
}
