using Newtonsoft.Json;

public class Photos
{
    [JsonProperty("albumId")] 
    public int AlbumId { get; set; }
    [JsonProperty("id")] 
    public int Id { get; set; }
    [JsonProperty("title")] 
    public string Title { get; set; }
    [JsonProperty("url")] 
    public string Url { get; set; }
    [JsonProperty("thumbnailUrl")] 
    public string ThumbnailUrl { get; set; }

    public Photos(int albumId, int id, string title, string url, string thumbnailUrl)
    {
        AlbumId = albumId;
        Id = id;
        Title = title;
        Url = url;
        ThumbnailUrl = thumbnailUrl;
    }
}
