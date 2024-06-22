namespace my_app.Entitys
{
    public class Note
    {
        public long Id {  get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Note(long id, string title, string content)
        {
            Id = id;
            Title = title;
            Content = content;
        }
    }
}
