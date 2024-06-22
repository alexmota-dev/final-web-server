namespace my_app.Entitys
{
    public class Book
    {
        public long Id {  get; set; }
        public string Title { get; set; }
        public string Storyline { get; set; }
        public string URL { get; set; }

        public Book(long id, string title, string storyline, string url)
        {
            Id = id;
            Title = title;
            Storyline = storyline;
            URL = url;
        }
    }
}
