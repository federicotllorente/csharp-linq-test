LinqQuery query = new LinqQuery();

PrintValues(query.GetCollection());

void PrintValues(IEnumerable<Book> bookList)
{
    Console.WriteLine("{0,-60} {1,15} {2,15}\n", "Title", "Pages", "Publishing date");

    foreach (var item in bookList)
    {
        Console.WriteLine("{0,-60} {1,15} {2,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}
