public class LinqQuery
{
    public List<Book> BookCollection = new List<Book>();

    public LinqQuery()
    {
        using(StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.BookCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(
                json,
                new System.Text.Json.JsonSerializerOptions() {
                    PropertyNameCaseInsensitive = true
                }
            )!;
        }
    }

    public IEnumerable<Book> GetCollection()
    {
        return BookCollection;
    }
}
