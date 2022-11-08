using FlutterApiBlog.Models;
namespace FlutterApiBlog.Models;

public class Post
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string[] Tags { get; set; }
    public bool ReadTime { get; set; } = false;
    public string PhotoUrl { get; set; } = string.Empty;
    public bool HasReadLater { get; set; } = false;

    public User? Author { get; set; }
    public string Content { get; set; } = string.Empty;
}