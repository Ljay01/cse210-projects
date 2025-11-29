
public class Video
{
    public string _title;
    public string _author;
    public int _length;
    public List<Comment> _comments = new List<Comment>();
    public int GetCommentCount()
    {
        return _comments.Count;
    }
}