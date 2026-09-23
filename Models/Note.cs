using SQLite;

namespace NotesApp.Models;

public class Note
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public string Category { get; set; } = "General";
    public string Color { get; set; } = "#FFF59D"; // default sticky-note yellow
    public bool Pinned { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}