using System.Collections.Generic;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(string commenterName, string text)
    {
        Comment comment = new Comment { CommenterName = commenterName, Text = text };
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public List<Comment> Comments
    {
        get { return _comments; }
    }
}
