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

    public IEnumerable<Book> GetAll()
    {
        return BookCollection;
    }

    public IEnumerable<Book> GetAllFromYear(int year)
    {
        return BookCollection.Where(p => p.PublishedDate.Year == year);
    }

    public IEnumerable<Book> GetAllFromYearToNow(int year)
    {
        return BookCollection.Where(p => p.PublishedDate.Year >= year);
    }

    public IEnumerable<Book> GetAllFromTitle(string search)
    {
        return BookCollection.Where(p => p.Title.Contains(search, StringComparison.CurrentCultureIgnoreCase));
    }

    public IEnumerable<Book> GetAllFromCategory(string search, Order? order = Order.None)
    {
        if(order == Order.Ascending) {
            return BookCollection.Where(p => p.Categories.Contains(search)).OrderBy(p => p.Title);
        }

        if(order == Order.Descending) {
            return BookCollection.Where(p => p.Categories.Contains(search)).OrderByDescending(p => p.Title);
        }

        return BookCollection.Where(p => p.Categories.Contains(search));
    }
}

public enum Order
{
    None,
    Ascending,
    Descending,
}
